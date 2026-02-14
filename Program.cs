using System;
using ATMApp.Service;

namespace ATMApp.View
{
    public class BankingView
    {
        public static void Run()
        {
            BankingService service = new BankingService();
            double accountBalance = 1000.00; 
            bool isRunning = true;

            Console.WriteLine("Jeremy Andy Ampatin");
            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine($"Initial Balance: P{accountBalance:N2}");

            while (isRunning) 
            {
                Console.WriteLine("\n1: Check Balance");
                Console.WriteLine("2: Deposit Money");
                Console.WriteLine("3: Withdraw Money");
                Console.WriteLine("4: Print Mini Statement");
                Console.WriteLine("5: Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        double current = service.GetBalance(accountBalance);
                        Console.WriteLine($"Current Balance: P{current:N2}");
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        if (double.TryParse(Console.ReadLine(), out double dAmount) && dAmount > 0)
                        {
                            service.Deposit(ref accountBalance, dAmount);
                            Console.WriteLine("Deposit successful.");
                            Console.WriteLine($"Updated Balance: P{accountBalance:N2}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            continue; 
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        if (double.TryParse(Console.ReadLine(), out double wAmount) && wAmount > 0)
                        {
                            service.Withdraw(ref accountBalance, wAmount, out bool success);
                            if (success)
                            {
                                Console.WriteLine("Withdrawal successful.");
                                Console.WriteLine($"Updated Balance: P{accountBalance:N2}");
                            }
                            else
                            {
                                Console.WriteLine("Withdrawal failed. Insufficient balance.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                            continue;
                        }
                        break;

                    case "4":
                        double last = service.GetLastTransaction();
                        Console.WriteLine("--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: P{accountBalance:N2}");
                        Console.WriteLine($"Last Transaction Amount: P{last:N2}");
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        isRunning = false; 
                        break;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            }
        }
    }
}
