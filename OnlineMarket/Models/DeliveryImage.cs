using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class DeliveryImage
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(2048)]
        public byte[] Image { get; set; }
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
