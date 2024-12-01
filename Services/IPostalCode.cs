using refund.DTOs;
using refund.Utilities;

namespace refund.Services
{
    public interface IPostalCode
    {
        Task<ApiResponse<List<PostalCodeDTOs>>> StateList(); // return back State list Task<ApiResponse<List<PostalCodeDTOs>>> CityList_ZipCodeList(string state); // return back city list
        Task<ApiResponse<List<PostalCodeDTOs>>> ZipCodeList(string? state, string? city); // return back zip code list
        //Task<ApiResponse<List<PostalCodeDTOs>>> ZipCodeList_StateList(string? city); // return back zip code list and state list
         Task<ApiResponse<List<PostalCodeDTOs>>> StateList_CityList(string? zipcode); // return back zip code list
          Task<ApiResponse<List<PostalCodeDTOs>>> CityList(string? state);
    }
}