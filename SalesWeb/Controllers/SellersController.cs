using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Services;

namespace SalesWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService sellerService;

        public SellersController(SellerService service)
        {
            sellerService = service;
        }

        public IActionResult Index()
        {
            var list = sellerService.FindAll();
            return View(list);
        }
    }
}