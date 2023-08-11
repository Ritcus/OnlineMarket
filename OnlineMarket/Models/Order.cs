using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        [StringLength(500)]
        public string Comments {get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual Delivery? Delivery { get; set; }
        public virtual Payment? Payment { get; set; }
       
    }
}
