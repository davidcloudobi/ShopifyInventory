using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Helper
{
   public class DbSeedingHelper
   {
       private static readonly List<string> _businessTypEnumerable = new List<string>()
       {
           "Adult",
           "Beauty & Cosmetics",
           "Bike",
           "Café & Food Truck",
           "CBD & Vape",
           "Electronics",
           "Fashion & Clothing",
           "Florist",
           "Footwear",
           "Furniture",
           "Gift Store",
           "Groceries & Food Retail",
           "Hair & Beauty Salon",
           "Health",
           "Homeware",
           "Jewellery",
           "Liquor Stores & Bottle Shop",
           "Pet",
           "Restaurant",
           "Second Hand Shop & Op Shop", 
           "Services",
           "Sporting & Outdoor",
           "Sports Team",
           "Stadium & Events",
           "Tools & Hardware",
           "Tourism",
           "Toys, Hobbies & Crafts",
           "Other Retail",
           "Other Non-retail",



       };
        public static IEnumerable<BusinessType> SeedBusinessTypes()
        {
            var businessTypes = _businessTypEnumerable.Select(x => new BusinessType()
            {
                Name = x
            });

            return businessTypes;

        }

        public static IEnumerable<PaymentType> SeedPaymentTypes()
        {
            var paymentTypes = new List<PaymentType>()
            {
                new PaymentType()
                {
                    Name = "Cash",
                },
                new PaymentType()
                {
                    Name = "LayBy",
                },
                new PaymentType()
                {
                    Name = "StoreCredit",
                },
                new PaymentType()
                {
                    Name = "OnAccount",
                },
            };
            return paymentTypes;


        }

        public  static void SeedRoles(IServiceProvider serviceProvider)
        {
            
           var roles  = new List<ApplicationRole>()
           {
               new ApplicationRole()
               {
                   Name = "AccountOwner", NormalizedName = "AccountOwner".ToUpper().Normalize()
               },
               new ApplicationRole()
               {
                   Name =  "Administrator", NormalizedName = "Administrator".ToUpper().Normalize()
               },
               new ApplicationRole()
               {
                   Name = "Manager", NormalizedName = "Manager".ToUpper().Normalize()
               },
               new ApplicationRole()
               {
                   Name = "Cashier", NormalizedName = "Cashier".ToUpper().Normalize()
               }
           };

           var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var roleStore = new RoleStore<ApplicationRole>(context);

            if (context.Roles.Any()) return;
            foreach (var role in roles)
           {
               var res = roleStore.CreateAsync(role).Result;
           }

        }
    }
}
