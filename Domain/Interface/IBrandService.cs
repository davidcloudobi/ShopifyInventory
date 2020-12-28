using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface IBrandService
    {
        Task<GlobalResponse> Add(BrandRequest request);
    }
}