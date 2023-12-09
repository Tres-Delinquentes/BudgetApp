using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iTextSharp;

namespace Backend.Api.Helpers;

public class PDFGenerator
{

    internal MemoryStream GenerateBudgetReport(Budget budget)
    {
        var pdfStream = new MemoryStream();

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
            }
            pdfStream.Position = 0;
            return pdfStream;
        }
    }




    //public async Task<byte[]> GeneratePdfAsync(Budget budget)
    //{

    //    var failedByteArray = new byte[0];
    //    await Task.Run(() =>
    //    {
    //        using (var memoryStream = new MemoryStream())
    //        {
    //            using (var writer = new PdfWriter(memoryStream))
    //            {
    //                using (var pdf = new PdfDocument(writer))
    //                {
    //                    var document = new Document(pdf);
    //                    // Lägg till innehåll i PDF baserat på pdfData
    //                    // ...

    //                    var header = new Paragraph(budget.Title).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER);
    //                    document.Add(header);
    //                }
    //            }

    //            // Återställ positionen för MemoryStream
    //            memoryStream.Position = 0;

    //            return memoryStream.ToArray();
    //        }
    //    });
    //    return failedByteArray;
    //}








    //public  byte[] GeneratePdf(Budget budget, PdfDocument pdf, MemoryStream memoryStream)
    //{
    //    float totalIncome = 0;
    //    float totalExpense = 0;
    //    // Skapa ett MemoryStream för att hålla PDF-datan
    //        // Skapa ett PdfWriter-objekt

    //            // Skapa ett PdfDocument-objekt

    //                // Skapa ett Document-objekt för att lägga till innehåll
    //                var document = new Document(pdf);

    //                // Lägg till innehåll i PDF, t.ex. text
    //                document.Add(new Paragraph(budget.Title).SetTextAlignment(TextAlignment.CENTER));
    //                document.Add(new Paragraph("Din inkomst"));
    //                foreach (var incomeItem in budget.Income.Items)
    //                {
    //                    document.Add(new Paragraph(incomeItem.Name + ": " + incomeItem.Amount));
    //                    totalIncome += incomeItem.Amount;
    //                }
    //                document.Add(new Paragraph("--------------------"));
    //                document.Add(new Paragraph("Dina utgifter"));
    //                foreach (var category in budget.Expenses)
    //                {
    //                    document.Add(new Paragraph(category.Name + ": " + category.TotalAmount));
    //                    totalExpense += category.TotalAmount;
    //                    foreach (var item in category.Items)
    //                    {
    //                        document.Add(new Paragraph(item.Name + ": " + item.Amount));
    //                    }
    //                }

    //                document.Add(new Paragraph("........................"));

    //                var balance = (totalIncome - totalExpense);

    //                if (balance >= 0)
    //                    document.Add(new Paragraph("Din balans: +" + balance));
    //                else 
    //                    document.Add(new Paragraph("Din balans: -" + balance));



    //                // Stäng dokumentet
    //                document.Close();




    //        // Returnera en FileContentResult med MemoryStream och MIME-typen
    //        return memoryStream.ToArray();


    //}



}
