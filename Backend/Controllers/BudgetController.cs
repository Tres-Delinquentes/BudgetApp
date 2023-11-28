using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetManager _budgetManager;

        public BudgetController(BudgetManager budgetManager)
        {
            _budgetManager = budgetManager;
        }

        // GET: api/<BudgetController>
        [HttpGet]
        public Budget Get()
        {
            var budget = _budgetManager.SmallBudget;
            //budget.Add(_budgetManager.SmallBudget);
            //budget.Add(_budgetManager.MediumBudget);
            //budget.Add(_budgetManager.LargeBudget);
            return budget;
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public Budget Get(int id)
        {
            var budget = new Budget();            

            switch (id)
            {
                case 1:
                    budget = _budgetManager.SmallBudget;
                    break;
                case 2:
                    budget = _budgetManager.MediumBudget;
                    break;
                case 3:
                    budget = _budgetManager.LargeBudget;
                    break;

            }
            return budget;
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody] Budget budget)
        {
            _budgetManager.BudgetChecker(budget);
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
