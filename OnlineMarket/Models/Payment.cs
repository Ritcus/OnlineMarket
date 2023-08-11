
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.Models
{
    public class Payment
    {
        [Key]
        [ForeignKey("Order")]
        public int PaymentId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDateTime { get; set; } = DateTime.Now;
        [StringLength(500)]
        public string Comments { get; set; } = string.Empty;
        public virtual ICollection<ReceiptImage>? ReceiptImages { get; set; } 
        public virtual Order Order { get; set; }
    }
}
