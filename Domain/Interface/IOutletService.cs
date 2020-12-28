using System;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface IOutletService
    {
        Task<GlobalResponse> Create(Guid businessId, OutletRequest request);
    }
}