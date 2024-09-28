using AutoMapper;
using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.DTOs;
using refund.Utilities;
using refund.Validators;
using Serilog;


namespace refund.Libs
{
    public class ValidateLibs : IValidators, ICityValidate, IStateValidators
    {
       private readonly DbContextPlayer _db;
       private readonly IMapper _mapper;
       public ValidateLibs(DbContextPlayer db,IMapper mapper)
        {
            _db=db;
            _mapper=mapper; 
        }

        public async Task<bool> Exists(CityDto city)
        {
        var normalizedname = city.Name.Trim().ToLower();
        bool Exists =await _db.City.FirstOrDefaultAsync(a=>a.Name.Trim().ToLower().StartsWith(normalizedname))!=null? true:false;
        return Exists;
        }

        public async Task<ApiResponse<string>> PropertiesValidate(string name)
        {
                bool res=false;           
            string message="you should complete the form";
            try
            {
             
           if (string.IsNullOrEmpty(name))
            {
                return new ApiResponse<string>(false," request invalid",null!);
            }
            else{
                var normalizedname = name.Trim().ToLower();


             var existe = await _db.TaxPreparer.AsNoTracking().Where(x => x.Name.Trim().ToLower().StartsWith(normalizedname)).FirstAsync();
             var mapped =_mapper.Map<TaxPreparerDto>(existe);
            // var Properties =  
            #if existssomefieldnull
                if (mapped.Name!=null && mapped.Address==null || mapped.Brand==null || mapped.Phone==null)
                { res=true;
                     
                }
            #endif      
          
            }
               return new ApiResponse<string>(res,res==true?message:"the properties is completed",null!);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                return new ApiResponse<string>(res,ex.Message,null!);
               
            }
           
        }


       public async Task<ApiResponse<string>>  RecordExistsValidate(string name)
        {
              var normalizedname = name.Trim().ToLower();
        string message=string.Empty;
        bool response =false;

                var Exists =await _db.TaxPreparer.FirstOrDefaultAsync(a=>a.Name.Trim().ToLower().StartsWith(name));
            // var existe =await _db.TaxPreparer.Where(a=>a.Name.Trim().ToLower().StartsWith(name)).FirstAsync()!=null? true:false;
           if (Exists!=null)
           {
                message="This record is already registered";
                response=true;
           }
           else
           {
            message="This record isnt registered";
             response=false;
           }
           
            return new ApiResponse<string>(response,message,null!); 
        }

        public async Task<bool> StateExists(StateDto state)
        {
             var normalizedname = state.Name.Trim().ToLower();
        bool Exists =await _db.State.FirstOrDefaultAsync(a=>a.Name.Trim().ToLower().StartsWith(normalizedname))!=null? true:false;
        return Exists;
        }
    }
}