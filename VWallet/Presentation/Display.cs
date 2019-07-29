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
            StringBuilder sb = new StringBuilder();
            sb.Append('=',120);
            sb.Append(' ', 52);
            sb.AppendLine("Welcome to VWallet!");
            sb.Append('=', 120);
            sb.Append("\n\nOptions:");
            sb.Append("\n1.Register Income");
            sb.Append("\n2.Register Expense");
            sb.Append("\n3.Show Statistics");
            sb.Append("\n4.Exit");
            Console.WriteLine(sb.ToString());
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
        public string GetIncomeDescription()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            return description;
        }
        public double GetValue()
        {
            Console.Write("\nEnter a value: ");
            double value = double.Parse(Console.ReadLine());
            return value;
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

    }
}