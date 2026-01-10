using Microsoft.AspNetCore.Mvc;

namespace WholesaleShop.Controllers;

public class ProdcutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}