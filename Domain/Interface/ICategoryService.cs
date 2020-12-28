using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
    public interface ICategoryService
    {
        Task<GlobalResponse> Add(CategoryRequest request);
    }
}