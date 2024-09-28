using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface IFilingStatus
    {
             Task<ApiResponse<string>> Create(FilingStatusDto filingStatus);
        Task<ApiResponse<string>> Update(FilingStatusDto filingStatus);
        Task<ApiResponse<string>> Delete(int filingStatusId);
        Task<ApiResponse<List<FilingStatusDto>>> GetAll();
        Task<ApiResponse<FilingStatusDto>> GetbyId(int filingStatusId);
    
    }
    }
