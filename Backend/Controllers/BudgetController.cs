using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetManager _budgetManager;

        public BudgetController()
        {            
            _budgetManager = BudgetManager.Instance;
        }

        // GET: api/<BudgetController>
        [HttpGet]
        public List<Budget> Get()
        {
            var budgetList = new List<Budget>();

            budgetList.Add(_budgetManager.SmallBudget);
            budgetList.Add(_budgetManager.MediumBudget);
            budgetList.Add(_budgetManager.LargeBudget);

            return budgetList;
        }

        // POST api/<BudgetController>
        [HttpPost]
        public IActionResult HandleBudgetPostedFromUser([FromBody] Budget budget)
        {
            try
            {
                _budgetManager.BudgetChecker(budget);
                return Ok(budget);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, StatusCode = 450});
            }
        }


        //// GET api/<BudgetController>/5
        //[HttpGet("{id}")]
        //public Budget Get(int id)
        //{
        //    var budget = new Budget();

        //    switch (id)
        //    {
        //        case 1:
        //            budget = _budgetManager.SmallBudget;
        //            break;
        //        case 2:
        //            budget = _budgetManager.MediumBudget;
        //            break;
        //        case 3:
        //            budget = _budgetManager.LargeBudget;
        //            break;

        //    }
        //    return budget;
        //}


        //// PUT api/<BudgetController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        //// DELETE api/<BudgetController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
