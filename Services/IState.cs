using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface IState
    {
         Task<ApiResponse<string>> Create(StateDto state);
        Task<ApiResponse<List<StateDto>>> GetAll();
         Task<ApiResponse<StateDto>> GetbyId(int StateId);
    }
}