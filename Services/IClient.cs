using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refund.DTOs;

namespace refund.Services
{
    public interface IClient
    {
        Task<bool> Create(CLientDto clientDto);
        Task<CLientDto> GetAll();
    }
}