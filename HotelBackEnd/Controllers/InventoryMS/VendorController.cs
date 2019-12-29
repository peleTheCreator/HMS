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
    public class VendorController : Controller
    {

        private readonly IGenericHotelService<Vendor> _hotelService;
        private readonly IInventoryService inventoryService;
        private readonly AppDbContext context;

        public VendorController(IGenericHotelService<Vendor> genericHotelService,
            IInventoryService inventoryService, AppDbContext context)
        {
            _hotelService = genericHotelService;
            this.inventoryService = inventoryService;
            this.context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet()]
        public async Task<IActionResult> Details(string id)
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
            return View(product);
        }
        [HttpGet()]
        public IActionResult Create()
        {          
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Vendor = new Vendor
                {
                    VendorId = Guid.NewGuid().ToString(),
                    Email = model.Email,
                    Address = model.Address,
                    Address2 = model.Address2,
                    Description = model.Description,
                    Name = model.Name,
                    Phone = model.Phone,
                };
                await _hotelService.CreateItemAsync(Vendor);
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

            var vendor = await _hotelService.GetItemByIdAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(new VendorViewModel
            {
                VendorId = vendor.VendorId,
                Email = vendor.Email,
                Address = vendor.Address,
                Address2 = vendor.Address2,
                Description = vendor.Description,
                Name = vendor.Name,
                Phone = vendor.Phone,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VendorViewModel model)
        {
            var vendorfrmdb = await _hotelService.GetItemByIdAsync(model.VendorId);
            if (vendorfrmdb == null)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // VendorId = model.VendorId,
                    vendorfrmdb.Email = model.Email;
                    vendorfrmdb.Address = model.Address;
                    vendorfrmdb.Address2 = model.Address2;
                    vendorfrmdb.Description = model.Description;
                    vendorfrmdb.Name = model.Name;
                    vendorfrmdb.Phone = model.Phone;
                    var editvendor = context.Vendors.Attach(vendorfrmdb);
                    editvendor.State = EntityState.Modified;
                    context.SaveChanges();
                 //  await _hotelService.EditItemAsync(vendor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(model.VendorId) == null)
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
            var vendor = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(vendor);
            return RedirectToAction(nameof(Index));
        }
    } 
}
