using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.InventotyEntities;
using HotelManagementSystem.ViewModel.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services.Inventory
{
    public interface IInventoryService
    {
        Task<IEnumerable<Vendor>> GetAllVendorAsync();
        IEnumerable<ProductIndexViewModel> GetAllProductIndexViewModel();
        IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder();
        PurchaseOrderViewModel GetPurchaseOrder(string id);
        PurchaseOrder GetRealPurchaseOrder(string id);
        ProductOrderEditViewModel GetEditPurchaseOrder(string id);
        Task<InventoryWhiteBoardViewModel> CreateWhiteBoard();
        IEnumerable<SalesOrderIndexViewModel> GetIndexSalesOrder();
        void UpdatePurchaseOrder(PurchaseOrder productfrmdb);
        Task<IEnumerable<WhiteBoardTable>> CreateWhiteBoardReport();
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(string productId);
        void CreatePurchaseOrder(PurchaseOrder product);
        void DeletePurchaseOrder(PurchaseOrder purchase);
        Task<ProductIndexViewModel> GetProductDetailViewModelById(string id);
        Task<OverallSaleReportViewModel> CreateSaleReport(DateTime salesReportReportFrom, DateTime salesReportReportTo);
        void CreateProductPurchaseTracker(string productId, int quantity, string purchaseOrderId);
        SalesAndErrorViewModel CreateProductSalesOrderTracker(List<string> productId, List<int> sales);
        void EditProductPurchaseTracker(string productId, int quantity, DateTime purchaseOrderDate);
        void UpdateProductPurchaseTracker(string productId, string purchaseOrderId);
        void DeleteProductPurchaseTracker(string productId, string purchaseOrderId);

    }
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext context;

        public InventoryService(AppDbContext context)
        {
            this.context = context;
        }

        public SalesAndErrorViewModel CreateProductSalesOrderTracker(List<string> productId, List<int> sales)
        {
            List<string> errors = new List<string>();

           //// invent unentered values
           // for (int i = 0; i < productId.Count(); i++)
           // {
           //     try
           //     {
           //         if (sales[i] < 0)
           //         {
           //             string error = $"products can  not take a negative quantity as a value";
           //             errors.Add(error);
           //         }                
           //     }
           //     catch (ArgumentOutOfRangeException)
           //     {
           //         sales.Insert(i, 0);
           //     }
           // }
           // validate errors
            for (int i = 0; i < productId.Count(); i++)
            {
                var checkTrackerForProduct = context
                .ProductPurchaseOrderTracking
                .Where(t => t.ProductId == productId[i])
               .LastOrDefault();
                var productname = context.Products
                                  .Where(p => p.ProductId == productId[i]).
                                  Select(p => p.Name).
                                  FirstOrDefault();
                var pdx = productname;
                if (checkTrackerForProduct != null)
                {
                    if (checkTrackerForProduct.RemainingProductQty < sales[i])
                    {
                        string error = $"{pdx} remains  {checkTrackerForProduct.RemainingProductQty} quantity";
                        errors.Add(error);
                    }
                    else if (sales[i] < 0)
                    {
                        string error = $"{pdx} can not have a negative quantity as a value";
                        errors.Add(error);
                    }
                }
                else
                {
                    if (sales[i] < 0)
                    {
                        string error = $"{pdx} can not have a negative quantity as a value";
                        errors.Add(error);
                    }
                    else if (sales[i] > 0)
                    {
                        string error = $"{pdx} remains  {0} quantity";
                        errors.Add(error);
                    }
                }
            }

            //only save when error is equal zero
            if (errors.Count() == 0)
            {
                for (int i = 0; i < productId.Count(); i++)
                {
                    var checkTrackerForProduct = context
                    .ProductPurchaseOrderTracking
                    .Where(t => t.ProductId == productId[i])
                   .LastOrDefault();

                    if (checkTrackerForProduct != null)
                    {
                        checkTrackerForProduct.RemainingProductQty = checkTrackerForProduct.RemainingProductQty - sales[i];
                        context.SaveChanges();
                    }
                }
            }
          
            return new SalesAndErrorViewModel
            {
                Errors = errors,
                Sales = sales,
            }; 
        }
        public void CreateProductPurchaseTracker(string productId, int quantity, string purchaseOrderId)

        {
            //check if product already exist then just add the quantity and remaining else create it
            var checkTrackerForProduct = context.
                ProductPurchaseOrderTracking.
                Where(t => t.ProductId == productId)
               .LastOrDefault();
            if (checkTrackerForProduct == null)
            {
                var model = new ProductPurchaseOrderTracking
                {
                    ProductPurchaseOrderTrackerId = 0,
                    ProductId = productId,
                    TotalPoductQty = quantity,
                    RemainingProductQty = quantity,
                    DateTime = DateTime.Now.Date,
                    PurchaseOrderId = purchaseOrderId,
                };
                context.ProductPurchaseOrderTracking.Add(model);
                context.SaveChanges();
            }
            else
            {
                var model = new ProductPurchaseOrderTracking
                {
                    ProductPurchaseOrderTrackerId = 0,
                    ProductId = productId,
                    DateTime = DateTime.Now.Date,
                    PurchaseOrderId = purchaseOrderId,
                };
                // if it not null then update it
                model.TotalPoductQty = checkTrackerForProduct.TotalPoductQty + quantity;
                model.RemainingProductQty = checkTrackerForProduct.RemainingProductQty + quantity;
                context.ProductPurchaseOrderTracking.Add(model);
                context.SaveChanges();
            }

        }
        public void UpdateProductPurchaseTracker(string productId, string purchaseOrderId)
        {
            var DeletecheckTrackerForProduct = context.
                PurchaseOrders.
                Where(t => t.ProductId == productId)
               .First();

            var checkTrackerForProduct = context.
              ProductPurchaseOrderTracking.
              Where(t => t.ProductId == productId)
             .LastOrDefault();
            if(checkTrackerForProduct == null)
            {
                return;
            }

            checkTrackerForProduct.TotalPoductQty = checkTrackerForProduct.TotalPoductQty - DeletecheckTrackerForProduct.Quantity;
            checkTrackerForProduct.RemainingProductQty = checkTrackerForProduct.RemainingProductQty - DeletecheckTrackerForProduct.Quantity;
            context.SaveChanges();            
        }
        public void DeleteProductPurchaseTracker(string productId, string purchaseOrderId)
        {
            var checkTrackerForProduct = context.
            ProductPurchaseOrderTracking.
            Where(t => t.ProductId == productId && t.PurchaseOrderId == purchaseOrderId)
            .Single();
            context.ProductPurchaseOrderTracking.Remove(checkTrackerForProduct);
            context.SaveChanges();
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
                    Name = p.Name,
                    PriceSell = p.PriceSell,
                    CostPrice = p.CostPrice,
                    Description = p.Description,
                    VendorName = p.Vendor.Name
                }).ToList();
            return prodx;
        }

        public IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder()
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
            var prodxs = context.Products.OrderBy(p => p.ProductId);
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
            return context.Products.OrderBy(p => p.ProductId)
                  .Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public async Task<ProductIndexViewModel> GetProductDetailViewModelById(string id)
        {
            var product = await context.Products.
                               Where(p => p.ProductId == id).
                               Include(p => p.Vendor).
                               FirstOrDefaultAsync();
            return new ProductIndexViewModel
            {
                ProductId = product.ProductId,
                CostPrice = product.CostPrice,
                Description = product.Description,
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

        public async Task<InventoryWhiteBoardViewModel> CreateWhiteBoard()
        {
            //now
            var dateNow = DateTime.Now;
            var ThedateEndDaynow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 23, 59, 59);

            //week
            var week = DateTime.Now.AddDays(-7);
            var dateweekEnd = new DateTime(week.Year, week.Month, week.Day, 23, 59, 59);
            //month
            var Year = DateTime.Now.Year;
            var Month = DateTime.Now.Month;
            var daysmonth = DateTime.DaysInMonth(Year, Month);
            // var month = DateTime.Now.AddDays(-daysmonth).ToString("dd:MM:yyy");
            var month = DateTime.Now.AddDays(-daysmonth).Date;
            var datemonthEnd = new DateTime(week.Year, week.Month, week.Day, 23, 59, 59);


            //========================purchase order=======================================
            var purchaseOrderTodayQuery = await context.
                PurchaseOrders.Where(p => p.PurchaseOrderDate >= dateNow.Date && p.PurchaseOrderDate <= ThedateEndDaynow).
                Select(p=>new{ p.Quantity,p.TotalCost}).
                ToListAsync();
            //purchase order  total quantity for the day
            int purchaseOrderToday = 0;
            foreach (var pt in purchaseOrderTodayQuery.Select(p=>p.Quantity).ToList())
            {
                purchaseOrderToday = pt + purchaseOrderToday;
            }
            //purchase order today total cost for the day
            decimal purchaseOrderTodayCost = 0;
            foreach (var ptcost in purchaseOrderTodayQuery.Select(p => p.TotalCost).ToList())
            {
                purchaseOrderTodayCost = ptcost + purchaseOrderTodayCost;
            }
            //===============================================================
            var PurchaseOrderThisWeekQuery = await context.
              PurchaseOrders.Where(p => p.PurchaseOrderDate >= week.Date && p.PurchaseOrderDate <= ThedateEndDaynow).
              Select(p => new { p.Quantity, p.TotalCost }).
              ToListAsync();
            int PurchaseOrderThisWeek = 0;
            foreach (var pt in PurchaseOrderThisWeekQuery.Select(p => p.Quantity).ToList())
            {
                PurchaseOrderThisWeek = pt + PurchaseOrderThisWeek;
            }
            decimal purchaseOrderThisWeekCost = 0;
            foreach (var ptcost in PurchaseOrderThisWeekQuery.Select(p => p.TotalCost).ToList())
            {
                purchaseOrderThisWeekCost = ptcost + purchaseOrderThisWeekCost;
            }
            //==========================================================================


            var PurchaseOrderThisMonthQuery = await context.
              PurchaseOrders.Where(p => p.PurchaseOrderDate >= month.Date && p.PurchaseOrderDate <= ThedateEndDaynow).
              Select(p => new { p.Quantity, p.TotalCost }).
              ToListAsync();
            int PurchaseOrderThisMonth = 0;
            foreach (var pt in PurchaseOrderThisMonthQuery)
            {
                PurchaseOrderThisMonth = pt.Quantity + PurchaseOrderThisMonth;
            }
            decimal purchaseOrderThisMonthCost = 0;
            foreach (var ptcost in PurchaseOrderThisWeekQuery)
            {
                purchaseOrderThisMonthCost = ptcost.TotalCost + purchaseOrderThisMonthCost;
            }
            //========================sale order==================================================
            var SalesQuery = await context.SalesOrders
                .Where(p => p.SalesDate >= dateNow.Date && p.SalesDate <= ThedateEndDaynow).
                Select(s => new { s.Price, s.Sale, }).ToListAsync();
            decimal salespriceToday = 0;
            int salesquantityToday = 0;
            foreach (var st in SalesQuery)
            {
                salespriceToday = (st.Price * st.Sale) + salespriceToday;
                salesquantityToday = st.Sale + salesquantityToday;
            }

            //==================================================================================================
            var SalesQueryThisWeek = await context.SalesOrders
               .Where(p => p.SalesDate >= week.Date && p.SalesDate <= ThedateEndDaynow).
               Select(s => new { s.Price, s.Sale }).ToListAsync();
            decimal salespriceThisWeek = 0;
            int salesquantityThisWeeek = 0;
            foreach (var st in SalesQueryThisWeek)
            {
                salespriceThisWeek = (st.Price * st.Sale) + salespriceThisWeek;
                salesquantityThisWeeek = st.Sale + salesquantityThisWeeek;
            }
            //==========================================================================================================
            var SalesQueryThisMonth = await context.SalesOrders
                .Where(p => p.SalesDate >= month.Date && p.SalesDate <= ThedateEndDaynow).
                Select(s => new { s.Price, s.Sale }).ToListAsync();
            decimal salespriceThisMonth = 0;
            int salesquantityThisMonth = 0;
            foreach (var st in SalesQueryThisWeek)
            {
                salespriceThisMonth = (st.Price * st.Sale) + salespriceThisMonth;
                salesquantityThisMonth = st.Sale + salesquantityThisMonth;
            }

            //===============================TotalEarning==============================================================================

            var costquery = context.
                Products.
                Select(p => new { p.CostPrice, p.ProductId,p.PriceSell }).ToList();
            List<decimal> costPriceListToday = new List<decimal>();
            for (int i = 0; i < costquery.Count(); i++)
            {
                var SellingQuery = await context.SalesOrders.Where(p=>p.ProductId == costquery.Select(q=>q.ProductId).ToList()[i])
                 .Where(p => p.SalesDate >= dateNow.Date && p.SalesDate <= ThedateEndDaynow).
                  Select(s => new { s.Price, s.Sale }).ToListAsync();
                decimal costpricesellsperPrdoxForToday = 0;
                for (int j = 0; j < SellingQuery.Count(); j++)
                {
                     costpricesellsperPrdoxForToday = (costquery.Select(c=>c.CostPrice).ToList()[i]
                                                         * SellingQuery.Select(p => p.Sale).ToList()[j]) + costpricesellsperPrdoxForToday;
                }
                costPriceListToday.Add(costpricesellsperPrdoxForToday);
            }

            decimal TotalcostForToday = 0;
            foreach(var cp in costPriceListToday)
            {
                TotalcostForToday = cp + TotalcostForToday;
            }     
            var totalearningtoday =  salespriceToday - TotalcostForToday;
            //===========================================================================================================================
            List<decimal> costPriceListThisWeek = new List<decimal>();
            for (int i = 0; i < costquery.Count(); i++)
            {
                var SellingQuery = await context.SalesOrders.Where(p => p.ProductId == costquery.Select(q => q.ProductId).ToList()[i])
                  .Where(p => p.SalesDate >= week.Date && p.SalesDate <= ThedateEndDaynow).
                   Select(s => new { s.Price, s.Sale }).ToListAsync();
                decimal costpricesellsperPrdoxForThisWeek = 0;
                for (int j = 0; j < SellingQuery.Count(); j++)
                {
                    costpricesellsperPrdoxForThisWeek = (costquery.Select(c => c.CostPrice).ToList()[i]
                                                        * SellingQuery.Select(p => p.Sale).ToList()[j]) + costpricesellsperPrdoxForThisWeek;
                }
                costPriceListThisWeek.Add(costpricesellsperPrdoxForThisWeek);
            }

            decimal TotalcostForThisWeek = 0;
            foreach (var cp in costPriceListToday)
            {
                TotalcostForThisWeek = cp + TotalcostForThisWeek;
            }
            var totalearningThisWeek = salespriceThisWeek - TotalcostForThisWeek;

            //=========================================================================================================================
            List<decimal> costPriceListThisMonth = new List<decimal>();
            for (int i = 0; i < costquery.Count(); i++)
            {
                var SellingQuery = await context.SalesOrders.Where(p => p.ProductId == costquery.Select(q => q.ProductId).ToList()[i])
                  .Where(p => p.SalesDate >= month.Date && p.SalesDate <= ThedateEndDaynow).
                   Select(s => new { s.Price, s.Sale }).ToListAsync();
                decimal costpricesellsperPrdoxForThisMonth = 0;
                for (int j = 0; j < SellingQuery.Count(); j++)
                {
                    costpricesellsperPrdoxForThisMonth = (costquery.Select(c => c.CostPrice).ToList()[i]
                                                        * SellingQuery.Select(p => p.Sale).ToList()[j]) + costpricesellsperPrdoxForThisMonth;
                }
                costPriceListThisMonth.Add(costpricesellsperPrdoxForThisMonth);
            }

            decimal TotalcostForThisMonth = 0;
            foreach (var cp in costPriceListToday)
            {
                TotalcostForThisMonth = cp + TotalcostForThisMonth;
            }
            var totalearningThisMonth = salespriceThisMonth - TotalcostForThisMonth;
            //===============================================Overall Total Earning=====================================================
            List<decimal> OverallcostPriceList = new List<decimal>();

            for (int i = 0; i < costquery.Count(); i++)
            {
                var SellingQuery = await context.SalesOrders.Where(p => p.ProductId == costquery.Select(q => q.ProductId).ToList()[i])
                   .Select(s => new { s.Price, s.Sale }).ToListAsync();
                decimal costpricesellsperPrdox = 0;
                for (int j = 0; j < SellingQuery.Count(); j++)
                {
                    costpricesellsperPrdox = (costquery.Select(c => c.CostPrice).ToList()[i]
                                                        * SellingQuery.Select(p => p.Sale).ToList()[j]) + costpricesellsperPrdox;
                }
                OverallcostPriceList.Add(costpricesellsperPrdox);
            }
            decimal OveerallTotalcost= 0;
            foreach (var cp in OverallcostPriceList)
            {
                OveerallTotalcost = cp + OveerallTotalcost;
            }
            //get the overall sellscost ever
            var overallSaleCostEverQuery = await context.SalesOrders.Select(s => new { s.Price, s.Sale }).ToListAsync();
            decimal overallSaleCostEver = 0;
            for (int i = 0; i < overallSaleCostEverQuery.Count(); i++)
            {
                var price = overallSaleCostEverQuery[i].Price;
                var sale = overallSaleCostEverQuery[i].Sale;
                overallSaleCostEver = (price * sale) + overallSaleCostEver;
            }
            var OverallTotalEarning = overallSaleCostEver - OveerallTotalcost;
            //================================TotalProducts============================================================
            var totalProduct = await context.Products.ToListAsync();

            //================================totalVendor ==========================================================
            var totalVendor = await context.Vendors.ToListAsync();


            var model = new InventoryWhiteBoardViewModel();
            model.PurchaseOrderToday = purchaseOrderToday.ToString();
            model.PurchaseOrderThisWeek = PurchaseOrderThisWeek.ToString();
            model.PurchaseOrderThisMonth = PurchaseOrderThisMonth.ToString();
            model.SalesToDayPrice = salespriceToday.ToString();
            model.SalesToDayQuantity = salesquantityToday.ToString();
            model.SalesThisWeekPrice = salespriceThisWeek.ToString();
            model.SalesThisWeekQuantity = salesquantityThisWeeek.ToString();
            model.SalesThisMonthPrice = salespriceThisMonth.ToString();
            model.SalesThisMonthQuantity = salesquantityThisMonth.ToString();
            model.TotalEarningToday = totalearningtoday.ToString();
            model.TotalEarningThisWeek = totalearningThisWeek.ToString();
            model.TotalEarningThisMonth = totalearningThisMonth.ToString();
            model.TotalProducts = totalProduct.Count().ToString();
            model.TotalVendor = totalVendor.Count().ToString();
            model.TotalEarnings = OverallTotalEarning.ToString();
            model.PurchaseOrderCostToday = purchaseOrderTodayCost.ToString();
            model.PurchaseOrderCostThisWeek = purchaseOrderThisWeekCost.ToString();
            model.PurchaseOrderCostThisMonth = purchaseOrderThisMonthCost.ToString();
            return model;
        }

        public async Task<IEnumerable<WhiteBoardTable>> CreateWhiteBoardReport()
        {

            var product =await context.
                Products.
                Select(p=>new { p.ProductId,p.Name }).ToListAsync();
          
            List<WhiteBoardTable> WhiteBoardTable = new List<WhiteBoardTable>();

            foreach(var pdx in product)
            {

                var WhiteBoardTableQuery = await context
               .ProductPurchaseOrderTracking.Where(p => p.ProductId == pdx.ProductId)
               .Select(s => new { s.RemainingProductQty, s.TotalPoductQty })
               .LastOrDefaultAsync();
                if (WhiteBoardTableQuery == null)
                {
                    WhiteBoardTable.Add(new WhiteBoardTable
                    {
                        LastPurchaseDate = "null",
                        Product = pdx.Name,
                        QtyRemaining = "0",
                        TotalQty = "0",
                    });
                }
                var purchaseOrderDateQuery = await context.
                    PurchaseOrders.
                    Where(p => p.ProductId == pdx.ProductId)
                    .OrderBy(p => p.PurchaseOrderDate).LastAsync();
                var lastPurchaseDate = purchaseOrderDateQuery.PurchaseOrderDate;
                WhiteBoardTable.Add(new WhiteBoardTable
                {
                    LastPurchaseDate = lastPurchaseDate.ToString(),
                    Product = pdx.Name,
                    QtyRemaining = WhiteBoardTableQuery.RemainingProductQty.ToString(),
                    TotalQty = WhiteBoardTableQuery.TotalPoductQty.ToString(),
                });
            }
            return WhiteBoardTable;
        }

        public async Task<OverallSaleReportViewModel> CreateSaleReport(DateTime salesReportReportFrom, DateTime salesReportReportTo)
        {
            var salesReportViewModel = new List<SalesReportViewModel>();

           var query = await context.SalesOrders
                       .Where(s => s.SalesDate >= salesReportReportFrom.Date && 
                       s.SalesDate <= salesReportReportTo.Date).ToListAsync();

            //totalsale
            var totalsale = 0;
            foreach(var ts in query)
            {
                totalsale = ts.Sale + totalsale;
            }

            foreach (var so in query)
            {
                var pname = context.Products
                    .Where(p => p.ProductId == so.ProductId)
                    .Select(p=>p.Name).Single();

                var qtyRemaining = await context.ProductPurchaseOrderTracking
                    .Where(p => p.ProductId == so.ProductId)
                    .Select(p => p.RemainingProductQty)
                    .LastAsync();
                salesReportViewModel.Add(new SalesReportViewModel
                {
                    Price = so.Price.ToString(),
                    SalesDate = so.SalesDate.ToString("MM/dd/yyyy"),
                    QtyPerSaleForProduct = so.Sale.ToString(),
                    ProductName = pname,
                    RemainingQty = qtyRemaining.ToString(),
                    TotalSaleCostPerProduct = (so.Sale * so.Price)
                });
            }

            //overalltotalsalecost
            decimal overalltotalsalecost = 0;
            foreach (var ts in salesReportViewModel)
            {
                overalltotalsalecost = ts.TotalSaleCostPerProduct + overalltotalsalecost;
            }
            return new OverallSaleReportViewModel
            {
                SalesReportViewModel = salesReportViewModel,
                overalltotalsalecost = overalltotalsalecost,
                TotalSales = totalsale,
            };
        }

        public void EditProductPurchaseTracker(string productId, int quantity, DateTime purchaseOrderDate)
        {
            var OldcheckTrackerForProduct = context.
                       ProductPurchaseOrderTracking.
                       Where(t => t.ProductId == productId)
                      .LastOrDefault();
            context.ProductPurchaseOrderTracking.Remove(OldcheckTrackerForProduct);
            context.SaveChanges();

            var checkTrackerForProduct = context.
                       ProductPurchaseOrderTracking.
                       Where(t => t.ProductId == productId)
                      .LastOrDefault();
            if (checkTrackerForProduct == null)
            {
                var model = new ProductPurchaseOrderTracking
                {
                    ProductPurchaseOrderTrackerId = 0,
                    ProductId = productId,
                    TotalPoductQty = quantity,
                    RemainingProductQty = quantity,
                    DateTime = purchaseOrderDate
                };
                context.ProductPurchaseOrderTracking.Add(model);
                context.SaveChanges();
            }
            else
            {
                var model = new ProductPurchaseOrderTracking
                {
                    ProductPurchaseOrderTrackerId = 0,
                    ProductId = productId,
                    DateTime = purchaseOrderDate,
                };
                // if it not null then update it
                model.TotalPoductQty = checkTrackerForProduct.TotalPoductQty + quantity;
                model.RemainingProductQty = checkTrackerForProduct.RemainingProductQty + quantity;
                context.ProductPurchaseOrderTracking.Add(model);
                context.SaveChanges();
            }
        }
    }

}
