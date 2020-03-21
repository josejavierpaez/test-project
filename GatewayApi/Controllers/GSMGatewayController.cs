using System.Reflection.Metadata.Ecma335;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GatewayApi.Core.Models;
using GatewayApi.Core;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("GetByIp/{ip}", Name = "GetByIp")]
        public ActionResult<GSMGateway> GetByIp(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return BadRequest(new ArgumentNullException(nameof(ip), "You must write an IP Address"));

            var gsmGateway = _context.GSMGateways.FirstOrDefault(s => s.Ip.Equals(ip));

            if (gsmGateway == null)
                return NotFound("not foud");

            return Ok(gsmGateway);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GSMGateway gsmGateway)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = _context.Providers.FirstOrDefault(p => p.ProviderId == gsmGateway.ProviderId);

            if (provider == null)
                return BadRequest("The provider ID does not exist, write one valid");

            await _context.GSMGateways.AddAsync(gsmGateway);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetByIp", new { ip = gsmGateway.Ip }, gsmGateway);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]GSMGateway GSMGateway)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingGSMGateway = _context.GSMGateways.FirstOrDefault(g => g.Ip == GSMGateway.Ip);

            if (existingGSMGateway == null)
                return NotFound("GSMGateway does not  exist in the DataBase");

            var provider = _context.Providers.FirstOrDefault(p => p.ProviderId == GSMGateway.ProviderId);

            if (provider == null)
                return BadRequest("the provider ID does not exist, write one valid");

            existingGSMGateway = GSMGateway;

            await _context.SaveChangesAsync();

            return Ok(existingGSMGateway);
        }

        [HttpDelete("{ip}")]
        public async Task<ActionResult> Delete(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return BadRequest(new ArgumentNullException(nameof(ip), "You must write an IP Address"));

            var existingGSMGateway = _context.GSMGateways.FirstOrDefault(g => g.Ip == ip);

            if (existingGSMGateway == null)
                return NotFound("GSMGateway does not  exist in the DataBase");

            _context.GSMGateways.Remove(existingGSMGateway);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}