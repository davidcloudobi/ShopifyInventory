using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public  interface ISellService
    {
        Task<GlobalResponse> Add(SellRequestDTO sellRequest);
    }
}
