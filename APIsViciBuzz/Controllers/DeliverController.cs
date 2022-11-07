using APIsViciBuzz.Models;
using APIsViciBuzz.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIsViciBuzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverController : ControllerBase
    {

        private readonly IDeliverOrderService deliverOrderService;

        public DeliverController(IDeliverOrderService deliverOrderService)
        {
            this.deliverOrderService = deliverOrderService;
        }


        // GET: api/<DeliverController>
        [HttpGet]
        public ActionResult<List<DeliverOrder>> Get()
        {
            return deliverOrderService.Get();
        }

        // GET api/<DeliverController>/5
        [HttpGet("{id}")]
        public ActionResult<DeliverOrder> Get(string id)
        {
            var item = deliverOrderService.Get(id);
            if (item == null)
            {
                return NotFound($"item with Id= {id} Not Found");
            }
            return item;
        }

        // POST api/<DeliverController>
        [HttpPost]
        public ActionResult<DeliverOrder> Post([FromBody] DeliverOrder deliverOrder)
        {
            deliverOrderService.Create(deliverOrder);
            return CreatedAtAction(nameof(Get), new { id = deliverOrder.Id }, deliverOrder);
        }

       /* // PUT api/<DeliverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeliverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
