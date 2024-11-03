using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface ILogin
    {
        Task<ApiResponse<string>> Register(LoginDtos login);
        Task<ApiResponse<bool>> Exists(LoginDtos login);
          Task<ApiResponse<string>> Access(LoginDtos login);
          ApiResponse<TokenDtos> CreateToken(LoginDtos Login);
          Task<ApiResponse<List<SecurityQuestionsDtos>>> GetSecurityQuestions();
          Task<ApiResponse<bool>> ValidateEfin(string username);
          Task<ApiResponse<RecoveryDto>> Getmyzipcode(string username);
    }
}