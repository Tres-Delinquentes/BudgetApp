namespace Backend.Models
{
    public class Category
    {
        public string Name { get; set; }
        public float TotalAmount { get; set; } = 0;
        public List<Item> Items { get; set; } = new List<Item>();
    }
}


