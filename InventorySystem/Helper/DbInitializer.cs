using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.Model.Identity;
using Domain.Helper;
using Microsoft.AspNetCore.Identity;
using NLog.Web;

namespace InventorySystem.Helper
{
    public class DbInitializer
    {


        public static void Initialize(ApplicationDbContext context, IServiceProvider services)
        {
            // Get a logger
            // var logger = services.GetRequiredService<ILogger<DbInitializer>>();
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            // Make sure the database is created
            // We already did this in the previous step
            context.Database.EnsureCreated();

            try
            {
                if (context.BusinessTypes.Any() || context.Roles.Any() || context.PaymentTypes.Any())
                {
                    logger.Debug("The database was already seeded");
                    return;
                }
                logger.Debug("Start seeding the database.");
                var businessTypes = DbSeedingHelper.SeedBusinessTypes();
                context.BusinessTypes.AddRange(businessTypes);
                var paymentTypes = DbSeedingHelper.SeedPaymentTypes();
                context.PaymentTypes.AddRange(paymentTypes);
                DbSeedingHelper.SeedRoles(services);
                context.SaveChanges();
                logger.Debug("Finished seeding the database.");
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occurred when seeding");
            }

        }
    }
}
