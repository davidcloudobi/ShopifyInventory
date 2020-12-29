using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
   public class OutletService : IOutletService
    {
        public OutletService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationDbContext DbContext { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<ApplicationRole> RoleManager { get; set; }
        public async Task<GlobalResponse> Create(Guid businessId, OutletRequest request)
        {
            var business = await DbContext.Businesses.Include(x => x.Outlets).Include(x=>x.ApplicationUsers)
                .FirstOrDefaultAsync(x => x.Id == businessId);
            if (business == null)
            {
                throw new KeyNotFoundException("Business not found");
            }

            var outlet = business.Outlets.FirstOrDefault(x =>
                string.Equals(x.Name.ToLower(), request.Name.ToLower(), StringComparison.Ordinal));
            if (outlet != null)
            {
                throw new ApplicationException("Outlet already exist");
            }

            var newOutlet = new Outlet() {Name = request.Name, DateAdded = DateTime.Now};
            business.Outlets.Add(newOutlet);
            //await DbContext.Outlets.AddAsync(newOutlet);
          

            var applicationUsers = business.ApplicationUsers;
            if (!applicationUsers.Any())
            {
                throw new AppException("Cannot find the account owner of the business");
            }

            foreach (var applicationUser in applicationUsers)
            {
                var roles = await UserManager.GetRolesAsync(applicationUser);
                var roleCheck = roles.FirstOrDefault(x => x == "AccountOwner");
                if (!(roleCheck is null))
                {
                   applicationUser.Outlets.Add(newOutlet);
                  // newOutlet.ApplicationUsers.Add(applicationUser);
                   DbContext.Update(applicationUser);
                }
            }
            DbContext.Update(business);
            await DbContext.SaveChangesAsync();
            return new GlobalResponse(){Message = "Successful", Status = true};
        }
    }
}
