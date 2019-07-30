using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWallet
{
    public class Display
    {
        public Display()
        {

        }

        public void WelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();
            sb.Append('=',120);
            sb.Append(' ', 52);
            sb.AppendLine("Welcome to VWallet!");
            sb.Append('=', 120);
            sb.Append("\n\nOptions:");
            sb.Append("\n1. Register Income");
            sb.Append("\n2. Register Expense");
            sb.Append("\n3. Show Statistics");
            sb.Append("\n4. Reset balance");
            sb.Append("\n5. Exit");
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }

        public int GetCommand()
        {
            Console.Write("\nChoose an option: ");
            //var choice = Console.ReadLine().ToLower().Trim();
            //choice = string.Join(" ", choice.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            var choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public void PrintResult(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }

        public void ReturnToMainMenuScreen()
        {
            Console.Write("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public int GetIncomeType()
        {
            Console.Write("\nEnter a type: ");
            var choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public string GetIncomeDescription()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            return description;
        }

        public void GetIncomeTypeInterface()
        {
            Console.WriteLine("Choose type of income:");
            Console.WriteLine("1.Family");
            Console.WriteLine("2.Job");
            Console.WriteLine("3.Sales");
            Console.WriteLine("4.Trading");
            Console.WriteLine("5.Services");
            Console.WriteLine("6.Online");
            Console.WriteLine("7.Other");
        }

        public double GetValue()
        {
            Console.Write("\nEnter a value: ");
            double value = double.Parse(Console.ReadLine());
            return value;
        }

        public void WarningMessageForReset()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append('=', 120);
            sb.Append(' ', 52);
            sb.AppendLine("Reset account balance");
            sb.Append('=', 120);
            Console.WriteLine(sb.ToString());
        }

        public string GetResetAnswer()
        {
            Console.Write("\nAre you sure you want to erase all account records?(Y/N): ");
            string answer = Console.ReadLine().Trim().ToLower();
            return answer;
        }

        public void DepositOptionInterface()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append('=', 120);
            sb.Append(' ', 52);
            sb.AppendLine("Register an Income");
            sb.Append('=', 120);
            sb.Append("\n\nOptions:");
            sb.Append("\n1.Deposit");
            sb.Append("\n2.Back to main menu");
            Console.WriteLine(sb.ToString());
        }

        public void ExpenseOptionInterface()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append('=', 120);
            sb.Append(' ', 52);
            sb.AppendLine("Register an Expense");
            sb.Append('=', 120);
            sb.Append("\n\nOptions:");
            sb.Append("\n1.Register Expense");
            sb.Append("\n2.Back to main menu");
            Console.WriteLine(sb.ToString());
        }

        public void GetExpenseTypeInterface()
        {
            Console.WriteLine("Choose type of income:");
            Console.WriteLine("1.Food & Drinks");
            Console.WriteLine("2.Fun");
            Console.WriteLine("3.Games");
            Console.WriteLine("4.Shopping");
            Console.WriteLine("5.Financial expenses");
            Console.WriteLine("6.Vehicle");
            Console.WriteLine("7.Other");
        }

        public void ShowStatisticsInterfaceIncomes(double Family, double Job, double Sales, double Trading, double Services, double Online, double OtherIncomeCounter, double Total)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();
            sb.Append('=', 120);
            sb.Append(' ', 52);
            sb.AppendLine("Statistics");
            sb.Append('=', 120);
            Console.WriteLine(sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Incomes");
            Console.ResetColor();

            Console.WriteLine("Type\t\tValue\t\t%/Total Incomes");

            Console.WriteLine("\nFamily\t\t" + Family + "BGN " + $"\t\t{(Family / Total) * 100:f2}" + "%");

            Console.WriteLine("\nJob\t\t" + Job + "BGN " + $"\t\t{(Job / Total) * 100:f2}" + "%");

            Console.WriteLine("\nSales\t\t" + Sales + "BGN " + $"\t\t{(Sales / Total) * 100:f2}" + "%");

            Console.WriteLine("\nTrading\t\t" + Trading + "BGN " + $"\t\t{(Trading / Total) * 100:f2}" + "%");

            Console.WriteLine("\nServices\t" + Services + "BGN " + $"\t\t{(Services / Total) * 100:f2}" + "%");

            Console.WriteLine("\nOnline\t\t" + Online + "BGN " + $"\t\t{(Online / Total) * 100:f2}" + "%");

            Console.WriteLine("\nOther\t\t" + OtherIncomeCounter + "BGN " + $"\t\t{(OtherIncomeCounter / Total) * 100:f2}" + "%");

            StringBuilder sbline = new StringBuilder();
            sbline.Append('-', 120);
            Console.Write(sbline.ToString());
            Console.ResetColor();
        }

        public void ShowStatisticsInterfaceExpenses(double FoodDrinks, double Fun, double Games, double Shopping, double Financial, double Vehicle, double OtherExpenseCounter, double Total)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Expenses");
            Console.ResetColor();

            Console.WriteLine("Type\t\tValue\t\t%/Total Expenses");

            Console.WriteLine("\nFoodDrinks\t" + FoodDrinks + "BGN " + $"\t\t{(FoodDrinks / Total) * 100:f2}" + "%");

            Console.WriteLine("\nFun\t\t" + Fun + "BGN " + $"\t\t{(Fun / Total) * 100:f2}" + "%");

            Console.WriteLine("\nGames\t\t" + Games + "BGN " + $"\t\t{(Games / Total) * 100:f2}" + "%");

            Console.WriteLine("\nShopping\t" + Shopping + "BGN " + $"\t\t{(Shopping / Total) * 100:f2}" + "%");

            Console.WriteLine("\nFinancial\t" + Financial + "BGN " + $"\t\t{(Financial / Total) * 100:f2}" + "%");

            Console.WriteLine("\nVehicle\t\t" + Vehicle + "BGN " + $"\t\t{(Vehicle / Total) * 100:f2}" + "%");

            Console.WriteLine("\nOther\t\t" + OtherExpenseCounter + "BGN " + $"\t\t{(OtherExpenseCounter / Total) * 100:f2}" + "%");

            Console.WriteLine();
            Console.ResetColor();
        }

    }
}