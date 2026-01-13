using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WholesaleShop.Models;

public class Product
{
   public int Id { get; set; }

   [Required, MaxLength(200)]
   public string Name { get; set; } = string.Empty;

   [Required, MaxLength(80)]
   public string Code { get; set; } = string.Empty;

   // سعر البيع
   [Column(TypeName = "decimal(18,2)")]
   public decimal UnitPrice { get; set; }

   // سعر الشراء
   [Column(TypeName = "decimal(18,2)")]
   public decimal CostPrice { get; set; }

   // الكمية في المخزن
   public int StockQty { get; set; } = 0;
   
   // Soft Delete
   public bool IsDeleted { get; set; } = true;

   // Relationships
   public ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();
   public ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
   
}