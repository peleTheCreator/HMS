using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.AccountViewModel
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
        new Claim("Create Booking", "Create Booking"),
        new Claim("Edit Booking","Edit Booking"),
        new Claim("Delete Booking","Delete Booking"),

        new Claim("Delete Product","Delete Product"),
        new Claim("Create Product","Create Product"),
        new Claim("Edit Product","Edit Product"),


        new Claim("Delete PurchaseOrder","Delete PurchaseOrder"),
        new Claim("Create PurchaseOrder","Create PurchaseOrder"),
        new Claim("Edit PurchaseOrder","Edit PurchaseOrder"),
        new Claim("Delete Vendor","Delete Vendor"),

        };
    }
}
