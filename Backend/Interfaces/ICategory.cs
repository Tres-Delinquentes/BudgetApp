namespace Backend.Interfaces
{
    public interface ICategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float TotalAmount { get; set; }
        public List<Item> Items { get; set; }
    }
}
