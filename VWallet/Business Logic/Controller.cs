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
        private WalletStatistics TotalSumOfAccount;

        public void Start()
        {
            display.WelcomeScreen();
            TotalSumOfAccount = context.WalletStatistics.Single(x => x.Name == "Total amount");
            OutputMessage = $"\nCurrent balance: {TotalSumOfAccount.Count:f2}BGN";
            Console.ForegroundColor = ConsoleColor.Cyan;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            while (true)
            {
                try
                {
                    GivenCommand = display.GetCommand();
                    if (GivenCommand> 0 && GivenCommand <6)
                    {
                        break;
                    }
                }
                catch
                {
                    OutputMessage = "Invalid choice of option!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
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
                    ShowStatistics();
                    break;
                case 4:
                    ResetBalance();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    OutputMessage = "Invalid choice of option!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                    break;
            }
        }

        private void DepositOption()
        {
            display.DepositOptionInterface();
            while (true)
            {
                try
                {
                    GivenCommand = display.GetCommand();
                    if(GivenCommand==1 || GivenCommand==2)
                    {
                        break;
                    }
                }
                catch
                {
                    OutputMessage = "Invalid choice of income entry!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
            }
            switch (GivenCommand)
            {
                case 1:
                    DepositValue();
                    break;
                case 2:
                    EscapeToMain();
                    break;
                default:
                    OutputMessage = "Invalid choice of income entry!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                    break;
            }
        }

        private void DepositValue()
        {
            double GivenValue =0;
            while (true)
            {
                try
                {
                    GivenValue = display.GetValue();
                    if (GivenValue <= 0)
                    {
                        OutputMessage = "You cannot deposit value less or equal to 0";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                    }
                    if(GivenValue>0)
                    {
                        break;
                    }
                }
                catch
                {
                    OutputMessage = "Invalid entry of value!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
            }
            OutputMessage = $"Successfully deposited {GivenValue:f2} BGN into your account!";
            Console.ForegroundColor = ConsoleColor.Green;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            string FinishedDescription= DescriptionRead();
            string FinishedType= IncomeTypeNameRead();
            Type TypeOfIncome = context.Types.Single(x => x.NameOfType == FinishedType);
            Income income = new Income(FinishedDescription, GivenValue, TypeOfIncome.Id);
            context.Incomes.Add(income);
            TotalSumOfAccount.Count += GivenValue;
            context.SaveChanges();
            EscapeToMain();
        }

        private void ExpenseOption()
        {
            display.ExpenseOptionInterface();
            while (true)
            {
                try
                {
                    GivenCommand = display.GetCommand();
                    if (GivenCommand == 1 || GivenCommand == 2)
                    {
                        break;
                    }
                    else
                    {
                        OutputMessage = "Invalid choice of expense!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                    }
                }
                catch
                {
                    OutputMessage = "Invalid choice of expense!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
            }
            switch (GivenCommand)
                {
                    case 1:
                        ExpenseValue();
                        break;
                    case 2:
                        EscapeToMain();
                        break;
                    default:
                        OutputMessage = "Invalid choice of expense!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        break;
                }
        }

        private void ExpenseValue()
        {
            double GivenValue = 0;
            double CheckBalanceAfterExpense = 0;
            while (true)
            {
                try
                {
                    GivenValue = display.GetValue();
                    while (GivenValue <= 0)
                    {
                        OutputMessage = "You cannot expend value less or equal to 0";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        GivenValue = display.GetValue();
                    }
                    CheckBalanceAfterExpense = TotalSumOfAccount.Count - GivenValue;
                    while (CheckBalanceAfterExpense < 0)
                    {
                        OutputMessage = "Your balance cannot be below 0BGN";
                        Console.ForegroundColor = ConsoleColor.Red;
                        display.PrintResult(OutputMessage);
                        Console.ResetColor();
                        GivenValue = display.GetValue();
                        CheckBalanceAfterExpense = TotalSumOfAccount.Count - GivenValue;
                    }
                    break;
                }
                catch
                {
                    OutputMessage = "Invalid input!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
            }
            OutputMessage = $"Successfully taken {GivenValue:f2} BGN from your account!";
            Console.ForegroundColor = ConsoleColor.Yellow;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            string FinishedDescription = DescriptionRead();
            string FinishedType = ExpenseTypeNameRead();
            Type TypeOfExpense = context.Types.Single(x => x.NameOfType == FinishedType);
            Expense income = new Expense(FinishedDescription, GivenValue, TypeOfExpense.Id);
            context.Expenses.Add(income);
            TotalSumOfAccount.Count -= GivenValue;
            context.SaveChanges();
            EscapeToMain();
        }

        private string ExpenseTypeNameRead()
        {
            string TypeName = null;
            display.GetExpenseTypeInterface();
            int GivenTypeNumber = 0;
            while (GivenTypeNumber < 1 || GivenTypeNumber > 7)
            {
                try
                {
                    GivenTypeNumber = display.GetIncomeType();
                    if (GivenTypeNumber > 0 && GivenTypeNumber < 8)
                    {
                        break;
                    }
                    OutputMessage = "Please enter a valid type!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();

                }
                catch
                {
                    OutputMessage = "Please enter a valid type!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
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
                    TypeName = "Other expenses";
                    break;
                default:
                    OutputMessage = "Invalid choice of expense type!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
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
            int GivenTypeNumber = 0;
            while(GivenTypeNumber<1 || GivenTypeNumber>7)
            {
                try
                {
                    GivenTypeNumber = display.GetIncomeType();
                    if (GivenTypeNumber> 0 && GivenTypeNumber <8)
                    {
                        break;
                    }
                    OutputMessage = "Please enter a valid type!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                    
                }
                catch
                {
                    OutputMessage = "Please enter a valid type!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                }
            }

            switch (GivenTypeNumber)
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
                    TypeName = "Other incomes";
                    break;
                default:
                    OutputMessage = "Invalid type entry!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    display.PrintResult(OutputMessage);
                    Console.ResetColor();
                    break;
            }
            
            OutputMessage = "Successfully added type of income!";
            Console.ForegroundColor = ConsoleColor.Green;
            display.PrintResult(OutputMessage);
            Console.ResetColor();
            return TypeName;
        }

        private void ShowStatistics()
        {
            double FamilyCounter = 0, JobCounter=0, SalesCounter=0, TradingCounter=0, ServicesCounter=0, OnlineCounter=0, OtherIncomeCounter=0;
            double FoodDrinksCounter = 0, FunCounter = 0, GamesCounter = 0, ShoppingCounter = 0, FinancialCounter = 0, VehicleCounter = 0, OtherExpenseCounter = 0;
            double total = 0;
            foreach(Income income in context.Incomes)
            {
                if(income.TypeId==1)
                {
                    FamilyCounter+=income.Value;
                    total += income.Value;
                }
                else if (income.TypeId==2)
                {
                    JobCounter += income.Value;
                    total += income.Value;
                }
                else if (income.TypeId == 3)
                {
                    SalesCounter += income.Value;
                    total += income.Value;
                }
                else if (income.TypeId == 4)
                {
                    TradingCounter += income.Value;
                    total += income.Value;
                }
                else if (income.TypeId == 5)
                {
                    ServicesCounter += income.Value;
                    total += income.Value;
                }
                else if (income.TypeId == 6)
                {
                    OnlineCounter += income.Value;
                    total += income.Value;
                }
                else if (income.TypeId == 7)
                {
                    OtherIncomeCounter += income.Value;
                    total += income.Value;
                }
            }
            display.ShowStatisticsInterfaceIncomes(FamilyCounter, JobCounter, SalesCounter, TradingCounter, ServicesCounter, OnlineCounter, OtherIncomeCounter, total);
            total = 0;
            foreach (Expense expense in context.Expenses)
            {
                if (expense.Type_id == 8)
                {
                    FoodDrinksCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 9)
                {
                    FunCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 10)
                {
                    GamesCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 11)
                {
                    ShoppingCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 12)
                {
                    FinancialCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 13)
                {
                    VehicleCounter += expense.Value;
                    total += expense.Value;
                }
                else if (expense.Type_id == 14)
                {
                    OtherExpenseCounter += expense.Value;
                    total += expense.Value;
                }
            }
            display.ShowStatisticsInterfaceExpenses(FoodDrinksCounter, FunCounter, GamesCounter, ShoppingCounter, FinancialCounter, VehicleCounter, OtherExpenseCounter, total);
            EscapeToMain();
        }

        private void ResetBalance()
        {
            display.WarningMessageForReset();
            string answer = display.GetResetAnswer().ToLower();
            while(answer!="y" && answer!="n")
            {
                OutputMessage = "Please enter a valid answer!";
                Console.ForegroundColor = ConsoleColor.Red;
                display.PrintResult(OutputMessage);
                Console.ResetColor();
                answer = display.GetResetAnswer();
            }
            if (answer == "y")
            {
                TotalSumOfAccount.Count = 0;
                foreach (Income income in context.Incomes)
                {
                    context.Incomes.Remove(income);
                }
                foreach(Expense expense in context.Expenses)
                {
                    context.Expenses.Remove(expense);
                }
                Console.WriteLine($"Account balance updated to {TotalSumOfAccount.Count:f2} BGN");
                context.SaveChanges();
                EscapeToMain();
            }
            if(answer == "n")
            {
                EscapeToMain();
            }
        }

        private void EscapeToMain()
        { 
            display.ReturnToMainMenuScreen();
            Start();
        }
    }
}
