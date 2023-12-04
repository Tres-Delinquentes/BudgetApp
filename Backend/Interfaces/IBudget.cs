namespace Backend.Interfaces
{
    public interface IBudget
    {
        public Category Income { get; set; }
        public string? Title { get; set; }
        public List<Category> Expenses { get; set; }
    }
}
