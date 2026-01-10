using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WholesaleShop.Enums;

namespace WholesaleShop.Models;

public class Payment
{
    public int Id { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }

    // Nullable FK حسب النوع
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    [MaxLength(800)]
    public string? Notes { get; set; }
}