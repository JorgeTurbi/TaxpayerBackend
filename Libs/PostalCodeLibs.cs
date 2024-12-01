
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.DTOs;
using refund.Services;
using refund.Utilities;

namespace refund.Libs
{
    public class PostalCodeLibs : IPostalCode
    {
        public readonly IMapper _mapper;
        private readonly DbContextPlayer _db;
        private readonly ILogger<PostalCodeLibs> _logger;
        public PostalCodeLibs(DbContextPlayer db, IMapper mapper, ILogger<PostalCodeLibs> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<List<PostalCodeDTOs>>> StateList()
        {
            try
            {
                var data = await _db.PostalCodes.ToListAsync();
        
                if (data.Count() == 0)
                {
                    return new ApiResponse<List<PostalCodeDTOs>>(false, "Data not found", null!);
                }
                var dataList = data.DistinctBy(a=>a.States);
                var mapList = _mapper.Map<List<PostalCodeDTOs>>(dataList);
                return new ApiResponse<List<PostalCodeDTOs>>(true, "State List", mapList);

            }
            catch (Exception ex)
            {
#pragma warning disable CA2017 // Parameter count mismatch
                _logger.LogError("ERROR CONSULTADO ESTADOS", ex.Message);
#pragma warning restore CA2017 // Parameter count mismatch
                return new ApiResponse<List<PostalCodeDTOs>>(false, ex.Message, null!);

            }
        }

        public async Task<ApiResponse<List<PostalCodeDTOs>>> StateList_CityList(string? zipcode)
        {
           try
            {
                var data = await _db.PostalCodes.Where(a=>a.ZipCode==zipcode).ToListAsync();
        
                if (data.Count() == 0)
                {
                    return new ApiResponse<List<PostalCodeDTOs>>(false, "Data not found", null!);
                }
                var dataList = data.DistinctBy(a=>a.States);
                var mapList = _mapper.Map<List<PostalCodeDTOs>>(dataList);
                return new ApiResponse<List<PostalCodeDTOs>>(true, "cdf", mapList);

            }
            catch (Exception ex)
            {
#pragma warning disable CA2017 // Parameter count mismatch
                _logger.LogError("ERROR CONSULTADO ESTADOS", ex.Message);
#pragma warning restore CA2017 // Parameter count mismatch
                return new ApiResponse<List<PostalCodeDTOs>>(false, ex.Message, null!);

            }
        }

        public async Task<ApiResponse<List<PostalCodeDTOs>>> ZipCodeList(string? state, string? city)
        {
           try
            {
                var data = await _db.PostalCodes.Where(a=>a.States==state && a.PrimaryCity==city).ToListAsync();
        
                if (data.Count() == 0)
                {
                    return new ApiResponse<List<PostalCodeDTOs>>(false, "Data not found", null!);
                }
                var dataList = data.DistinctBy(a=>a.States);
                var mapList = _mapper.Map<List<PostalCodeDTOs>>(dataList);
                return new ApiResponse<List<PostalCodeDTOs>>(true, "cdf", mapList);

            }
            catch (Exception ex)
            {
#pragma warning disable CA2017 // Parameter count mismatch
                _logger.LogError("ERROR CONSULTADO ESTADOS", ex.Message);
#pragma warning restore CA2017 // Parameter count mismatch
                return new ApiResponse<List<PostalCodeDTOs>>(false, ex.Message, null!);

            }
        }

        public async Task<ApiResponse<List<PostalCodeDTOs>>> CityList(string? state)
        {
                 try
            {
                var data = await _db.PostalCodes.Where(a=>a.States==state).ToListAsync();
        
                if (data.Count() == 0)
                {
                    return new ApiResponse<List<PostalCodeDTOs>>(false, "Data not found", null!);
                }
                var dataList = data;
                var mapList = _mapper.Map<List<PostalCodeDTOs>>(dataList);
                return new ApiResponse<List<PostalCodeDTOs>>(true, "cdf", mapList);

            }
            catch (Exception ex)
            {
#pragma warning disable CA2017 // Parameter count mismatch
                _logger.LogError("ERROR CONSULTADO ESTADOS", ex.Message);
#pragma warning restore CA2017 // Parameter count mismatch
                return new ApiResponse<List<PostalCodeDTOs>>(false, ex.Message, null!);

            }
        }

    }
}