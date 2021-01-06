using System;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface IProductService
    {
        Task<GlobalResponse> Add(Guid businessId, ProductRequest request);
    }
}