using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface ICity
    {
        Task<ApiResponse<string>> Create(CityDto city);
        Task<ApiResponse<List<CityDto>>> GetAll();
        Task<ApiResponse<CityDto>> GetbyId(int CityId);
        Task<ApiResponse<List<CityDto>>> GetAllCitybyId(int StateId);

    }
}