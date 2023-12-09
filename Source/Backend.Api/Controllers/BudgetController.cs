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
            budgetList.Add(new Budget());
        }

        return budgetList;
    }


    [HttpPost]
    [Route("/api/Budget/generate-pdf")]
    public IActionResult GeneratePdf([FromBody] Budget budget)
    {
        try
        {
            string filePath = Path.Combine(Path.GetTempPath(), "GeneratedPdf.pdf");

            using (var pdfStream = new FileStream(filePath, FileMode.Create))
            {
                using (PdfWriter writer = new PdfWriter(pdfStream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);


                        // Header
                        var header = new Paragraph(budget.Title).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(header);

                        // Income

                        // Espenses

                        // Summary
                        document.Close();

                        //pdfStream.Position = 0;
                        //return new FileStreamResult(pdfStream, "application/pdf")
                        //{
                        //    FileDownloadName = "budget-report.pdf"
                        //};


                    }
                }

            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "GeneratedPdf.pdf");
        }
        catch (ArgumentException ae)
        {
            return BadRequest(new { message = ae.Message, StatusCode = 418 });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message, StatusCode = 500 });
        }
    }
}

//private MemoryStream GenerateBudgetReport(Budget budget)
//{
//    var pdfStream = new MemoryStream();

//    using (PdfWriter writer = new PdfWriter(pdfStream))
//    {
//        using (PdfDocument pdf = new PdfDocument(writer))
//        {
//            Document document = new Document(pdf);


//            // Header
//            var header = new Paragraph(budget.Title).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER);
//            document.Add(header);

//            // Income

//            // Espenses

//            // Summary

//            return pdfStream;
//        }
//    }
//}




//[HttpPost]
//public IActionResult GeneratePdfAsync([FromBody] Budget budget)
//{
//    try
//    {
//        // Anropa PdfService för att generera PDF baserat på den skickade datan
//        var pdfBytes = _pdfGenerator.GeneratePdfAsync(budget);

//        // Returnera en OkObjectResult med PDF-datan, MIME-typen och statuskoden OK
//        return Ok(new
//        {
//            File = pdfBytes,
//            ContentType = "application/pdf",
//            FileName = "example.pdf"
//        });
//    }
//    catch (Exception ex)
//    {
//        // Om något går fel, returnera en BadRequest med felmeddelandet
//        return BadRequest(new { message = ex.Message });
//    }
//}

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


