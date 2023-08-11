using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class ReceiptImage
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(2048)]
        public byte[] Image { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
