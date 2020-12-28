using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Data.Model.Identity;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Helper;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service
{
   public class BusinessService : IBusinessService
    {

        public BusinessService(ApplicationDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager, IUserService userService, IOutletService outletService)
        {
            DbContext = dbContext;
            _mapper = mapper;
            UserManager = userManager;
            UserService = userService;
            OutletService = outletService;
        }

        public ApplicationDbContext DbContext { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        private readonly IMapper _mapper;
        public IUserService UserService { get; set; }
        public IOutletService OutletService { get; set; }
        public async Task<GlobalResponse> Add(BusinessRequest request)
        {
            var business = _mapper.Map<Business>(request);
          var businessType = await DbContext.BusinessTypes.FirstOrDefaultAsync(x => x.Name == request.BusinessTypeName);
          if (businessType == null)
          {
              throw new KeyNotFoundException("Failed Operation, business type is invalid");
          }
            businessType.Businesses.Add(business);
            var user = new ApplicationUser
            {
                FullName = request.ContactName,
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.Phone,

            };
            business.ApplicationUsers.Add(user);
           var userResponse = await UserService.Business_Add(user, request.Password, new List<string>(){"AccountOwner", "Administrator" });
           //business.ApplicationUsers.Add(user);
           if (userResponse.Status)
           {
               var outletResponse = await OutletService.Create(business.Id, new OutletRequest() {Name = "Main Outlet"});
               DbContext.Update(business);
               await DbContext.SaveChangesAsync();
               return userResponse;
           }
           throw new AppException("Internal Error");
           
        }
    }
}
