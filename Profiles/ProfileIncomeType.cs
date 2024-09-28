using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class ProfileIncomeType : Profile
    {
        
        public ProfileIncomeType()
        {
            CreateMap<IncomeTypeDto , IncomeType>().ReverseMap();
        }
    }
}