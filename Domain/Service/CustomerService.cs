using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Helper;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service
{
   public class CustomerService : ICustomerService
   {
       private readonly IMapper _mapper;

       public CustomerService(IMapper mapper, ApplicationDbContext dbContext)
       {
           _mapper = mapper;
           DbContext = dbContext;
       }

       public ApplicationDbContext DbContext { get; set; }
        public async Task<GlobalResponse> Add(Guid businessId, CustomerRequest request)
        {
            var business = await DbContext.Businesses.Include(x=>x.Customers).FirstOrDefaultAsync(x => x.Id == businessId);
            if (business == null)
            {
                throw new KeyNotFoundException("Business not found");
            }

            var customer = _mapper.Map<Customer>(request);
            var customerResponse = await  DbContext.Customers.Include(x=>x.Businesses).FirstOrDefaultAsync(x => x.Phone == customer.Phone);
          if (customerResponse == null)
          {
              customer.Businesses.Add(business);
                await DbContext.Customers.AddAsync(customer);
               // business.Customers.Add(customer);
                //DbContext.Update(business);
                await DbContext.SaveChangesAsync();
              return new GlobalResponse() { Message = "Successful", Status = true };

          }

          var businessCustomer = business.Customers.FirstOrDefault(x => x.Id == customerResponse.Id);


          if (businessCustomer != null)
          {
              throw new AppException("Customer already registered to the business");
          }
          business.Customers.Add(customerResponse);
          DbContext.Update(business);
          customerResponse.Businesses.Add(business);
          DbContext.Update(customerResponse);


         await DbContext.SaveChangesAsync();
         return new GlobalResponse(){Message = "Successful", Status = true};
        }
    }
}
