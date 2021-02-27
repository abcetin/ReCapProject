using Business.Abstract;
using Business.Constans;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
         
            var result = _carImageService.Add(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(int carId)
        {
            var delete = new CarImage() { Id = carId };
            var result = _carImageService.Delete(delete);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int carId)
        {
            var update = new CarImage() { Id = carId };
            var result = _carImageService.Update(file,update);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
