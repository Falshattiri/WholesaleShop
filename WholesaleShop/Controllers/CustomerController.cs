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
    
    // Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid)
            return NotFound();
        
        return View(customer);
    }
}