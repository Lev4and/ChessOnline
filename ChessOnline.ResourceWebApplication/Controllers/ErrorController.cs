﻿using ChessOnline.Model.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessOnline.ResourceWebApplication.Controllers
{
    [ApiController]
    [Route("api/error")]
    [EnableCors("CorsPolicy")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("badRequest")]
        [ProducesResponseType(typeof(BaseResponseModel<object?>), 200)]
        public IActionResult BadRequest()
        {
            return Ok(new BaseResponseModel<object?>(null, Statuses.InvalidData));
        }

        [HttpGet]
        [Route("notFound")]
        [ProducesResponseType(typeof(BaseResponseModel<object?>), 200)]
        public IActionResult NotFound()
        {
            return Ok(new BaseResponseModel<object?>(null, Statuses.NotFound));
        }

        [HttpGet]
        [Route("forbidden")]
        [ProducesResponseType(typeof(BaseResponseModel<object?>), 200)]
        public IActionResult Forbidden()
        {
            return Ok(new BaseResponseModel<object?>(null, Statuses.Forbidden));
        }

        [HttpGet]
        [Route("unauthorized")]
        [ProducesResponseType(typeof(BaseResponseModel<object?>), 200)]
        public IActionResult Unauthorized()
        {
            return Ok(new BaseResponseModel<object?>(null, Statuses.Unauthorized));
        }
    }
}
