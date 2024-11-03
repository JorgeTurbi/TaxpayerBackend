using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class ProfileLogin: Profile
    {
        public ProfileLogin()
        {
             CreateMap<LoginDtos, User>().ReverseMap();
        }
    }
}