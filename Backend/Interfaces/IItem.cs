namespace Backend.Interfaces
{
    public interface IItem
    {
        public static int IdChecker;
        public int Id { get; set; };
        public string Name { get; set; };
        public float Amount { get; set; };
    }
}
