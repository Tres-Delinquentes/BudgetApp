using Backend.Api.Helpers;
using iText.Kernel.Pdf;
using iText.Layout.Properties;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Layout;
using iText.Layout.Element;
using iTextSharp;

namespace Backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly IBudgetManager _budgetManager;
    private readonly PDFGenerator _pdfGenerator;

    public BudgetController(PDFGenerator generator)
    {
        _budgetManager = BudgetManager.Instance;
        _pdfGenerator = generator;
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
            budgetList.Add(new Budget());
        }

        return budgetList;
    }


    [HttpPost]
    [Route("/api/Budget/generate-pdf")]
    public IActionResult GeneratePdf([FromBody] Budget budget)
    {
        IBudget validatedBudget = new Budget();
        try
        {
            validatedBudget = _budgetManager.BudgetChecker(budget);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, StatusCode = 450 });
        }

        string filePath = Path.Combine(Path.GetTempPath(), "BudgetRapport.pdf");
        _pdfGenerator.GenerateBudgetReport(validatedBudget, filePath);

        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/pdf", "BudgetRapport.pdf");
    }
}