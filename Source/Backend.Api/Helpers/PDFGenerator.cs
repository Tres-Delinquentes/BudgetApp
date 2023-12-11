using Backend.Api.Helpers;
using iText.Kernel.Pdf;
using iText.Layout.Properties;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Layout;
using iText.Layout.Element;
using iTextSharp;

namespace Backend.Api.Helpers;

public class PDFGenerator
{

    internal void GenerateBudgetReport(Budget validatedBudget, string filePath)
    {
        using (var pdfStream = new FileStream(filePath, FileMode.Create))
        {
            using (PdfWriter writer = new PdfWriter(pdfStream))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Header
                    if (validatedBudget.Title != null && validatedBudget.Title != "")
                        document.Add(new Paragraph(validatedBudget.Title).SetFontSize(20).SetBold().SetTextAlignment(TextAlignment.CENTER));

                    // Description
                    if (validatedBudget.Description != null && validatedBudget.Description != "")
                        document.Add(new Paragraph(validatedBudget.Description));

                    document.Add(new Paragraph("\n"));

                    // Income
                    document.Add(new Paragraph("Din inkomst: ").SetBold().SetFontSize(15));
                    document.Add(new Paragraph(validatedBudget.Income.TotalAmount.ToString() + " kr"));
                    document.Add(new Paragraph(new String('.', 40)));

                    // Espenses
                    var totalExpense = 0.0;

                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph("Dina utgifter : ").SetBold().SetFontSize(15));
                    foreach (var category in validatedBudget.Expenses)
                    {
                        document.Add(new Paragraph(category.Name + ": " + category.TotalAmount + " kr").SetUnderline().SetFontSize(13));
                        totalExpense += category.TotalAmount;
                        foreach (var item in category.Items)
                        {
                            document.Add(new Paragraph(item.Name + ": " + item.Amount + " kr"));
                        }
                    }
                    document.Add(new Paragraph(new String('.', 40)));
                    document.Add(new Paragraph("\n"));

                    // Summary
                    var balance = Math.Round((validatedBudget.Income.TotalAmount - totalExpense), 2);
                    document.Add(new Paragraph("Summering").SetBold().SetFontSize(15));
                    if (balance >= 0)
                        document.Add(new Paragraph("Du kan spara: " + balance + " kronor denna period."));
                    else
                        document.Add(new Paragraph("Din balans: -" + balance + " kr"));

                    // Finished
                    document.Close();
                }
            }
        }

    }

}
