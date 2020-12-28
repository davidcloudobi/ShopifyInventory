using System;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface ICustomerService
    {
        Task<GlobalResponse> Add(Guid businessId, CustomerRequest request);
    }
}