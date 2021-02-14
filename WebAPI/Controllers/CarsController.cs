using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll() 
        {
            var result = _carService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int brandId) 
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetCarDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addcar")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("deletecar")]
        public IActionResult DeleteCar(int carId)
        {
            var deletecar = new Car() {Id = carId };
            var result = _carService.Delete(deletecar);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updatecar")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
