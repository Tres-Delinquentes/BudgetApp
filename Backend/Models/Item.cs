using Backend.Interfaces;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Backend.Models
{
    public class Item : IItem
    {
        public static int IdChecker = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; } = 0;

        public Item()
        {
            if(Id == 0)
            {
                Id = IdChecker;
                IdChecker++;
            }
        }


        // Ska float Amount vara en string för bättre flexibilitet?
        // Vi måste validera ordentligt då.

        //public float ParseAmount(string amountString)
        //{
        //    try
        //    {
        //        return float.Parse(amountString, CultureInfo.InvariantCulture);
        //    }
        //    catch (FormatException)
        //    {                
        //        throw new ArgumentException("Amount is not in a valid format");
        //    }
        //}

    }
}



