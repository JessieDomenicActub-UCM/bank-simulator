namespace ATMApp.Service
{
    public class BankingServices
    {
        private double lastTransaction = 0;

        public double GetBalance(double balance) 
        {
            return balance;
        }

        public void Deposit(ref double balance, double amount)
        {
            balance = balance + amount;
            lastTransaction = amount;
        }

        public void Withdraw(ref double balance, double amount, out bool success)
        {
            if (amount <= balance)
            {
                balance = balance - amount;
                lastTransaction = amount;
                success = true;
            }
            else
            {
                success = false;
            }
        }

        public double GetLastTransaction()
        {
            return lastTransaction;
        }
    }
}
