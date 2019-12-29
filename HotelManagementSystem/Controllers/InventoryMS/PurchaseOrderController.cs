using HotelManagementSystem.Entities.InventotyEntities;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.Inventory;
using HotelManagementSystem.ViewModel.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.InventoryMS
{
    [Authorize(Roles = "Admin,StoreKeeper")]
    public class PurchaseOrderController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly IGenericHotelService<PurchaseOrder> hotelService;

        public PurchaseOrderController(IInventoryService inventoryService, 
            IGenericHotelService<PurchaseOrder> hotelService)
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
        [Authorize(Policy = "EditPurchasePolicy")]
        [HttpGet()]
        public IActionResult Edit(string id)
        {
            ProductOrderEditViewModel purchaseOrder = inventoryService.GetEditPurchaseOrder(id);
            var product = purchaseOrder.Product;
            ViewBag.productid = new SelectList(product, "ProductId", "Name");
            return View(purchaseOrder);
        }
        [Authorize(Policy = "EditPurchasePolicy")]
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
                  //  productfrmdb.CostOfOne = model.CostOfOne;
                 //   productfrmdb.Number = model.Number;
                    productfrmdb.PurchaseOrderDate = model.PurchaseOrderDate;
                    productfrmdb.Quantity = model.Quantity;
                   // productfrmdb.PurchaseOrderId = model.id;
                    productfrmdb.ProductId = model.ProductId;
                    productfrmdb.TotalCost = (model.Quantity) * (productfrmdb.CostOfOne);
                    inventoryService.UpdatePurchaseOrder(productfrmdb);
                    inventoryService.EditProductPurchaseTracker(model.ProductId, model.Quantity, model.PurchaseOrderDate);

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
        [Authorize(Policy = "CreatePurchasePolicy")]
        [HttpGet()]
        public IActionResult Create()
        {
            IEnumerable<Product> product = inventoryService.GetAllProduct();
            ViewBag.productid = new SelectList(product, "ProductId", "Name");
            return View();
        }
        [Authorize(Policy = "CreatePurchasePolicy")]
        [HttpPost()]
        public IActionResult Create(ProductOrderCreateViewModel model)
        {

            var product = inventoryService.GetProductById(model.ProductId);



            if (model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                var productorder = new PurchaseOrder
                {
                    PurchaseOrderId = Guid.NewGuid().ToString(),
                    CostOfOne = product.CostPrice,
                    TotalCost =(product.CostPrice) * model.Quantity,
                    Number = Guid.NewGuid().ToString(),
                    Quantity = model.Quantity,
                     PurchaseOrderDate = DateTime.Now,                
                    ProductId = model.ProductId,
                };
                 inventoryService.CreatePurchaseOrder(productorder);
                inventoryService.CreateProductPurchaseTracker(model.ProductId,model.Quantity, productorder.PurchaseOrderId);
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
        [Authorize(Policy = "DeletePurchasePolicy")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var purchaseOrder = await hotelService.GetItemByIdAsync(id);
            inventoryService.DeleteProductPurchaseTracker(purchaseOrder.ProductId, id);
            //inventoryService.UpdateProductPurchaseTracker(purchaseOrder.ProductId, id);
            await hotelService.DeleteItemAsync(purchaseOrder);
            return RedirectToAction(nameof(Index));
        }
    }
}
