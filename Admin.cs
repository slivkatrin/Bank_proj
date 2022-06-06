using System;
namespace Bank
{
    public class Admin
    {
        Bank bank;
        public bool adminLogin = true;

        public Admin(Bank CurBank)
        {
            bank = CurBank;
        }
        public void addAccount()
        {
            Console.WriteLine("Enter account holder name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your account password:");
            string accPassword = Console.ReadLine();

            Console.WriteLine("Enter your account number:");
            int accNumber = int.Parse(Console.ReadLine());
            if (bank.addAccount(name, accPassword, accNumber))
            Console.WriteLine("\nAccount {0} with password {1} and number {2} was added", name, accPassword, accNumber);
        }
        public void delAccount()
        {
            Console.WriteLine("Enter account number which you want to delete:");
            int accToDel = int.Parse(Console.ReadLine());
            bank.deleteAccount(accToDel);
        }
        public void blockAccount()
        {
            Console.WriteLine("Enter account number which you want to block:");
            int accToBlock = int.Parse(Console.ReadLine());
            bank.blockAccount(accToBlock);
        }
        public void unblockAccount()
        {
            Console.WriteLine("Enter account number which you want to unblock:");
            int accToUnblock = int.Parse(Console.ReadLine());
            bank.unblockAccount(accToUnblock);
        }
    }

}
