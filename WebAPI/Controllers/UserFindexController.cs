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
    public class UserFindexController : ControllerBase
    {
        IUserFindexService _userFindexService;

        public UserFindexController(IUserFindexService userFindexService)
        {
            _userFindexService = userFindexService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserFindex userFindex)
        {
            var result = _userFindexService.Add(userFindex);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getuserfindex")]
        public IActionResult GetUserFindex(int userId)
        {
            var result = _userFindexService.GetFindexByUserId(userId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
