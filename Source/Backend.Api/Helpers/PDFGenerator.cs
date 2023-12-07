using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Backend.Api.Helpers;

public class PDFGenerator
{
    public static IActionResult GeneratePdf(Budget budget)
    {
        float totalIncome = 0;
        float totalExpense = 0;
        // Skapa ett MemoryStream för att hålla PDF-datan
        using (var memoryStream = new MemoryStream())
        {
            // Skapa ett PdfWriter-objekt
            using (var writer = new PdfWriter(memoryStream))
            {
                // Skapa ett PdfDocument-objekt
                using (var pdf = new PdfDocument(writer))
                {
                    // Skapa ett Document-objekt för att lägga till innehåll
                    var document = new Document(pdf);

                    // Lägg till innehåll i PDF, t.ex. text
                    document.Add(new Paragraph("Din inkomst"));
                    foreach (var incomeItem in budget.Income.Items)
                    {
                        document.Add(new Paragraph(incomeItem.Name + ": " + incomeItem.Amount));
                        totalIncome += incomeItem.Amount;
                    }
                    document.Add(new Paragraph("--------------------"));
                    document.Add(new Paragraph("Dina utgifter"));
                    foreach (var category in budget.Expenses)
                    {
                        document.Add(new Paragraph(category.Name + ": " + category.TotalAmount));
                        totalExpense += category.TotalAmount;
                        foreach (var item in category.Items)
                        {
                            document.Add(new Paragraph(item.Name + ": " + item.Amount));
                        }
                    }

                    document.Add(new Paragraph("........................"));

                    var balance = (totalIncome - totalExpense);

                    if (balance >= 0)
                        document.Add(new Paragraph("Din balans: +" + balance));
                    else 
                        document.Add(new Paragraph("Din balans: -" + balance));



                    // Stäng dokumentet
                    document.Close();
                }
            }

            // Återställ positionen för MemoryStream
            memoryStream.Position = 0;

            // Returnera en FileContentResult med MemoryStream och MIME-typen
            return new FileContentResult(memoryStream.ToArray(), "application/pdf")
            {
                FileDownloadName = budget.Title + ".pdf"
            };
        }
    }
}
