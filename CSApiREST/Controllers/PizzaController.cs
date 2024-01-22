using CSApiREST.Models;
using CSApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSApiREST.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() { }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost("add")]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);

        }

        // PUT action
        [HttpPut("edit/{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            Pizza? pizzaInDB = PizzaService.Get(id);

            if (id != pizza.Id)
            {
                return BadRequest();
            }
            if (pizzaInDB == null)
            {
                return NotFound();
            }

            PizzaService.Update(pizza);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
            {
                return NotFound();
            }

            PizzaService.Delete(id);
            return NoContent();
        }
    }

}
