using System.Collections.Generic;

namespace GatewayApi.Core.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }

        public List<GSMGateway> GSMGateways { get; set; }
    }
}