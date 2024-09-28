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
        private readonly DbContextPlayer _db;
        public TaxPreparerLibs(DbContextPlayer db, IMapper mapper)
        {
            _db = db;
            Mapper = mapper;
        }
        public async Task<ApiResponse<string>> Create(TaxPreparerDto preparerDto)
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
                         
                    var mapped = Mapper.Map<TaxPreparer>(preparerDto);
                    await _db.TaxPreparer.AddAsync(mapped);
                    bool saved = await _db.SaveChangesAsync() > 0 ? true : false;
                    if (saved)
                    {
                        Log.Information("Created successfully =>{@result}", mapped);
                        return new ApiResponse<string>(true, "Created successfully", null!);
                    }
                    else
                    {
                        Log.Error("An error occurred while creating the register");
                        return new ApiResponse<string>(false, "An error occurred while  creating the register", null!);
                    }

                }
            }
            catch (Exception ex)
            {

                Log.Error("Error : " + ex.Message);
                return new ApiResponse<string>(false, ex.Message, null!);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            Log.Information("One or more properties are invalid");
            return new ApiResponse<string>(false, "One or more properties are invalid", null!);
        }

    
        public Task<ApiResponse<string>> Delete(int TaxPreparerId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<TaxPreparerDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TaxPreparerDto>> GetbyId(int TaxPreparerId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<string>> Update(TaxPreparerDto preparerDto)
        {
            throw new NotImplementedException();
        }
    }
}