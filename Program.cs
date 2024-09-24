using Expense_Tracker;
using Newtonsoft.Json;

class Program
{
    private static readonly string expenseFile = "expenses.json";

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nExpense Tracker Commands:");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. Update Expense");
            Console.WriteLine("3. Delete Expense");
            Console.WriteLine("4. List Expenses");
            Console.WriteLine("5. Show Summary");
            Console.WriteLine("6. Show Summary for Month");
            Console.WriteLine("0. Exit");

            Console.Write("\nSelect a command: ");
            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    AddExpense();
                    break;
                case "2":
                    UpdateExpense();
                    break;
                case "3":
                    DeleteExpense();
                    break;
                case "4":
                    ListExpenses();
                    break;
                case "5":
                    ShowSummary();
                    break;
                case "6":
                    ShowSummaryForMonth();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }
    }

    static void AddExpense()
    {
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
        {
            Console.WriteLine("Invalid amount. Try again.");
            return;
        }

        var expenses = LoadExpenses();
        int newId = expenses.Count > 0 ? expenses.Max(e => e.Id) + 1 : 1;
        expenses.Add(new Expense { Id = newId, Description = description, Amount = amount, Date = DateTime.Now });
        SaveExpenses(expenses);
        Console.WriteLine($"Expense added successfully (ID: {newId})");
    }

    static void UpdateExpense()
    {
        Console.Write("Enter expense ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Try again.");
            return;
        }

        var expenses = LoadExpenses();
        var expense = expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            Console.Write("Enter new description: ");
            string description = Console.ReadLine();
            Console.Write("Enter new amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount. Try again.");
                return;
            }

            expense.Description = description;
            expense.Amount = amount;
            SaveExpenses(expenses);
            Console.WriteLine($"Expense (ID: {id}) updated successfully.");
        }
        else
        {
            Console.WriteLine("Expense not found.");
        }
    }

    static void DeleteExpense()
    {
        Console.Write("Enter expense ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Try again.");
            return;
        }

        var expenses = LoadExpenses();
        var expense = expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            expenses.Remove(expense);
            SaveExpenses(expenses);
            Console.WriteLine("Expense deleted successfully.");
        }
        else
        {
            Console.WriteLine("Expense not found.");
        }
    }

    static void ListExpenses()
    {
        var expenses = LoadExpenses();
        Console.WriteLine($"{"ID",-5} {"Date",-12} {"Description",-20} {"Amount",10}");
        foreach (var expense in expenses)
        {
            Console.WriteLine($"{expense.Id,-5} {expense.Date.ToShortDateString(),-12} {expense.Description,-20} {expense.Amount,10:C}");
        }
    }

    static void ShowSummary()
    {
        var expenses = LoadExpenses();
        decimal totalExpenses = expenses.Sum(e => e.Amount);
        Console.WriteLine($"Total expenses: {totalExpenses:C}");
    }

    static void ShowSummaryForMonth()
    {
        Console.Write("Enter month (1-12): ");
        if (!int.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12)
        {
            Console.WriteLine("Invalid month. Try again.");
            return;
        }

        var expenses = LoadExpenses();
        var filteredExpenses = expenses.Where(e => e.Date.Month == month && e.Date.Year == DateTime.Now.Year).ToList();
        decimal totalMonthExpenses = filteredExpenses.Sum(e => e.Amount);
        Console.WriteLine($"Total expenses for month {month}: {totalMonthExpenses:C}");
    }

    static List<Expense> LoadExpenses()
    {
        if (!File.Exists(expenseFile))
        {
            return [];
        }

        var json = File.ReadAllText(expenseFile);
        return JsonConvert.DeserializeObject<List<Expense>>(json) ?? [];
    }

    static void SaveExpenses(List<Expense> expenses)
    {
        var json = JsonConvert.SerializeObject(expenses, Formatting.Indented);
        File.WriteAllText(expenseFile, json);
    }
}