using Books.Models;
using E_CommerceWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ECommerceDBContext context;
        public HomeController(ILogger<HomeController> logger, ECommerceDBContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
        List<TbProduct> lstproducts = new List<TbProduct>();

        public IActionResult Index()
        {
            lstproducts = context.TbProducts.Include(a => a.Category).ToList();
            return View(lstproducts);
        }
        public IActionResult AddToCart(int id)
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (oShopingCart == null)
                oShopingCart = new ShopingCart();
            TbProduct item = context.TbProducts.Find(id);
            ShopingItem shopingItem = oShopingCart.lstItem.Where(a => a.ProductId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oShopingCart.lstItem.Add(new ShopingItem()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ImageName = item.ImageName,
                    Price = item.ProductSalePrice,
                    Qty = 1,
                    Total = item.ProductSalePrice
                });
            }

            oShopingCart.Total = oShopingCart.lstItem.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            return Redirect("/Home/Shop");
        }
        public IActionResult Shop()
        {
            lstproducts = context.TbProducts.Include(a => a.Category).ToList(); 
            return View(lstproducts);
        }
        public IActionResult Cart()
        {
            return View();
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
