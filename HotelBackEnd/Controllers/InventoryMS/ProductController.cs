using HotelBackEnd.Entities;
using HotelBackEnd.Entities.InventotyEntities;
using HotelBackEnd.Services;
using HotelBackEnd.Services.Inventory;
using HotelBackEnd.ViewModel.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Controllers.InventoryMS
{
    [Authorize(Roles = "Admin,StoreKeeper")]
    public class ProductController : Controller
    {

        private readonly IGenericHotelService<Product> _hotelService;
        private readonly IInventoryService inventoryService;
        private readonly AppDbContext context;

        public ProductController(IGenericHotelService<Product> genericHotelService, 
            IInventoryService inventoryService, AppDbContext context)
        {
            _hotelService = genericHotelService;
            this.inventoryService = inventoryService;
            this.context = context;
        }

        [HttpGet()]
        public IActionResult  Index()
        {
           var model = inventoryService.GetAllProductIndexViewModel();
            return View(model);
        }

        [HttpGet()]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductIndexViewModel product = await inventoryService.GetProductDetailViewModelById(id);


            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            var vendor = inventoryService.GetAllVendorAsync().Result;
            ViewBag.id = new SelectList(vendor, "VendorId", "Name");
            return View();
        }     


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    CostPrice = model.CostPrice,
                    Description=model.Description,
                    Name=model.Name,
                    PriceSell=model.PriceSell,    
                    VendorId = model.VendorId,
                };  
                await _hotelService.CreateItemAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _hotelService.GetItemByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var vendor = inventoryService.GetAllVendorAsync().Result;
            ViewBag.id = new SelectList(vendor, "VendorId", "Name");

            return View(new ProductViewModel
            {               
                CostPrice = product.CostPrice,
                Description =  product.Description,
                Name = product.Name,
                PriceSell=product.PriceSell, 
                ProductId = product.ProductId,
                VendorId = product.VendorId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( ProductViewModel model)
        {
            var productfrmdb = await _hotelService.GetItemByIdAsync(model.ProductId);
            if (productfrmdb == null)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // VendorId = model.VendorId,
                    productfrmdb.Name = model.Name;
                    productfrmdb.PriceSell = model.PriceSell;
                    productfrmdb.CostPrice = model.CostPrice;
                    productfrmdb.Description = model.Description;
                    productfrmdb.Name = model.Name;
                    productfrmdb.ProductId = model.ProductId;
                    productfrmdb.VendorId = model.VendorId;

                    var editvendor = context.Products.Attach(productfrmdb);
                    editvendor.State = EntityState.Modified;
                    context.SaveChanges();
                    //  await _hotelService.EditItemAsync(vendor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(model.ProductId) == null)
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
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roomType = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }
    }
}
 