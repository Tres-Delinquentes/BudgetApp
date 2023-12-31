﻿namespace Backend.Api.DAL;

public class ItemManager : IItemManager
{
    public ItemManager()
    {

    }

    public bool CheckIfItemsAreValidInBudget(IBudget budget)
    {
        budget.Expenses.ForEach(x => x.Items.ForEach(z => CheckValidItem(z)));           
         
        return true;
    }


    public bool CheckValidItem(IItem item) 
    {
        List<string> invalidSqlExpressions = new List<string>() { "Delete", "Insert", "Into", "Alter", "Drop Table", "Select", "Create Database", "Truncate" };

        // More checks to se if name contains sql injections? 

        if (string.IsNullOrWhiteSpace(item.Name))
        {
            throw new ArgumentException(item.Name + " cannot be null, empty, or whitespace." + item.Id.ToString());
        }

        if (item.Name.Length > 50)
        {
            throw new ArgumentException(item.Name + " cannot be longer then 50 characters.");
        }

        if (!char.IsLetterOrDigit(item.Name[0]))
        {
            throw new ArgumentException(item.Name + " cannot start with a special character.");
        }

        foreach (string sql in invalidSqlExpressions.Where(sql => item.Name.ToLower().Contains(sql.ToLower())))
        {
            throw new ArgumentException(item.Id + ". " + item.Name + " cannot contain any sql keywords!");
        }
        

        // Regex: Each word must start with an alphanumeric character, underscore, or dash.
        Regex validNameRegex = new Regex(@"^[a-zåäöA-ZÅÄÖ0-9-&]+( [a-zåäöA-ZÅÄÖ0-9-&]+)*$", RegexOptions.None, TimeSpan.FromMilliseconds(2000));
        if (!validNameRegex.IsMatch(item.Name))
        {
            throw new ArgumentException(item.Name + " contains invalid characters.");
        }
        

        if (item.Amount < 0)
        {
            throw new ArgumentException("Amount cannot be a negative number. Amount supplied: " + item.Amount);
        }

        return true;
    }
}
