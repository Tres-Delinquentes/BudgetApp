﻿using Backend.Api.Helpers;
using Backend.Core.Models;

namespace Backend.Api.DAL;

public class BudgetManager : IBudgetManager
{
    private static BudgetManager? _instance;
    private readonly ICategoryManager _categoryManager;
    private readonly IItemManager _itemManager;
    public Budget? SmallBudget { get; set; }
    public Budget? MediumBudget { get; set; }
    public Budget? LargeBudget { get; set; }

    private BudgetManager(ICategoryManager categoryManager, IItemManager itemManager)
    {

        var helpers = new Helpers.BudgetFiller();
        SmallBudget = helpers.FetchSmallBudget();
        MediumBudget = helpers.FetchMediumBudget();
        LargeBudget = helpers.FetchLargeBudget();

        _categoryManager = categoryManager;
        _itemManager = itemManager;


    }
    public BudgetManager()
    {
        
    }


    public IBudget BudgetChecker(IBudget budget)
    {
        IBudget newBudget = new Budget();
        if (budget != null)
        {
            budget = TrimNamesOfBudget(budget);

            if (_itemManager.CheckIfItemsAreValidInBudget(budget)
                && _categoryManager.CheckExpensesOfBudget(budget)
                && _categoryManager.CheckIncomeOfBudget(budget)
                && BudgetIsValid(budget))
            {
                return budget;
            }

            return newBudget;
        }
        return newBudget;

    }

    private IBudget TrimNamesOfBudget(IBudget budget)
    {
        foreach (Category expenseCategory in budget.Expenses)
        {
            foreach (Item item in expenseCategory.Items)
            {
                item.Name = item.Name?.Trim();
            }
            expenseCategory.Name = expenseCategory.Name?.Trim();
        }
        return budget;
    }

    public bool BudgetIsValid(IBudget budget)
    {
        List<string> invalidSqlExpressions = new List<string>() { "Delete", "Insert", "Into", "Alter", "Drop Table", "Select", "Create Database", "Truncate" };

        if (string.IsNullOrWhiteSpace(budget.Title))
        {
            throw new ArgumentException("Budgetname cannot be null, empty, or whitespace.");
        }

        if (budget.Title.Length > 50)
        {
            throw new ArgumentException("Budgetname cannot be longer then 50 characters.");
        }

        if (!char.IsLetterOrDigit(budget.Title[0]))
        {
            throw new ArgumentException("Budgetname cannot start with a special character.");
        }

        foreach (string sql in invalidSqlExpressions.Where(sql => budget.Title.ToLower().Contains(sql.ToLower())))
        {
            throw new ArgumentException(" Budgetname cannot contain any sql keywords! ");
        }

        // Regex: Each word must start with an alphanumeric character, underscore, or dash.
        Regex validNameRegex = new Regex(@"^[a-zåäöA-ZÅÄÖ0-9-&]+( [a-zåäöA-ZÅÄÖ0-9-&]+)*$", RegexOptions.None, TimeSpan.FromMilliseconds(2000));

        if (!validNameRegex.IsMatch(budget.Title))
        {
            throw new ArgumentException("Budgetname contains invalid characters.");
        }

        CheckBudgetDescription(budget);



        return true;
    }

    private void CheckBudgetDescription(IBudget budget)
    {
        List<string> invalidSqlExpressions = new List<string>() { "Delete", "Insert", "Into", "Alter", "Drop Table", "Select", "Create Database", "Truncate" };

        if (budget.Description != null)
        {
            foreach (string sql in invalidSqlExpressions.Where(sql => budget.Description.ToLower().Contains(sql.ToLower())))
            {
                throw new ArgumentException(" Budget Description cannot contain any sql keywords! ");
            }
        }  
    }

    public static BudgetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                ICategoryManager categoryManager = new CategoryManager();
                IItemManager itemManager = new ItemManager();
                _instance = new BudgetManager(categoryManager, itemManager);
            }
            return _instance;
        }
    }
}
