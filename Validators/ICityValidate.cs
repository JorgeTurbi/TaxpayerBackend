using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refund.DTOs;

namespace refund.Validators
{
    public interface ICityValidate
    {
         Task<bool> Exists(CityDto city);
    }
}