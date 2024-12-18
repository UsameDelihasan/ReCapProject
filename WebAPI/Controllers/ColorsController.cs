﻿using Business.Abstract;
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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _colorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var result = _colorService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpPost]
        public IActionResult Post([FromBody] Color color)
        {

            var result = _colorService.Add(color);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
