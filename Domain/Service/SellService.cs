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
   public class SellService: ISellService
    {
        public SellService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, ICustomerService customerService)
        {
            DbContext = dbContext;
            UserManager = userManager;
            CustomerService = customerService;
        }

        public ApplicationDbContext DbContext { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        public ICustomerService CustomerService { get; set; }
        public async Task<GlobalResponse> Add(Guid businessId , SellRequestDTO sellRequest)
        {
            var business = await DbContext.Businesses.Include(x=>x.Products).Include(x=>x.Outlets).FirstOrDefaultAsync(x => x.Id == businessId);

            if (business == null)
            {
                throw new KeyNotFoundException("Business not found");
            }
            var outlet = business.Outlets.FirstOrDefault(x => x.Id == sellRequest.OutletId);
            if (outlet == null)
            {
                throw new KeyNotFoundException("Outlet not found");
            }
            var paymentType = await DbContext.PaymentTypes.FirstOrDefaultAsync(x => x.Name == sellRequest.PaymentType);
            if (paymentType == null)
            {
                throw new KeyNotFoundException("Payment Type not found");
            }
            
            // is this right ?
            var customer = await DbContext.Customers.FirstOrDefaultAsync(x => x.Id == sellRequest.CustomerId);
            //if (customer == null)
            //{
            //    throw new KeyNotFoundException("Customer not found");
            //}


            var newSell = new Sell()
            {
                Discount = sellRequest.Discount,
                TotalCost = sellRequest.TotalCost,
                TransactionDate = DateTime.Now,
                SellItems = sellRequest.SellItems.Any() ?  sellRequest.SellItems.Select( x=> new SellItem()
                {
                    Quantity = x.Quantity,
                    PriceSold = x.PriceSold,
                    Discount = x.Discount,
                    Product =  DbContext.Products.FirstOrDefault(y=>y.Id == x.ProductId ) ?? throw new AppException($"product with id {x.ProductId}  not found")
                }).ToList() : throw  new AppException("Sell items cannot be null"),
            };
            foreach (var sellItem in newSell.SellItems)
            {
              var product =  business.Products.FirstOrDefault(x => x.Id == sellItem.Product.Id);
              if (product is null) continue;
              product.Quantity -= sellItem.Quantity;
              var outletInventory =
                  await DbContext.Inventories.Include(x=>x.InventoryProducts).FirstOrDefaultAsync(x => x.OutletId == outlet.Id);
            var inventoryItem =  outletInventory.InventoryProducts.FirstOrDefault(x => x.ProductId == sellItem.Product.Id);
            if (inventoryItem is null) throw new AppException($"Product not found in the {outletInventory} inventory ");
            inventoryItem.Quantity -= sellItem.Quantity;
            }
            //await DbContext.Products.AddRangeAsync(newSell.SellItems.Select(x => x.Product));
            paymentType.Sells.Add(newSell);
            business.Sells.Add(newSell);
            outlet.Sells.Add(newSell);
            customer?.Sells.Add(newSell);
            await DbContext.Sells.AddAsync(newSell);
            await DbContext.SaveChangesAsync();

            return new GlobalResponse() {Message = "Successful", Status = true};

            //var user = await UserManager.FindByIdAsync(sellRequest.ApplicationUserId);
            //if (user == null)
            //{
            //    throw new KeyNotFoundException("user not found");
            //}


            //if (business == null || outlet == null || paymentType == null || customer == null || user == null)
            //{
            //    throw new KeyNotFoundException("Sell Details are invalid");
            //}
            //var sell = new Sell()
            //{
            //    Discount = sellRequest.Discount,
            //    TotalCost = sellRequest.TotalCost
            //};
            //foreach (var sellItem in sellRequest.SellItems)
            //{
            //    var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == sellItem.ProductId);
            //    if (product == null)
            //    {
            //        throw new KeyNotFoundException("Product not found");
            //    }

            //    var  item = new SellItem()
            //    {
            //        PriceSold = sellItem.PriceSold,
            //        Quantity = sellItem.Quantity
            //    };
            //    product.SellItems.Add(item);
            //    sell.SellItems.Add(item);
            //}

            //var sellItems = sellRequest.SellItems.Select(x => new SellItem()
            //{
            //    PriceSold = x.PriceSold,
            //    Quantity = x.Quantity
            //});

            //var sell = new Sell()
            //{
            //    Discount = sellRequest.Discount,
            //    TotalCost = sellRequest.TotalCost,
            //    SellItems = new List<SellItem>(sellItems),
            //};
            //user.Sells.Add(sell);
            //customer.Sells.Add(sell);
            //paymentType.Sells.Add(sell);
            //outlet.Sells.Add(sell);
            //business.Sells.Add(sell);
            //var saved = await DbContext.SaveChangesAsync();
            //if (saved > 0)
            //{
            //    return new GlobalResponse(){Message = "Successful", Status = true};
            //}
            //return new GlobalResponse(){Message = "Failed", Status =  false};
        }
    }
}
