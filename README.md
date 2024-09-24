# Expense Tracker CLI Application

## Overview
The Expense Tracker is a simple command-line application written in C#. It allows users to manage their finances by adding, updating, deleting, and listing expenses. The application also provides a summary of total expenses or expenses for a specific month. Sample solution for the [Task Tracker](https://roadmap.sh/projects/expense-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

Expenses are stored in a JSON file and can be manipulated directly from the command line.

## Features
- **Add an Expense**: Add an expense with a description and amount.
- **Update an Expense**: Update the description and amount of an existing expense by its ID.
- **Delete an Expense**: Delete an expense by its ID.
- **List Expenses**: View all recorded expenses, including ID, date, description, and amount.
- **Summary of Expenses**: Get the total amount of all expenses.
- **Monthly Summary**: Get the total amount of expenses for a specific month of the current year.

## How to Run

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (Ensure you have installed the .NET SDK)

### Clone the repository

```bash
git clone https://github.com/your-username/expense-tracker-cli.git
cd expense-tracker-cli
```

### Build and Run the Application

1. Build the project:

```bash
dotnet build
```
2. Run the project:
```bash
dotnet run
```

### Example Usage
Once you run the program, you will be prompted with the following options:

```markdown
Expense Tracker Commands:
1. Add Expense
2. Update Expense
3. Delete Expense
4. List Expenses
5. Show Summary
6. Show Summary for Month
0. Exit
```


### Commands Overview
- Add Expense: Adds a new expense.

```mathematica
Select a command: 1
Enter description: Lunch
Enter amount: 20
Expense added successfully (ID: 1)
```

- List Expenses: Lists all added expenses with details.

```bash
Select a command: 4
ID    Date        Description         Amount
1     2024-09-24  Lunch               $20.00
```

- Update Expense: Updates an existing expense using its ID.

```mathematica
Select a command: 2
Enter expense ID to update: 1
Enter new description: Dinner
Enter new amount: 25
Expense (ID: 1) updated successfully.
```

- Delete Expense: Deletes an expense using its ID.

```mathematica
Select a command: 3
Enter expense ID to delete: 1
Expense deleted successfully.
```

- Summary of Expenses: Displays the total expenses.

```bash
Select a command: 5
Total expenses: $25.00
```

- Show Summary for a Specific Month: Displays the total expenses for a specified month of the current year.

```mathematica
Select a command: 6
Enter month (1-12): 9
Total expenses for month 9: $25.00
```

## Support My Work
If you enjoy my work or want to support what I do, feel free to [Buy Me a Coffee](https://buymeacoffee.com/marvynharry)!

## Contributing
Feel free to submit a pull request or report issues to help improve the project!

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For any questions or support, please reach out via [GitHub Issues](https://github.com/MarvynHarry/expense-tracker/issues).
