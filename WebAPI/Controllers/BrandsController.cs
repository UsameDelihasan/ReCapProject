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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var result = _brandService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpPost]
        public IActionResult Post([FromBody] Brand brand)
        {

            var result = _brandService.Add(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
