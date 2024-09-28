using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refund.DTOs;
using refund.Models;
using refund.Utilities;

namespace refund.Services
{
    public interface ITaxPreparer
    {
         Task<ApiResponse<string>> Create(TaxPreparerDto preparerDto);
        Task<ApiResponse<string>> Update(TaxPreparerDto preparerDto);
        Task<ApiResponse<string>> Delete(int TaxPreparerId);
        Task<ApiResponse<List<TaxPreparerDto>>> GetAll();
        Task<ApiResponse<TaxPreparerDto>> GetbyId(int TaxPreparerId);
     
    }
}