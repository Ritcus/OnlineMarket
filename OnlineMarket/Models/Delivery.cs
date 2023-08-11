using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineMarket.Models.Enums.ProjectEnums;

namespace OnlineMarket.Models
{
    public class Delivery
    {
        [Key]
        [ForeignKey("Order")]
        public int DeliveryId { get; set; }
        public DeliveryStatus Status { get; set; }
        public DateTime LowerTimeRange { get; set; }
        public DateTime UpperTimeRange { get; set; }
        public bool IsCompleted { get; set; }
        [StringLength(500)]
        public string Instructions { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public virtual ICollection<DeliveryImage>? DeliveryImages { get; set; }
        public virtual Order? Order { get; set; }
    }
}
