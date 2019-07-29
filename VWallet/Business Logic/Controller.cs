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

        private Display display = new Display();
        private string OutputMessage;
        private int GivenCommand;
        public void Start()
        {
            display.WelcomeScreen();
            while (true)
            {
                GivenCommand = display.GetCommand();
                switch (GivenCommand)
                {
                    case 1:
                        DepositOption();
                        break;
                    case 2:
                        //ExpenseOption; TODO
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
            IncomeDescriptionRead();
            OutputMessage = "\nPress any key to go back to Deposit menu...";
            display.PrintResult(OutputMessage);
            Console.ReadKey();
            DepositOption();
        }

        private string IncomeDescriptionRead()
        {
            int ParagraphCount = 1;
            int validator = 0;
            string FinishedDescription = null;
            StringBuilder sb = new StringBuilder();
            do
            {
                string GivenDescription = display.GetIncomeDescription();

                validator = ValidateIncomeDescription(GivenDescription, ParagraphCount);

                if (validator == 1)
                {
                    OutputMessage = "Successfully added description to income!";
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
        private int ValidateIncomeDescription(string GivenDescription, int ParagraphCount)
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
        private void EscapeToMain()
        { 
            display.ReturnToMainMenuScreen();
            Start();
        }
    }
}
