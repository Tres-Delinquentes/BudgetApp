namespace Backend.Core.Models;

public class Budget : IBudget
{
    public Category Income { get; set; } = new Category();
    public string? Title { get; set; }
    public List<Category> Expenses { get; set; } = new List<Category>();
    
}
