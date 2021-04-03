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
    public class CardsController : ControllerBase
    {
        ICardService _cartService;
        public CardsController(ICardService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("addcard")]
        public IActionResult CardAdd(Card cart)
        {
            var result =  _cartService.Add(cart);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
