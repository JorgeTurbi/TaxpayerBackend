
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
    public class IncometypeLibs : IIncometype
    {
        public readonly IMapper Mapper;
        private readonly DbContextPlayer _db;

        private readonly ILogger<IncometypeLibs> _logger;

        public IncometypeLibs(IMapper mapper, DbContextPlayer db, ILogger<IncometypeLibs> logger)
        {
            Mapper = mapper;
            _db = db;
            _logger = logger;
        }
        public async Task<ApiResponse<string>> Create(IncomeTypeDto income)
        {
            try
            {

                if (!string.IsNullOrEmpty(income.Nameincometype))
                {
                    var mapped = Mapper.Map<IncomeType>(income);
                    await _db.IncomeType.AddAsync(mapped);
                    bool saved = await _db.SaveChangesAsync() > 0 ? true : false;
                    if (saved)
                    {
                        Log.Information("Income Type created successfully =>{@result}", saved);
                        return new ApiResponse<string>(true, "Income Type created successfully", null!);

                    }
                    else
                    {
                        Log.Error("An error occurred while creating the Income Type");
                        return new ApiResponse<string>(false, "An error occurred while  the creating Income Type", null!);
                    }

                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error : " + ex.Message);
                return new ApiResponse<string>(false, ex.Message, null!);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            Log.Information("One or more properties are invalid");
            return new ApiResponse<string>(false, "One or more properties are invalid", null!);

        }

        public async Task<ApiResponse<string>> Delete(int IncomeTypeId)
        {
            try
            {
                var SelectedToDelete = await _db.IncomeType.FindAsync(IncomeTypeId);
                if (SelectedToDelete != null)
                {
                    _db.IncomeType.Remove(SelectedToDelete);
                    var deleted =await _db.SaveChangesAsync() >0? true:false;
                    if (deleted)
                    {
                          Log.Information("data is deleted from the system");
                    return new ApiResponse<string>(true, "data is deleted from the system", null!);
                        
                    }
                    else{
                        Log.Error("Data was not deleted");
                             return new ApiResponse<string>(false, "An error occured", null!);
                    }
                  
                }
                else
                {
                    Log.Information("Register Not Found");
                    return new ApiResponse<string>(false, "Register Not Found", null!);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                return new ApiResponse<string>(false, "A error ocurred", data: ex.Message);
            }



        }


        public async Task<ApiResponse<List<IncomeTypeDto>>> GetAll()
        {
            try
            {
                    var list = await _db.IncomeType.AsNoTracking().ToListAsync();
            if (list.Count > 0)
            {
                var mapped = Mapper.Map<List<IncomeTypeDto>>(list);
                return new ApiResponse<List<IncomeTypeDto>>(true, "Success", data: mapped);

            }
            return new ApiResponse<List<IncomeTypeDto>>(false, "Not found data", null!);

            }
            catch (Exception ex)
            {
                    Log.Fatal(ex.Message);
                 return new ApiResponse<List<IncomeTypeDto>>(false, ex.Message, null!);
            }
        

        }

        public async Task<ApiResponse<IncomeTypeDto>> GetbyId(int IncomeTypeId)
        {

            try
            {
                    IncomeType? found = await _db.IncomeType.FindAsync(IncomeTypeId);
            if (found != null)
            {
                var mapped = Mapper.Map<IncomeTypeDto>(found);
                Log.Information("Income type was found");
                return new ApiResponse<IncomeTypeDto>(true, "Success", data: mapped);
            }
            else
            {
                Log.Information("Income type not found");
                return new ApiResponse<IncomeTypeDto>(false, "Income type not found", null!);
            }
                
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
              return new ApiResponse<IncomeTypeDto>(true, ex.Message, null!);
            }
        
        }

        public async Task<ApiResponse<string>> Update(IncomeTypeDto income)
        {
            try
            {

                if (income != null)
                {
                    var found = await _db.IncomeType.FindAsync(income.IncometypeId);
                    if (found != null)
                    {
                        var mapped = Mapper.Map(income, found);
                       // _db.IncomeType.Update(mapped);
                        bool res = await _db.SaveChangesAsync() > 0 ? true : false;
                        if (res)
                        {
                            Log.Information("data is updated success");
                            return new ApiResponse<string>(true, "data is updated", null!);
                        }
                        else
                        {
                            Log.Error("An error ocurred while updating income type");
                            return new ApiResponse<string>(false, "An error ocurred while updating income type", null!);
                        }
                    }
                    else
                    {
                        Log.Warning("Income Type data not found");
                        return new ApiResponse<string>(false, "Income Type data not found", null!);
                    }
                }
                else
                {
                    return new ApiResponse<string>(false, "Income Type data is invalid", null!);
                }
            }
            catch (System.Exception)
            {

                return new ApiResponse<string>(false, "An error occurred while updating the Income Type", null!);
            }

        }


    }
}