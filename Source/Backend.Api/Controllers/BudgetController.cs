using Backend.Api.Helpers;
using iText.Kernel.Pdf;
using System.IO;

namespace Backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly BudgetManager _budgetManager;
    private readonly PDFGenerator _pdfGenerator;

    public BudgetController(PDFGenerator pdfGenerator)
    {
        _budgetManager = BudgetManager.Instance;
        _pdfGenerator = pdfGenerator;
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
    public IActionResult GeneratePdf([FromBody] Budget budget)
    {
        try
        {
            // Anropa PdfService för att generera PDF baserat på den skickade datan
            var pdfBytes = _pdfGenerator.GeneratePdf(budget);

            // Returnera en OkObjectResult med PDF-datan, MIME-typen och statuskoden OK
            return Ok(new
            {
                File = pdfBytes,
                ContentType = "application/pdf",
                FileName = "example.pdf"
            });
        }
        catch (Exception ex)
        {
            // Om något går fel, returnera en BadRequest med felmeddelandet
            return BadRequest(new { message = ex.Message });
        }
    }

    //[HttpPost]
    //public IActionResult HandleBudgetPostedFromUser([FromBody] Budget budget)
    //{
    //    MemoryStream memoryStream = new MemoryStream();
    //    PdfDocument? pdf = null;

    //    try
    //    {
    //        var isValidated = _budgetManager.BudgetChecker(budget);
    //        if (isValidated)
    //        {
    //            var writer = new PdfWriter(memoryStream);
    //            pdf = new PdfDocument(writer);

    //            var pdfBytes = _pdfGenerator.GeneratePdf(budget, pdf, memoryStream);
    //            // Återställ positionen för MemoryStream
    //            //if (memoryStream.CanSeek)
    //                memoryStream.Position = 0;
    //            return Ok(new
    //            {
    //                File = pdfBytes,
    //                ContentType = "application/pdf",
    //                FileName = "example.pdf"
    //            });
    //        }
    //        return BadRequest(new { message = "Budget did not pass validation", StatusCode = 418 });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message, StatusCode = 450 });
    //    }
    //    //finally
    //    //{
    //    //    pdf?.Close();
    //    //    memoryStream.Dispose();
    //    //}
}

    // Göra Async?
    // POST api/<BudgetController>
    //[HttpPost]
    //public IActionResult HandleBudgetPostedFromUser([FromBody] Budget budget)
    //{
    //    try
    //    {
    //        var isValidated = _budgetManager.BudgetChecker(budget);
    //        if (isValidated)
    //        {
    //            var memoryStream = new MemoryStream();
    //            var writer = new PdfWriter(memoryStream);
    //            var pdf = new PdfDocument(writer);

    //            var pdfBytes = _pdfGenerator.GeneratePdf(budget, pdf, memoryStream);
    //            return Ok(new
    //            {
    //                File = pdfBytes,
    //                ContentType = "application/pdf",
    //                FileName = "example.pdf"
    //            });

    //        }
    //        return BadRequest(new { message = "Budget did not pass validation", StatusCode = 418 });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message, StatusCode = 450 });
    //    }
    //    finally
    //    {
    //        pdf?.Close();
    //        memoryStream.Dispose();
    //    }
    //}


