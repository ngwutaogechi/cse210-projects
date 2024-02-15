using System;
using System.Collections.Generic;

// Abstract base class for transactions
abstract class Transaction
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction(string description, decimal amount, DateTime date)
    {
        Description = description;
        Amount = amount;
        Date = date;
    }

    // Abstract method to be implemented by derived classes
    public abstract string GetTransactionType();
}

// Expense class derived from Transaction
class Expense : Transaction
{
    public string Category { get; set; }

    public Expense(string description, decimal amount, DateTime date, string category) : base(description, amount, date)
    {
        Category = category;
    }

    public override string GetTransactionType()
    {
        return "Expense";
    }
}

// Income class derived from Transaction
class Income : Transaction
{
    public Income(string description, decimal amount, DateTime date) : base(description, amount, date)
    {
    }

    public override string GetTransactionType()
    {
        return "Income";
    }
}

// Budget class to set and manage budgets
class Budget
{
    public string Category { get; set; }
    public decimal Amount { get; set; }

    public Budget(string category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}

// FinanceManager class to manage transactions and budgets
class FinanceManager
{
    private List<Transaction> transactions = new List<Transaction>();
    private List<Budget> budgets = new List<Budget>();

    // Method to add a transaction
    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    // Method to add a budget
    public void AddBudget(Budget budget)
    {
        budgets.Add(budget);
    }

    // Method to generate a report
    public void GenerateReport()
    {
        Console.WriteLine("Transaction Report:");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.GetTransactionType()}: {transaction.Description}, Amount: {transaction.Amount}");
        }

        Console.WriteLine("\nBudget Report:");
        foreach (Budget budget in budgets)
        {
            Console.WriteLine($"Category: {budget.Category}, Amount: {budget.Amount}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FinanceManager financeManager = new FinanceManager();

        // Adding transactions
        financeManager.AddTransaction(new Expense("Groceries", 50.00m, DateTime.Now, "Food"));
        financeManager.AddTransaction(new Expense("Shopping", 100.00m, DateTime.Now, "Personal"));
        financeManager.AddTransaction(new Income("Salary", 2000.00m, DateTime.Now));

        // Adding budgets
        financeManager.AddBudget(new Budget("Food", 300.00m));
        financeManager.AddBudget(new Budget("Personal", 200.00m));

        // Generating report
        financeManager.GenerateReport();
    }
}
