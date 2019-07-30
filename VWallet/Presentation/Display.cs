﻿using System;
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
            var choice = 0;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw;
            }
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

    }
}