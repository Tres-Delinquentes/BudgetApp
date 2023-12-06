namespace Backend.Api.Controllers;

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
        if (_budgetManager.SmallBudget != null && _budgetManager.MediumBudget != null && _budgetManager.LargeBudget != null)
        {
            budgetList.Add(_budgetManager.SmallBudget);
            budgetList.Add(_budgetManager.MediumBudget);
            budgetList.Add(_budgetManager.LargeBudget);
        }        
        // hej hej hej 
        return budgetList;
    }


    // Göra Async?
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
    
}
