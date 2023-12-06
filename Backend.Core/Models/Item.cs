namespace Backend.Core.Models;

public class Item : IItem
{
    private static int IdChecker = 1;
    public int Id { get; set; }
    public string? Name { get; set; }
    public float Amount { get; set; } = 0;

    public Item()
    {
        if(Id == 0)
        {
            Id = IdChecker;
            IdChecker++;
        }
    }        

}



