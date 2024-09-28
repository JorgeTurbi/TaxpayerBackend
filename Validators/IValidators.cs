using refund.Models;
using refund.Utilities;

namespace refund.Libs
{
    public interface IValidators 
    {
         Task<ApiResponse<string>> PropertiesValidate(string name);
           Task<ApiResponse<string>> RecordExistsValidate(string name);
           
    }
}