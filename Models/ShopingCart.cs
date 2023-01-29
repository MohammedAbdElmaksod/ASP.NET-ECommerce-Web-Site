using System.Collections.Generic;
using E_CommerceWebSite.Models;
namespace E_CommerceWebSite.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            lstItem = new List<ShopingItem>();
        }
        public List<ShopingItem>lstItem { get; set; }
        public decimal Total { get; set; }
    }
}
