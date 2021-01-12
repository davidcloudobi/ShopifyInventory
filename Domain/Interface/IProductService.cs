using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface IProductService
    {
        Task<GlobalResponse> Add(Guid businessId, ProductRequest request);
        Task<IList<Product>> GetProducts(Guid businessId);
    }
}