using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GatewayApi.Core.Models;
using GatewayApi.Core;
namespace GatewayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GSMGatewayController : Controller
    {
        private ApplicationDbContext _context;
        public GSMGatewayController(ApplicationDbContext context)
        {
            _context = context;
        }

        ~GSMGatewayController()
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GSMGateway>> Get()
        {
            return _context.GSMGateways.ToList();
        }
    }
}