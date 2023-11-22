namespace Backend.Models
{
    public class Category
    {
        public string Name { get; set; }
        public float TotalAmount { get; set; }
        public List<Item> Items { get; set; }
    }
}


