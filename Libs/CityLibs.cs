
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.DTOs;
using refund.Models;
using refund.Services;
using refund.Utilities;
using refund.Validators;

namespace refund.Libs
{
    public class CityLibs : ICity
    {
        private readonly DbContextPlayer _db;
        private readonly ICityValidate _cityValidate;
        private readonly IMapper _mapper;
        public CityLibs(DbContextPlayer db,ICityValidate city,IMapper mapper)
        {
            _db=db;
            _cityValidate=city;
            _mapper=mapper;
        }
        public async Task<ApiResponse<string>> Create(CityDto city)
        {
           if(city is null) return new ApiResponse<string>(false,"Invalid Object",null!);
           var validate = await _cityValidate.Exists(city);
           if (validate)
           {
             return new ApiResponse<string>(false,"Record Founded",null!);
           }

           var mapped = _mapper.Map<City>(city);
           await _db.City.AddAsync(mapped);
           string message = string.Empty;
           bool Saved = await _db.SaveChangesAsync()>0?true:false;
           if (Saved)
           {
            message ="Success";
           }
           else{
            message="An error ocurred";

           }
           return new ApiResponse<string>(Saved,message,null!);
        }

        public async Task<ApiResponse<List<CityDto>>> GetAll()
        {
               var List = await _db.City.ToListAsync();
            if (List.Count()>0)
            {
                   var MappedList = _mapper.Map<List<CityDto>>(List);
            return new ApiResponse<List<CityDto>>(true,"success",data:MappedList);
            }
            else{
                
            return new ApiResponse<List<CityDto>>(false,"Not exists Record",data:null!);
            }
        }

        public async Task<ApiResponse<List<CityDto>>> GetAllCitybyId(int StateId)
        {
            var List = await _db.City.AsNoTracking().Where(a=>a.StateId==StateId).ToListAsync();
            if (List.Count()>0)
            {
                   var MappedList = _mapper.Map<List<CityDto>>(List);
            return new ApiResponse<List<CityDto>>(true,"success",data:MappedList);
            }
            else{
                
            return new ApiResponse<List<CityDto>>(false,"Not exists Record",data:null!);
            }
        }

        public async Task<ApiResponse<CityDto>> GetbyId(int CityId)
        {
            var ObjectState = await _db.City.FindAsync(CityId);
            if (ObjectState==null)
            {
                return new ApiResponse<CityDto>(false,"Not Found",data:null!);
            }
              var Founded = _mapper.Map<CityDto>(ObjectState);
              return   new ApiResponse<CityDto>(true,"Success",data:Founded);
        }
    }
}