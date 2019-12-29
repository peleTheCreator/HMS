using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.InventotyEntities;
using HotelManagementSystem.Services.Inventory;
using HotelManagementSystem.ViewModel.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.InventoryMS
{
    [Authorize(Roles = "Admin,StoreKeeper")]
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
            ViewBag.Error = new List<string>();
            return View(prodx);
        }

        [HttpPost]
        public IActionResult Index(List<string> ProductId, List<SalesOrderIndexViewModel> soModel)
        {
            var model = inventoryService.GetIndexSalesOrder();
            if (!ModelState.IsValid)
            {
                ViewBag.Error = new List<string>();
                return View(model);
            }
            List<int> Sales = soModel.Select(s => s.Sales).ToList();
            //update the tracker
            SalesAndErrorViewModel errorandsales = inventoryService.CreateProductSalesOrderTracker(ProductId, Sales);
            if (errorandsales.Errors.Count() == 0)
            {
                int total = 0;
                //find the total of the sales list
                foreach (var sales in Sales)
                {
                    total = sales + total;
                }
                var SalesOrderObject = new List<SalesOrder>();

                for (int i = 0; i < ProductId.Count(); i++)
                {
                    var prodx = inventoryService.GetProductById(ProductId[i]);
                    if (prodx == null)
                    {
                        BadRequest();
                    }
                    var saleorderid = Guid.NewGuid().ToString();
                    var saleord = new SalesOrder
                    {
                        Price = prodx.PriceSell,
                        Sale = errorandsales.Sales[i],
                        SalesOrderId = saleorderid,
                        TotalSales = total,
                        ProductId = ProductId[i],
                        SalesDate = DateTime.Now.Date,
                    };
                    SalesOrderObject.Add(saleord);
                }
                context.SalesOrders.AddRange(SalesOrderObject);
                context.SaveChanges();
                return RedirectToAction("Index", "Inventory");
            }
            else
            {
                ViewBag.Error = errorandsales.Errors;
                return View(model);
            }
        }
    }
}
