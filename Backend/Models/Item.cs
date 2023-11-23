using System.Globalization;
using System.Runtime.CompilerServices;

namespace Backend.Models
{
    public class Item
    {
        public Guid Id { get; set; } = new Guid(); //int
        public string Name { get; set; }
        public float Amount { get; set; } 


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



