using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VWallet;

namespace VWallet
{
    public class Controller
    {
        private VWalletContext context = new VWalletContext();
        private Display display = new Display();
        private string OutputMessage;
        private int GivenCommand;
        //TODO Statistics + SUM
        public void Start()
        {
            display.WelcomeScreen();
            while (true)
            {
                try
                {
                    GivenCommand = display.GetCommand();
                }
                catch (FormatException)
                {

                    GivenCommand = 10;
                }
                switch (GivenCommand)
                {
                    case 1:
                        DepositOption();
                        break;
                    case 2:
                        ExpenseOption();
                        break;
                    case 3:
                        //StatisticsOption; TODO
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        OutputMessage = "Invalid choice!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        break;

                }
                
            }
        }

        private void DepositOption()
        {
            display.DepositOptionInterface();
            while (true)
            {
                GivenCommand = display.GetCommand();
                switch (GivenCommand)
                {
                    case 1:
                        DepositValue();
                        break;
                    case 2:
                        EscapeToMain();
                        break;
                    default:
                        OutputMessage = "Invalid choice!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void DepositValue()
        {
            double GivenValue = display.GetValue();
            while (GivenValue <= 0)
            {
                OutputMessage = "You cannot deposit value less or equal to 0";
                Console.ForegroundColor = ConsoleColor.Red;
                display.PrintResult(OutputMessage);
                Console.ResetColor();
                GivenValue = display.GetValue();
            }
            OutputMessage = $"Successfully deposited {GivenValue} BGN into your account!";
            Console.ForegroundColor = ConsoleColor.Green;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            string FinishedDescription= DescriptionRead();
            string FinishedType= IncomeTypeNameRead();
            Type TypeOfIncome = context.Types.Single(x => x.NameOfType == FinishedType);
            Income income = new Income(FinishedDescription, GivenValue, TypeOfIncome.Id);
            context.Incomes.Add(income);
            context.SaveChanges();
            OutputMessage = "\nPress any key to go back to Deposit menu...";
            display.PrintResult(OutputMessage);
            Console.ReadKey();
            DepositOption();
        }

        private void ExpenseOption()
        {
            display.ExpenseOptionInterface();
            while (true)
            {
                GivenCommand = display.GetCommand();
                switch (GivenCommand)
                {
                    case 1:
                        ExpenseValue();
                        break;
                    case 2:
                        EscapeToMain();
                        break;
                    default:
                        OutputMessage = "Invalid choice!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void ExpenseValue()
        {
            double GivenValue = display.GetValue();
            while (GivenValue <= 0)
            {
                OutputMessage = "You cannot expend value less or equal to 0";
                Console.ForegroundColor = ConsoleColor.Red;
                display.PrintResult(OutputMessage);
                Console.ResetColor();
                GivenValue = display.GetValue();
            }
            OutputMessage = $"Successfully taken {GivenValue} BGN from your account!";
            Console.ForegroundColor = ConsoleColor.Yellow;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            string FinishedDescription = DescriptionRead();
            string FinishedType = ExpenseTypeNameRead();
            Type TypeOfExpense = context.Types.Single(x => x.NameOfType == FinishedType);
            Expense income = new Expense(FinishedDescription, GivenValue, TypeOfExpense.Id);
            context.Expenses.Add(income);
            context.SaveChanges();
            OutputMessage = "\nPress any key to go back to Expense menu...";
            display.PrintResult(OutputMessage);
            Console.ReadKey();
            DepositOption();
        }

        private string ExpenseTypeNameRead()
        {
            string TypeName = null;
            display.GetExpenseTypeInterface();
            int GivenTypeNumber = display.GetIncomeType();
            while (GivenTypeNumber < 1 || GivenTypeNumber > 7)
            {
                OutputMessage = "Please enter a valid type!";
                Console.ForegroundColor = ConsoleColor.Red;
                display.PrintResult(OutputMessage);
                Console.ResetColor();
                GivenTypeNumber = display.GetIncomeType();
            }
            switch (GivenTypeNumber)
            {
                case 1:
                    TypeName = "Food & Drinks";
                    break;
                case 2:
                    TypeName = "Fun";
                    break;
                case 3:
                    TypeName = "Games";
                    break;
                case 4:
                    TypeName = "Shopping";
                    break;
                case 5:
                    TypeName = "Financial expenses";
                    break;
                case 6:
                    TypeName = "Vehicle";
                    break;
                case 7:
                    TypeName = "Other";
                    break;
            }
            OutputMessage = "Successfully added type of expense!";
            Console.ForegroundColor = ConsoleColor.Yellow;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            return TypeName;
        }

        private string DescriptionRead()
        {
            int ParagraphCount = 1;
            int validator = 0;
            string FinishedDescription = null;
            StringBuilder sb = new StringBuilder();
            do
            {
                string GivenDescription = display.GetIncomeDescription();

                validator = ValidateDescription(GivenDescription, ParagraphCount);

                if (validator == 1)
                {
                    OutputMessage = "Successfully added description!";
                }
                else if (validator == -1 || validator == 0)
                {
                    OutputMessage = "Please enter a valid paragraph!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                    continue;
                }

                sb.Append(GivenDescription + "\n");
                ParagraphCount++;

            } while (validator != 1);
            FinishedDescription = sb.ToString();
            FinishedDescription = FinishedDescription.Remove(FinishedDescription.Length - 2);
            Console.ForegroundColor = ConsoleColor.Green;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            return FinishedDescription;
        }

        private int ValidateDescription(string GivenDescription, int ParagraphCount)
        {
            if (string.IsNullOrEmpty(GivenDescription))
            {
                return -1;
            }
            else if (GivenDescription.Equals("#") && ParagraphCount == 1)
            {
                return 0;
            }
            else if (GivenDescription.EndsWith("#"))
            {
                return 1;
            }
            return 2;
        }

        private string IncomeTypeNameRead()
        {
            string TypeName = null;
            display.GetIncomeTypeInterface();
            int GivenTypeNumber = display.GetIncomeType();
            while(GivenTypeNumber<1 || GivenTypeNumber>7)
            {
                OutputMessage = "Please enter a valid type!";
                Console.ForegroundColor = ConsoleColor.Red;
                display.PrintResult(OutputMessage);
                Console.ResetColor();
                GivenTypeNumber = display.GetIncomeType();
            }
            switch(GivenTypeNumber)
            {
                case 1:
                    TypeName = "Family";
                    break;
                case 2:
                    TypeName = "Job";
                    break;
                case 3:
                    TypeName = "Sales";
                    break;
                case 4:
                    TypeName = "Trading";
                    break;
                case 5:
                    TypeName = "Services";
                    break;
                case 6:
                    TypeName = "Online";
                    break;
                case 7:
                    TypeName = "Other";
                    break;
            }
            OutputMessage = "Successfully added type of income!";
            Console.ForegroundColor = ConsoleColor.Green;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            return TypeName;
        }

        private void EscapeToMain()
        { 
            display.ReturnToMainMenuScreen();
            Start();
        }
    }
}
