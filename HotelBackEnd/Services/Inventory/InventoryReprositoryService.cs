using HotelBackEnd.Entities;
using HotelBackEnd.Entities.InventotyEntities;
using HotelBackEnd.ViewModel.Inventory;
using HotelBackEnds.ViewModel.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Services.Inventory
{
    public interface IInventoryService
    {
        Task<IEnumerable<Vendor>> GetAllVendorAsync();
        IEnumerable<ProductIndexViewModel> GetAllProductIndexViewModel();
        IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder();
        PurchaseOrderViewModel GetPurchaseOrder(string id);
        PurchaseOrder GetRealPurchaseOrder(string id);
        ProductOrderEditViewModel GetEditPurchaseOrder(string id);
        IEnumerable<SalesOrderIndexViewModel> GetIndexSalesOrder();
        void UpdatePurchaseOrder(PurchaseOrder productfrmdb);
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(string productId);
        void CreatePurchaseOrder(PurchaseOrder product);
        void DeletePurchaseOrder(PurchaseOrder purchase);
        Task<ProductIndexViewModel> GetProductDetailViewModelById(string id);
    }
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext context;

        public InventoryService(AppDbContext context)
        {
            this.context = context;
        }

        public void CreatePurchaseOrder(PurchaseOrder product)
        {
            context.PurchaseOrders.Add(product);
            context.SaveChanges();
        }

        public void DeletePurchaseOrder(PurchaseOrder purchase)
        {
            context.PurchaseOrders.Remove(purchase);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return context.Products;
        }

        public IEnumerable<ProductIndexViewModel> GetAllProductIndexViewModel()
        {
            var prodx = context.Products.Include(p => p.Vendor)
                .Select(p =>
                new ProductIndexViewModel
                {
                  ProductId = p.ProductId,
                  Name =  p.Name,
                  PriceSell =  p.PriceSell,
                  CostPrice =  p.CostPrice,
                  Description = p.Description,
                  VendorName =  p.Vendor.Name
                }).ToList();
            return prodx;
        }

        public IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder()
        {
            var model = context.PurchaseOrders;
            var po =  model.Select(s=>new PurchaseOrderViewModel
                    {
                        PurchaseOrderId = s.PurchaseOrderId,
                        CostOfOne = s.CostOfOne,
                        TotalCost = s.TotalCost,
                        PurchaseOrderDate = s.PurchaseOrderDate,
                        Number = s.Number,
                        Quantity = s.Quantity,
                        Product = s.Product.Name,
                        Vendor = s.Product.Vendor.Name
                     }).ToList();

            return po;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorAsync()
        {
            return await context.Vendors.ToArrayAsync();
        }

        public ProductOrderEditViewModel GetEditPurchaseOrder(string id)
        {           
            var purchaseorder = GetPurchaseOrder(id);
            var product = context.Products.ToList();
            var producteditviewmodel = new ProductOrderEditViewModel
            {
                Product = product,
                CostOfOne = purchaseorder.CostOfOne,
                TotalCost = purchaseorder.TotalCost,
                Description = purchaseorder.Description,
                Number = purchaseorder.Number,
                PurchaseOrderDate = purchaseorder.PurchaseOrderDate,
                PurchaseOrderId = purchaseorder.PurchaseOrderId,
                Quantity = purchaseorder.Quantity,
            };
            return producteditviewmodel;
        }

        public IEnumerable<SalesOrderIndexViewModel> GetIndexSalesOrder()
        {
            var prodxs = context.Products.OrderBy(p=>p.ProductId);
            var saleO = prodxs.Select(s => new SalesOrderIndexViewModel
            {
                Price = s.PriceSell,
                ProductName = s.Name,
                ProuctId = s.ProductId,
            }).ToList();
            return saleO;
        }

        public Product GetProductById(string productId)
        {
          return  context.Products.OrderBy(p => p.ProductId)
                .Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public async Task<ProductIndexViewModel> GetProductDetailViewModelById(string id)
        {
            var product =  await context.Products.
                               Where(p => p.ProductId == id).
                               Include(p => p.Vendor).
                               FirstOrDefaultAsync();
            return new ProductIndexViewModel
            {
                ProductId = product.ProductId,
                CostPrice = product.CostPrice,
                Description =product.Description,
                Name = product.Name,
                PriceSell = product.PriceSell,
                VendorName = product.Vendor.Name,
            }; 

        }

        public PurchaseOrderViewModel GetPurchaseOrder(string id)
        {
            var model = context.PurchaseOrders;
            var po = model.Select(s => new PurchaseOrderViewModel
            {
                PurchaseOrderId = s.PurchaseOrderId,
                CostOfOne = s.CostOfOne,
                TotalCost = s.TotalCost,
                PurchaseOrderDate = s.PurchaseOrderDate,
                Number = s.Number,
                Quantity = s.Quantity,
                Product = s.Product.Name,
                Vendor = s.Product.Vendor.Name
            });
            var singlepo = po.Where(s => s.PurchaseOrderId == id).FirstOrDefault();
            return singlepo;
        }

        public PurchaseOrder GetRealPurchaseOrder(string id)

        {
            return context.PurchaseOrders.Where(p => p.PurchaseOrderId == id).FirstOrDefault();
        }

        public void UpdatePurchaseOrder(PurchaseOrder productfrmdb)
        {
            var editvendor = context.Attach(productfrmdb);
            editvendor.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

}
