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
        public class StateLibs : IState
    {

         private readonly DbContextPlayer _db;
        private readonly IStateValidators _stateValidators;
        private readonly ICityValidate _cityValidators;
        private readonly IMapper _mapper;
            public StateLibs(DbContextPlayer db, IStateValidators stateValidators, ICityValidate cityValidators,IMapper mapper)
            {
                _db=db;
                _stateValidators=stateValidators;
                _cityValidators=cityValidators;
                _mapper=mapper;

            }


            //methods and funtions

        public async Task<ApiResponse<string>> Create(StateDto state)
        {
            string message=string.Empty;
            if (state is null)
            {
                return new ApiResponse<string>(false,"Invalid object",null!);
            }
                    bool response =await _stateValidators.StateExists(state);
            if (response)
            {
               message="Record exists";
               return new ApiResponse<string>(response,message,null!);
            }

                var mappedRecord = _mapper.Map<State>(state);
                await _db.State.AddAsync(mappedRecord);
                response = await _db.SaveChangesAsync()>0?true:false;
                message =response==true?"Record saved success":"An error ocurred";
            
             return new ApiResponse<string>(response,message,null!);

        }

        public async Task<ApiResponse<List<StateDto>>> GetAll()
        {
            var List = await _db.State.ToListAsync();
            if (List.Count()>0)
            {
                   var MappedList = _mapper.Map<List<StateDto>>(List);
            return new ApiResponse<List<StateDto>>(true,"success",data:MappedList);
            }
            else{
                
            return new ApiResponse<List<StateDto>>(false,"Not exists Record",data:null!);
            }
            
        }

        public async Task<ApiResponse<StateDto>> GetbyId(int StateId)
        {
            var ObjectState = await _db.State.FindAsync(StateId);
            if (ObjectState==null)
            {
                return new ApiResponse<StateDto>(false,"Not Found",data:null!);
            }
              var Founded = _mapper.Map<StateDto>(ObjectState);
              return   new ApiResponse<StateDto>(true,"Success",data:Founded);

        }
    }
}