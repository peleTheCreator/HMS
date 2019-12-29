
using HotelBackEnd.Entities.InventotyEntities;
using HotelBackEnd.Services;
using HotelBackEnd.Services.Inventory;
using HotelBackEnd.ViewModel.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Controllers.InventoryMS
{
    public class PurchaseOrderController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly IGenericHotelService<PurchaseOrder> hotelService;

        public PurchaseOrderController(IInventoryService inventoryService, IGenericHotelService<PurchaseOrder> hotelService)
        {
            this.inventoryService = inventoryService;
            this.hotelService = hotelService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var model = inventoryService.GetAllPurchaseOrder();
            return View(model);
        }
        [HttpGet()]
        public IActionResult Details(string id)
        {
            PurchaseOrderViewModel model = inventoryService.GetPurchaseOrder(id);
            return View(model);
        }
        [HttpGet()]
        public IActionResult Edit(string id)
        {
            ProductOrderEditViewModel purchaseOrder = inventoryService.GetEditPurchaseOrder(id);
            var product = purchaseOrder.Product;
            ViewBag.productid = new SelectList(product, "ProductId", "Name");
            return View(purchaseOrder);
        }

        [HttpPost()]
        public IActionResult Edit(ProductOrderEditViewModel model)
        {
            var productfrmdb = inventoryService.GetRealPurchaseOrder(model.PurchaseOrderId);
            if (productfrmdb == null)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    // VendorId = model.VendorId,
                    productfrmdb.CostOfOne = model.CostOfOne;
                    productfrmdb.Number = model.Number;
                    productfrmdb.PurchaseOrderDate = model.PurchaseOrderDate;
                    productfrmdb.Quantity = model.Quantity;
                   // productfrmdb.PurchaseOrderId = model.id;
                    productfrmdb.TotalCost = model.TotalCost;
                    productfrmdb.ProductId = model.ProductId;

                    inventoryService.UpdatePurchaseOrder(productfrmdb);                   
                    //  await _hotelService.EditItemAsync(vendor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (inventoryService.GetRealPurchaseOrder(model.PurchaseOrderId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            IEnumerable<Product> product = inventoryService.GetAllProduct();
            ViewBag.productid = new SelectList(product, "ProductId", "Name");
            return View();
        }
        [HttpPost()]
        public IActionResult Create(ProductOrderCreateViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                var productorder = new PurchaseOrder
                {
                    PurchaseOrderId = Guid.NewGuid().ToString(),
                    CostOfOne = model.CostOfOne,
                    TotalCost = model.TotalCost,
                    Number = Guid.NewGuid().ToString(),
                    Quantity = model.Quantity,
                    PurchaseOrderDate = DateTimeOffset.Now,
                    ProductId = model.ProductId,
                };
                 inventoryService.CreatePurchaseOrder(productorder);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet()]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase =  inventoryService.GetPurchaseOrder(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roomType = await hotelService.GetItemByIdAsync(id);
            await hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }
    }
}
