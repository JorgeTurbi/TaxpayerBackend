using AutoMapper;
using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.DTOs;
using refund.Models;
using refund.Services;
using refund.Utilities;
using Serilog;

namespace refund.Libs
{
    public class TaxPreparerLibs : ITaxPreparer
    {

        public readonly IMapper Mapper;
         public readonly IValidators _validate;
        private readonly DbContextPlayer _db;
        public TaxPreparerLibs(DbContextPlayer db, IMapper mapper,IValidators validate)
        {
            _db = db;
            Mapper = mapper;
            _validate=validate;
        }
        public async Task<ApiResponse<TaxPreparerDto>> Create(TaxPreparerDto preparerDto)
        {
            try
            {
                 
                if (!string.IsNullOrEmpty(preparerDto.Name))
                {
                    
                    // if (preparerDto.Brand != null)
                    // { 
                      
                    //  byte[] imageData = File.ReadAllBytes(preparerDto.Brand);
                    //       string base64String = Convert.ToBase64String(imageData);
                    //        preparerDto.Brand = base64String;
                    // }
                //       var message = await  _validate.TaxPreparerExits(preparerDto.Username);
                //    if (message)
                //    {
                  
                //    }
                         
                    var mapped = Mapper.Map<TaxPreparer>(preparerDto);
                    await _db.TaxPreparer.AddAsync(mapped);
                    bool saved = await _db.SaveChangesAsync() > 0 ? true : false;
                    if (saved)
                    {
                            TaxPreparer? data = await _db.TaxPreparer.FindAsync(mapped.TaxPreparerId);
                            if (data!=null)
                            {
                              TaxPreparerDto  mapReverse = Mapper.Map<TaxPreparerDto>(data);
                               Log.Information("Created successfully =>{@result}", mapped);
                              return new ApiResponse<TaxPreparerDto>(true, "Created successfully", mapReverse);
                            }
                            else
                            {
                                    Log.Error("An error occurred while creating the register");
                        return new ApiResponse<TaxPreparerDto>(false, "An error occurred while  creating the register", null!);
                            }

                        
                    }
                    else
                    {
                        Log.Error("An error occurred while creating the register");
                        return new ApiResponse<TaxPreparerDto>(false, "An error occurred while  creating the register", null!);
                    }

                }
            }
            catch (Exception ex)
            {

                Log.Error("Error : " + ex.Message);
                return new ApiResponse<TaxPreparerDto>(false, ex.Message, null!);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            Log.Information("One or more properties are invalid");
            return new ApiResponse<TaxPreparerDto>(false, "One or more properties are invalid", null!);
        }

    

    public async Task<ApiResponse<string>> GetImagebyTaxPreparerId(int TaxPreparerId)
    {
        var Preparer = await _db.TaxPreparer.AsNoTracking().Where(a=>a.TaxPreparerId==TaxPreparerId).FirstOrDefaultAsync();
        if (Preparer!=null)
        {
            return new ApiResponse<string>(true,"success",Preparer.Brand!);
        }
        else{
            return new ApiResponse<string>(false,"An error ocurred",null!);
        }
    }
        public Task<ApiResponse<string>> Delete(int TaxPreparerId)
        {
            throw new NotImplementedException();
        }


        public async Task<ApiResponse<bool>> Check(string username)
        {
            string userLook= username.ToLower();
            bool exists= await _db.TaxPreparer.AsNoTracking().AnyAsync(a => a.Username == userLook);
            if (exists)
            {
                 return new ApiResponse<bool>(true,"IFI number exists",exists);
            }
            else{
                 return new ApiResponse<bool>(false,"IFI number not exists",exists);
            }
          
        }

        public async Task<ApiResponse<TaxPreparerDto>> GetDataPreparer(string username)
        {
            string userLook= username.ToLower();
            var exists= await _db.TaxPreparer.AsNoTracking().Where(a => a.Username == userLook).FirstOrDefaultAsync();
            if (exists!=null)
            {
                var Mapped =Mapper.Map<TaxPreparerDto>(exists);
                  return  new ApiResponse<TaxPreparerDto>(true,"Success",Mapped);
            }
            else{
              return  new ApiResponse<TaxPreparerDto>(false,"Not Found",null!);
            }
        }
        public async Task<ApiResponse<string>> ValidateZipCode(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new ApiResponse<string>(false,"Invalid ZipCode",null!);
            }
            string _username=username.ToLower();
            var user =await _db.User.AsNoTracking().Where(a=>a.Username==_username).FirstOrDefaultAsync();
            if (user==null)
            {
                  return new ApiResponse<string>(false,"Invalid ZipCode",null!);
            }
            return new ApiResponse<string>(true,"Success",user.Code.ToString());

        }
        public async Task<ApiResponse<List<TaxPreparerDto>>> GetAll()
        {
           var list = await _db.TaxPreparer.AsNoTracking().ToListAsync();

                var MappedList = Mapper.Map<List<TaxPreparerDto>>(list);
                return new ApiResponse<List<TaxPreparerDto>>(true,"Success",MappedList);
        }

        public Task<ApiResponse<TaxPreparerDto>> GetbyId(int TaxPreparerId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<string>> Update(TaxPreparerDto preparerDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TaxPreparerDto>> GetPreparer(string username)
        {
            throw new NotImplementedException();
        }
    }
}