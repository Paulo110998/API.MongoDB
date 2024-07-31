using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketsService _ticketsService;

        public TicketsController(TicketsService ticketsService) =>
            _ticketsService = ticketsService;

        [HttpGet]
        public async Task<List<Ticket>> Get() =>
            await _ticketsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Ticket>> Get(string id)
        {
            var ticket = await _ticketsService.GetAsyncId(id);

            if (ticket is null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket newTicket)
        {
            await _ticketsService.CreateAsync(newTicket);

            return CreatedAtAction(nameof(Get), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Ticket updateTicket)
        {
            var ticket = await _ticketsService.GetAsyncId(id);

            if (ticket is null)
            {
                return NotFound();
            }

            updateTicket.Id = id;

            await _ticketsService.UpdateAsync(id, updateTicket);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var ticket = await _ticketsService.GetAsyncId(id);

            if (ticket is null)
            {
                return NotFound();
            }

            await _ticketsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
