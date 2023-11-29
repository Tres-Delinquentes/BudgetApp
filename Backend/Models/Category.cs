namespace Backend.Models
{
    public class Category
    {
        public static int IdCheckerCategory = 1;
        public  int Id { get; set; }
        public string Name { get; set; }
        public float TotalAmount { get; set; } = 0;
        public List<Item> Items { get; set; } = new List<Item>();

        public Category()
        {
            Id = IdCheckerCategory;
            IdCheckerCategory++;
            
        }
    }
}


