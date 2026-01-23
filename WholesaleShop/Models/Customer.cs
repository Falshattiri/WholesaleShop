using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace WholesaleShop.Models;

public class Customer
{
   
    public int Id { get; set; }

    [RegularExpression(
        @"^[A-Za-z_][A-Za-z0-9_]{4,19}$",
        ErrorMessage = "اسم المستخدم 5–20، يبدأ بحرف أو _، وباقيه أحرف/أرقام/_ فقط، بدون مسافات أو رموز.")]
    public string UserName { get; set; }
    
    
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(30)]
    public string? Phone { get; set; }

    [MaxLength(200), EmailAddress]
    public string? Email { get; set; }

    [MaxLength(400)]
    public string? Address { get; set; }

    // حساب العميل (مدين/دائن)
    [Column(TypeName = "decimal(18,2)")]
    public decimal CurrentBalance { get; set; } = 0m;
    
    
    // Soft Delete
    public bool IsDeleted { get; set; } = true;
    
    
    // Relationships
    public ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    
}