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
    public class FilingStatusLibs : IFilingStatus
    {
        public readonly IMapper Mapper;
        private readonly DbContextPlayer _db;

   
        public FilingStatusLibs(DbContextPlayer db, IMapper mapper)
        {
            _db=db;
            Mapper=mapper;
        }
       public async Task<ApiResponse<string>> Create(FilingStatusDto filingStatus)
        {
             try
            {

                if (!string.IsNullOrEmpty(filingStatus.Name))
                {
                    var mapped = Mapper.Map<FilingStatus>(filingStatus);
                    await _db.FilingStatus.AddAsync(mapped);
                    bool saved = await _db.SaveChangesAsync() > 0 ? true : false;
                    if (saved)
                    {
                        Log.Information("Filing Status created successfully =>{@result}", saved);
                        return new ApiResponse<string>(true, "Filing status created successfully", null!);

                    }
                    else
                    {
                        Log.Error("An error occurred while creating the Filing status");
                        return new ApiResponse<string>(false, "An error occurred while  the creating Filing status", null!);
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

       public async Task<ApiResponse<string>> Delete(int filingStatusId)
        {
               try
            {
                var SelectedToDelete = await _db.FilingStatus.FindAsync(filingStatusId);
                if (SelectedToDelete != null)
                {
                    _db.FilingStatus.Remove(SelectedToDelete);
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

        public async Task<ApiResponse<List<FilingStatusDto>>> GetAll()
        {
           try
            {
                    var list = await _db.FilingStatus.AsNoTracking().ToListAsync();
            if (list.Count > 0)
            {
                var mapped = Mapper.Map<List<FilingStatusDto>>(list);
                return new ApiResponse<List<FilingStatusDto>>(true, "Success", data: mapped);

            }
            return new ApiResponse<List<FilingStatusDto>>(false, "Not found data", null!);

            }
            catch (Exception ex)
            {
                    Log.Fatal(ex.Message);
                 return new ApiResponse<List<FilingStatusDto>>(false, ex.Message, null!);
            }
        
        }

       public async Task<ApiResponse<FilingStatusDto>> GetbyId(int filingStatusId)
        {
            try
            {
                    FilingStatus? found = await _db.FilingStatus.FindAsync(filingStatusId);
            if (found != null)
            {
                var mapped = Mapper.Map<FilingStatusDto>(found);
                Log.Information("Register was found");
                return new ApiResponse<FilingStatusDto>(true, "Success", data: mapped);
            }
            else
            {
                Log.Information("Data not found");
                return new ApiResponse<FilingStatusDto>(false, "Data not found", null!);
            }
                
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
              return new ApiResponse<FilingStatusDto>(true, ex.Message, null!);
            }
        
        }

       public async Task<ApiResponse<string>> Update(FilingStatusDto filingStatus)
        {
             try
            {

                if (filingStatus != null)
                {
                    var found = await _db.FilingStatus.FindAsync(filingStatus.IdFilingStatus);
                    if (found != null)
                    {
                        var mapped = Mapper.Map(filingStatus, found);
                       
                        bool res = await _db.SaveChangesAsync() > 0 ? true : false;
                        if (res)
                        {
                            Log.Information("data is updated success");
                            return new ApiResponse<string>(true, "data is updated", null!);
                        }
                        else
                        {
                            Log.Error("An error ocurred while updating data");
                            return new ApiResponse<string>(false, "An error ocurred while updating data", null!);
                        }
                    }
                    else
                    {
                        Log.Warning(" data not found");
                        return new ApiResponse<string>(false, "data not found", null!);
                    }
                }
                else
                {
                    return new ApiResponse<string>(false, "data is invalid", null!);
                }
            }
            catch (System.Exception)
            {

                return new ApiResponse<string>(false, "An error occurred while updating the data", null!);
            }
        }
    }
}