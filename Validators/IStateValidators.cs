
using refund.DTOs;

namespace refund.Validators
{
    public interface  IStateValidators
    {
        
        Task<bool> StateExists(StateDto state);
    }
}