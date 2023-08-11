using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<ProductImage>? ProductImages { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
