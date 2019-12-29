using HotelBackEnd.Entities;
using HotelBackEnd.Entities.InventotyEntities;
using HotelBackEnd.Services.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Controllers.InventoryMS
{
    public class SalesOrderController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly AppDbContext context;

        public SalesOrderController(IInventoryService inventoryService, AppDbContext context)
        {
            this.inventoryService = inventoryService;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prodx = inventoryService.GetIndexSalesOrder();
            
            return View(prodx);
        }

        [HttpPost]
        public IActionResult CreateSalesOrder(List<string> ProductId,
            List<string> Sales )
        {
            var SalesOrderObject = new List<SalesOrder>();

            for (int i = 0; i < ProductId.Count(); i++)
            {
              var prodx =   inventoryService.GetProductById(ProductId[i]);
               if (prodx == null)
                {
                    BadRequest();
                }
                var saleorderid = Guid.NewGuid().ToString();
                var saleord = new SalesOrder
                {
                    Price = prodx.PriceSell,
                    Sale = Sales[i],
                    SalesOrderId = saleorderid,
                    TotalSales = "40",
                    ProductId = ProductId[0],
                    SalesDate = DateTime.Now
                };
                SalesOrderObject.Add(saleord);
            }
            context.SalesOrders.AddRange(SalesOrderObject);
            context.SaveChanges();
            return RedirectToAction("Index", "Inventory");
        }
    }
}
