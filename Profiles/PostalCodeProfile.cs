
using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class PostalCodeProfile :Profile
    {
        public PostalCodeProfile()
        {
            CreateMap<PostalCodes,PostalCodeDTOs>().ReverseMap();
        }
    }
}