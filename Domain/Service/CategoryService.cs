using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Interface;

namespace Domain.Service
{
   public class CategoryService:ICategoryService
    {
        public async Task<GlobalResponse> Add(CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
