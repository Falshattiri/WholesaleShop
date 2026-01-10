using Microsoft.AspNetCore.Mvc;
using WholesaleShop.Services.Interfaces;

namespace WholesaleShop.Controllers;

public class ProdcutController : Controller
{
    private readonly IProductService _productService;

    public ProdcutController(IProductService productService)
    {
        _productService = _productService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    // 
    
    
}