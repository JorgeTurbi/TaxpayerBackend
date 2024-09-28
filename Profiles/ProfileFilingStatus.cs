using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using refund.DTOs;
using refund.Models;

namespace refund.Profiles
{
    public class ProfileFilingStatus : Profile
    {
        public ProfileFilingStatus()
        {
            CreateMap<FilingStatusDto , FilingStatus>().ReverseMap();
        }
    }
}