using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interface
{
  public  interface  IBusinessService
  {
      Task<GlobalResponse> Add( BusinessRequest request);
  }
}
