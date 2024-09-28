using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface IIncometype
    {
        Task<ApiResponse<string>> Create(IncomeTypeDto income);
        Task<ApiResponse<string>> Update(IncomeTypeDto income);
        Task<ApiResponse<string>> Delete(int IncomeTypeId);
        Task<ApiResponse<List<IncomeTypeDto>>> GetAll();
        Task<ApiResponse<IncomeTypeDto>> GetbyId(int IncomeTypeId);
    }
}