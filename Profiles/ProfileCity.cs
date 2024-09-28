using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class ProfileCity :Profile
    {
        public ProfileCity()
        {
            CreateMap<CityDto,City>().ReverseMap();
        }
    }
}