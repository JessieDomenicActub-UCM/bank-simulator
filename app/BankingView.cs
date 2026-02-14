namespace ATMApp.View
{

    public class BankingView
    {
        public static void Run()
        {
            ATMApp.Service.BankingService service = new ATMApp.Service.BankingService();
            double accountBalance = 1000.0; 
            bool isRunning = true;

            Console.WriteLine("Jessie Domenic B. Actub"); 
            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine("Initial Balance: " + accountBalance); 
            
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
                        Console.WriteLine("Current Balance: " + current);
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        double dAmount = Convert.ToDouble(Console.ReadLine());
                        if (dAmount > 0) 
                        {
                    
                            service.Deposit(ref accountBalance, dAmount);
                            Console.WriteLine("Deposit successful.");
                            Console.WriteLine("Updated Balance: " + accountBalance);
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            continue; 
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        double wAmount = Convert.ToDouble(Console.ReadLine());
                        if (wAmount > 0)
                        {
                          
                            bool success;
                            service.Withdraw(ref accountBalance, wAmount, out success);
                            if (success)
                            {
                                Console.WriteLine("Withdrawal successful.");
                                Console.WriteLine("Updated Balance: " + accountBalance);
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
                        Console.WriteLine("Current Balance: " + accountBalance);
                        Console.WriteLine("Last Transaction Amount: " + last);
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
