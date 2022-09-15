using Microsoft.AspNetCore.Mvc;
using APIsViciBuzz.Models;
using APIsViciBuzz.Services;
using MongoDB.Driver.Encryption;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIsViciBuzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMakeOrderService makeOrderService;

        public OrderController(IMakeOrderService makeOrderService)
        {
            this.makeOrderService = makeOrderService;
        }



        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<MakeOrder>> Get()
        {
            return makeOrderService.Get();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<MakeOrder> Get(string id)
        {
            var item = makeOrderService.Get(id);
            if(item == null)
            {
                return NotFound($"item with Id= {id} Not Found");
            }
            return item;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<MakeOrder> Post([FromBody] MakeOrder makeOrder)
        {
            makeOrderService.Create(makeOrder);
            return CreatedAtAction(nameof(Get), new { id = makeOrder.Id }, makeOrder);

        }

        // PUT api/<OrderController>/5
       /* [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] MakeOrder makeOrder)
        {
            var existingItem = makeOrderService.Get(id);
            if (existingItem == null)
            {
                return NotFound($"item with Id={id} Not Found");
            }
            makeOrderService.Update(id, makeOrder);
            return NoContent();

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
