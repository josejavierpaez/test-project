using System.ComponentModel.DataAnnotations;

namespace GatewayApi.Core.Models
{
    public class GSMGateway
    {
        [Key]
        public string Ip { get; set; }
        public string User { get; set; }
        public int Password { get; set; }
        public int ProviderId { get; set; }
        //public Provider Providers { get; set; }
    }
}