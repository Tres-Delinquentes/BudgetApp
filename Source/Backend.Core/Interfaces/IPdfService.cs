namespace Backend.Core.Interfaces;

public interface IPdfService
{
    public void GenerateBudgetReport(Budget validatedBudget, string filePath);

}
