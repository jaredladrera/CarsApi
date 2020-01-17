using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarsApi.Models;
using CarsApi.Services;

namespace CarsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController: ControllerBase
    {

        private readonly CarService _cs;

        public CarController(CarService carservice)
        {
            _cs = carservice;
        }

        // getting all records from the database
        [HttpGet]
        public ActionResult<List<Cars>> Get() =>
            _cs.Get();

        [HttpGet("{id:length(24)}", Name = "GetCar")]
        public ActionResult<Cars> Get(string id)
        {
            var car = _cs.Get(id);

            if(car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        public ActionResult<Cars> Create(Cars car)
        {
            _cs.Create(car);

            return CreatedAtRoute("GetCar", new { id = car.Id.ToString() }, car);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Cars carIn)
        {
            var car = _cs.Get(id);

            if(car == null)
            {
                return NotFound();
            }

            _cs.Update(id, carIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var car = _cs.Get(id);

            if(car == null)
            {
                return NotFound();
            }

            _cs.Remove(car.Id);

            return NoContent()  ;

        }


    }
}
