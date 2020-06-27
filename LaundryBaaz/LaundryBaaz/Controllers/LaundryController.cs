﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaundryBaaz.Interfaces;
using LaundryBaaz.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaundryBaaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaundryController : ControllerBase
    {
        private readonly ILaundryRepository _laundryRepository;

        public LaundryController(ILaundryRepository laundryRepository)
        {
            _laundryRepository = laundryRepository;
        }
        // GET api/laundry
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/laundry/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/laundry
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Profile profile)
        {
            var result = _laundryRepository.SignUpDetails(profile);
            return result.Result;
        }

        // PUT api/laundry/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/laundry/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
