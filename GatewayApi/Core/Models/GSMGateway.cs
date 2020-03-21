using System.ComponentModel.DataAnnotations;

namespace GatewayApi.Core.Models
{
    public class GSMGateway
    {
        [Key]
        [Required]
        public string Ip { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public int ProviderId { get; set; }
    }
}