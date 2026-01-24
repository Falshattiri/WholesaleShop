using Microsoft.AspNetCore.Mvc;
using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;

namespace WholesaleShop.Controllers;

public class CustomerController : Controller
{
    
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return View(customers);
    }
    
     //  ----------------- Create ---------------------- //
     
    // Get
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (!ModelState.IsValid)
            return View(customer);
        
        var result = await _customerService.CreateCustomerAsync(customer);
        
        return RedirectToAction(nameof(Index));
        
    }
    
    
    // Update- GET
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();
        
        return View(customer);
    }
    
    // Update -PSOt
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Customer customer)
    {
        try {
            await _customerService.UpdateCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(customer);
        }
    }
    
    // Delete - POST
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    
    
}