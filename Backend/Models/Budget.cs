namespace Backend.Models
{
    public class Budget
    {
        public Category Income { get; set; } = new Category();
        public string Title { get; set; }
        public List<Category> Expenses { get; set; } = new List<Category>();


        public Budget()
        {
           
        }
    }
}
