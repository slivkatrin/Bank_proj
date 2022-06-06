using System;
namespace Bank
{
    public class Account
    {
        private string name;
        private int number;
        private string password;
        private int accBalance = 0;
        public int credit = 0;
        public bool isBlocked;
        private Bank bank;
        public bool userLogin = true;
        

        public Account(Bank Currbank, string holderName, string logPassword, int accNumber)
        {
            name = holderName;
            password = logPassword;
            number = accNumber;
            bank = Currbank;
        }

        public void payMoney()
        {
            Console.WriteLine("Input the amount which you want to pay: ");
            int moneyPayed = int.Parse(Console.ReadLine());
            accBalance += moneyPayed;
            Console.WriteLine("Your balance: {0}", accBalance);
            if (moneyPayed > 10000)
            Console.WriteLine("\n\x1b[1m The police was informed to the matter\x1b[0m ");
            bank.history.Add(new AccHistory(AccHistory.type.payment, number, 0, moneyPayed));
        }

        public bool withdrawMoney(int amount) //метод используется для перевода денег 
        {
            if (amount <= accBalance)
            {
                accBalance -= amount;
                return true;
            }
            return false;
        }

        public void payMoney(int amount) //используется банком чтобы добавить $
        {
            accBalance += amount;
        }

        public void withdrawMoney()
        {
            Console.WriteLine("Input the amount which you want to withdraw: ");
            int moneyWithdraw = int.Parse(Console.ReadLine());

            if (accBalance - moneyWithdraw < 0)
            {
                Console.WriteLine("Not enough money");
                return;
            }
            accBalance -= moneyWithdraw;
            Console.WriteLine("\nYour balance: {0}", accBalance);
            bank.history.Add(new AccHistory(AccHistory.type.withdraw, number, 0, moneyWithdraw));
        }

        public int getNumber() //контроль над доступом
        {
            return number;
        }

        public int getBalance() //контроль над доступом
        {
            return accBalance;
        }

        public void sendTransfer()
        {
            Console.WriteLine("Input the amount which you want to transfer: ");
            int transferAmount = int.Parse(Console.ReadLine());
            if (accBalance - transferAmount < 0)
            {
                Console.WriteLine("Not enough money");
                return;
            }
            Console.WriteLine("Input the beneficiary account number: ");
            int beneficiaryAcc = int.Parse(Console.ReadLine());
            bank.transfer(this.number, beneficiaryAcc, transferAmount);
            bank.history.Add(new AccHistory(AccHistory.type.transfer, number, beneficiaryAcc, transferAmount));
            Console.WriteLine("\nYour balance: {0}", accBalance);
        }

        public bool chceckPassword(string inpPassword)
        {
            if (inpPassword == password)
            {
                return true;
            }
            return false;
            //комуникат
        }

            public void takeCredit()
        {
            if (credit == 0)
            {
                Console.WriteLine("Input the amount of credit: ");
                int creditAmount = int.Parse(Console.ReadLine());
                accBalance += creditAmount;
                credit += creditAmount; //только сумма кредита в переменной кредит
                bank.history.Add(new AccHistory(AccHistory.type.creditGot, 0, number, creditAmount));
                Console.WriteLine("\nYour balance: {0}", accBalance);
            }
            else if (credit >0)
            {
                Console.WriteLine("You need to pay for your last credit");
            }
        }

        public void payCredit()
        {
            if (credit>0)
            {
                Console.WriteLine("Input the amount of credit to pay: ");
                int creditPayAmount = int.Parse(Console.ReadLine());

                if (accBalance < creditPayAmount)
                {
                    Console.WriteLine("Not enough money");
                    return;
                }

                if (creditPayAmount > credit)
                {
                    Console.WriteLine("Amount is bigger than credit");
                }

                if (accBalance>= creditPayAmount)
                {
                    accBalance -= creditPayAmount;
                    credit -= creditPayAmount;
                    bank.history.Add(new AccHistory(AccHistory.type.creditPayed, number, 0, creditPayAmount));
                }
            }
        }
        public void accHistory()
        {
            foreach (AccHistory history in bank.history)
            {
                if (history.sender == number || history.receiver == number)
                {
                    Console.WriteLine("==");
                    history.print();
                    Console.WriteLine(history.oppAmount);
                }
            }
        }
    }
}
