using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.DTOs;
using refund.Models;
using refund.Services;

namespace refund.Libs
{   
    public class ClientLibs: IClient
    {
        public readonly IMapper Mapper;
        private readonly DbContextPlayer _db;
        public ClientLibs(DbContextPlayer db, IMapper mapper)
        {
                _db=db;
                Mapper=mapper;
        }

        public async  Task<bool> Create(CLientDto clientDto)
        {
           if (clientDto is null)
           {
            return false;
           }

           var mapped = Mapper.Map<Client>(clientDto);
           if (mapped is null)
           {
            return false;
           }

           await _db.Client.AddAsync(mapped);
           return await _db.SaveChangesAsync()>0? true: false;
        }

        public async  Task<CLientDto> GetAll()
        {
                    var list =await _db.Client.ToListAsync();
                    var mapList =Mapper.Map<CLientDto>(list);

           return mapList;
        }
    }
     

}