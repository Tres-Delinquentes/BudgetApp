namespace Backend.Core.Interfaces;

public interface IPdfService
{
    public void GenerateBudgetReport(IBudget validatedBudget, string filePath);

}
