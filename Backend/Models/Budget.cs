namespace Backend.Models
{
    public class Budget
    {
        
        public List<Item> Income { get; set; }

        public string Title { get; set; }
        public List<Category> Expenses { get; set; } = new List<Category>();


        public Budget()
        {
           
        }

        
    }
}
