using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(2048)]
        public byte[] Image { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
