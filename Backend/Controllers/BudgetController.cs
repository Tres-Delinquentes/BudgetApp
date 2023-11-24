﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        // GET: api/<BudgetController>
        [HttpGet]
        public Budget Get()
        {
            var budgetManager = new BudgetManager();
            var budget = budgetManager.SmallBudget;
            return budget;
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}