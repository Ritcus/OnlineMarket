using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models
{
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        [StringLength(50)]
        public string LogLevel { get; set; } = string.Empty;
        [MaxLength]
        public string Message { get; set; } = string.Empty;
    }
}
