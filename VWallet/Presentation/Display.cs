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
            sb.ToString();
            Console.WriteLine(sb);
        }

        public string GetCommand()
        {
            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine().ToLower().Trim();

            choice = string.Join(" ", choice.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            return choice;
        }

        public string GetRecipeName()
        {
            Console.Write("\nName: ");

            string RecipeName = Console.ReadLine().Trim();

            return RecipeName;
        }

        public string GetRating()
        {
            Console.Write("Enter rating between 0 and 5: ");
            string rating = Console.ReadLine();
            return rating;
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
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}