
using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface ITaxPreparer
    {
         Task<ApiResponse<TaxPreparerDto>> Create(TaxPreparerDto preparerDto);
        Task<ApiResponse<string>> Update(TaxPreparerDto preparerDto);
        Task<ApiResponse<string>> Delete(int TaxPreparerId);
        Task<ApiResponse<List<TaxPreparerDto>>> GetAll();
        Task<ApiResponse<TaxPreparerDto>> GetbyId(int TaxPreparerId);
        Task<ApiResponse<string>> GetImagebyTaxPreparerId(int TaxPreparerId);
        Task<ApiResponse<bool>> Check(string username);
        Task<ApiResponse<TaxPreparerDto>> GetPreparer(string username);
        Task<ApiResponse<TaxPreparerDto>> GetDataPreparer(string username);
        Task<ApiResponse<string>> ValidateZipCode(string username);
     
    }
}