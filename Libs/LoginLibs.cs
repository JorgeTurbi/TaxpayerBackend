using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using refund.ContextDir;
using refund.DTOs;
using refund.Models;
using refund.Services;
using refund.Utilities;
namespace refund.Libs
{
    public class LoginLibs : ILogin
    {
        public readonly IMapper Mapper;
        private readonly DbContextPlayer _db;
        private readonly ILogger<LoginLibs> _logger;
        private readonly IConfiguration _config;
        public LoginLibs(IMapper mapper, DbContextPlayer db, ILogger<LoginLibs> logger, IConfiguration config)
        {
            Mapper = mapper;
            _db = db;
            _logger = logger;
            _config = config;
        }

        public async Task<ApiResponse<string>> Access(LoginDtos login)
        {
            try
            {
                string Token = string.Empty;
                if (login is null)
                {
                    return null!;
                }
                string usernameLogin = login.Username.ToLower();
                string codeLogin = login.Code.ToLower();
                var ObjectLogin = new LoginDtos
                {
                    UserId = 0,
                    Username = usernameLogin,
                    Code = codeLogin,
                    Question = login.Question,
                    Response = login.Response?.ToLower()
                };
                var username = await _db.User.AsNoTracking().Where(a => a.Username == ObjectLogin.Username).FirstOrDefaultAsync();
                if (username != null)
                {
                    if (username.Code == ObjectLogin.Code)
                    {
                        var Object_Token = CreateToken(ObjectLogin);
                        if (Object_Token.Success)
                        {
                            return new ApiResponse<string>(Object_Token.Success, Object_Token!.Message!, Object_Token!.Data!.Token!);
                        }
                        else
                        {
                            return new ApiResponse<string>(false, "Token Error", null!);
                        }
                    }
                    else
                    {
                        return new ApiResponse<string>(false, "IFI or Custome Code Invalid", null!);
                    }
                }
                else
                {
                    var register = await Register(ObjectLogin);
                    if (register.Data != null && register.Success == true)
                    {
                        var Object_Token = CreateToken(ObjectLogin);
                        if (Object_Token.Success)
                        {
                            return new ApiResponse<string>(Object_Token.Success, Object_Token!.Message!, Object_Token!.Data!.Token!);
                        }
                        else
                        {
                            return new ApiResponse<string>(false, "Token Error", null!);
                        }

                    }
                    else
                    {
                        return new ApiResponse<string>(false, "Token Error", null!);
                    }
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message.ToString(), ex);
                return new ApiResponse<string>(false, ex.Message.ToString(), null!);
            }



        }

        public async Task<ApiResponse<bool>> ValidateEfin(string username)
        {
            string user = username.ToLower();
            if (string.IsNullOrEmpty(user))
            {
                return new ApiResponse<bool>(true, "An Error Ocurred", false);
            }
            bool Exists = await _db.User.Where(a => a.Username == user).FirstOrDefaultAsync() != null;
            return new ApiResponse<bool>(Exists, Exists == true ? "User exists" : "User not exists", Exists);
        }

        public async Task<ApiResponse<List<SecurityQuestionsDtos>>> GetSecurityQuestions()
        {
            var data = await _db.SecurityQuestions.ToListAsync();
            if (data == null)
            {
                return new ApiResponse<List<SecurityQuestionsDtos>>(false, "No data", null!);
            }
            var mapped = Mapper.Map<List<SecurityQuestionsDtos>>(data);
            return new ApiResponse<List<SecurityQuestionsDtos>>(true, "Success", mapped);

        }
        public ApiResponse<TokenDtos> CreateToken(LoginDtos Login)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtConfig = _config.GetSection("jwt").Get<Jwt>();

                var claims = new List<Claim>
                                             {
                        new Claim(ClaimTypes.Email,Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, Login.Username),
                        new Claim("postalcode",Login.Code),
                        new Claim(ClaimTypes.Expired, jwtConfig!.Expire! ),



                                             };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt16(jwtConfig.Expire)), // Token expira en 10 minutos
                    NotBefore = DateTime.UtcNow, // Token válido a partir de ahora
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig!.Key!)), SecurityAlgorithms.HmacSha256Signature)
                };




                TokenDtos TokenData = new();
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                TokenData.Token = jwtTokenHandler.WriteToken(token);



                return new ApiResponse<TokenDtos>(true, "New Token Created", TokenData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), ex);
                return new ApiResponse<TokenDtos>(false, ex.Message.ToString(), null!);

            }
        }

        public async Task<ApiResponse<bool>> Exists(LoginDtos login)
        {
            try
            {
                string username = login.Username.ToLower();
                string passCode = login.Code.ToLower();

                var user = await _db.User.Where(a => a.Username == username).FirstOrDefaultAsync();
                if (user != null)
                {
                    if (user.Code == passCode)
                    {
                        return new ApiResponse<bool>(true, "Success", true);
                    }
                    else
                    {
                        return new ApiResponse<bool>(true, "EFE or Custome Code Invalid", false!);
                    }
                }
                else
                {
                    return new ApiResponse<bool>(false, "EFE or Custome Code Invalid", false!);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), ex.Data);
                return new ApiResponse<bool>(true, "IFI or Custome Code Invalid", false!);
            }
        }
        private async Task<List<SecurityQuestions>> getQuestions()
        {
            return await _db.SecurityQuestions.ToListAsync();
        }
        public async Task<ApiResponse<RecoveryDto>> Getmyzipcode(string username)
        {
            string userName = username.ToLower();
            List<SecurityQuestions> Lst = await getQuestions();

            var data = await _db.User.AsNoTracking().Where(a => a.Username == userName).FirstOrDefaultAsync();
            if (data != null)
            {
                int QuestId = Convert.ToInt16(data.Question);
                string question = Lst.First(a => a.QuestionID == QuestId).QuestionText!.ToString();
                string response = data.Response!.ToString();
                var recover = new RecoveryDto
                {
                    Zipcode = data.Code.ToString(),
                    QuestionText = question,
                    Response = response
                };
                return new ApiResponse<RecoveryDto>(true, "Success", recover);
            }
            else
            {
                return new ApiResponse<RecoveryDto>(false, "ERROR", null!);
            }
        }

        public async Task<ApiResponse<string>> Register(LoginDtos login)
        {
            try
            {
                if (login is null)
                {
                    return new ApiResponse<string>(true, "invalid access", null!);
                }
                var response = await Exists(login);
                if (!response.Success && response.Data == false)
                {
                    var user = new User
                    {
                        Username = login.Username,
                        Code = login.Code,
                        Question = login.Question,
                        Response = login.Response,
                        Lastlogin = DateTime.UtcNow.ToString()
                    };

                    await _db.User.AddAsync(user);
                    return await _db.SaveChangesAsync() > 0 ? new ApiResponse<string>(true, "Success", "Welcome") : new ApiResponse<string>(true, "An error while attend to save data", "Error");
                }
                return null!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), ex.Data);
                return new ApiResponse<string>(false, "IFI or Custome Code Invalid", null!);
            }
        }
    }
}