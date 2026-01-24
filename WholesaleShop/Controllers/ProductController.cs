using Microsoft.AspNetCore.Mvc;
using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;


namespace WholesaleShop.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // GET - 
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        return View(products); 
    }
    
    //  ----------------- Create ---------------------- //
    
    // - Get 
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid) 
            return View(product);
        
        var result = await _productService.CreateProductAsync(product);
        return RedirectToAction(nameof(Index));
    }
    
    
    //  ----------------- Update ---------------------- //
    
    // Get
    [HttpGet] 
    public async Task<IActionResult> Update(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        
        // If the Product is null will show Not Foud
        if (product == null)
            return NotFound();
        
        return View(product);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Product product)
    {
        try
        {
            await _productService.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(product);
        }
    }
    
    //  Delete - POST //

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}