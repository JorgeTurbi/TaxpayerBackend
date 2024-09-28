
using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class ProfileTaxPreparer : Profile
    {
     public ProfileTaxPreparer()
     {
          CreateMap<TaxPreparerDto , TaxPreparer>().ReverseMap();
        
     }

    }
}