using System;
using System.Collections.Generic;

namespace Bank
{
    public class Bank
    {
        public List<Account> accounts;
        public List<AccHistory> history;

        public Bank()
        {
            accounts = new List<Account> ();
            history = new List<AccHistory>();
        }

        public void transfer(int from, int to, int amount)
        {
            Account fromA=null;
            Account toA=null; 
            foreach (Account account in accounts)
            {
                if(from == account.getNumber())
                {
                    fromA = account;
                }

                if (to == account.getNumber())
                {
                    toA = account;
                }
            }
            if( fromA != null && toA != null )
            {
                if (fromA.withdrawMoney(amount)) 
                    toA.payMoney(amount);
            }

        }
        public void deleteAccount(int accToDel)
        {
            Account todel = null;

                foreach (Account account in accounts)
            {
                if (accToDel == account.getNumber())
                {
                    todel = account;
                    Console.WriteLine("Account: {0} was deleted", account.getNumber());
                    break;
                }

            }
            if (todel != null)
            {
                accounts.Remove(todel);
            }
        }

        public void blockAccount(int accToBlock)
        {
            Account toBlock = null;

            foreach (Account account in accounts)
            {
                if (accToBlock == account.getNumber())
                {
                    toBlock = account;
                    Console.WriteLine("Account: {0} was blocked", account.getNumber());

                    break;
                }
            }
            if (toBlock != null)
            {
                toBlock.isBlocked = true;
                
            }
        }

        public void unblockAccount(int accToUnblock)
        {
            Account toUnBlock = null;

            foreach (Account account in accounts)
            {
                if (accToUnblock == account.getNumber())
                {
                    toUnBlock = account;
                    Console.WriteLine("Account: {0} was unblocked", account.getNumber());
                    break;
                }
                else
                {
                    Console.WriteLine("Account not exists");
                }

            }
            if (toUnBlock != null)
            {
                toUnBlock.isBlocked = false;
            }
        }
        public void summary()
        {
            int sum = 0;
            foreach (Account account in accounts)
            {
                sum += account.getBalance();
            }
            Console.Write("Bank balance is: {0}", sum);
        }
        public void debtor()
        {
            foreach (Account account in accounts)
            {
                if( account.credit > 0)
                {
                    Console.WriteLine("Account number: {0} Credit amount: {1}", account.getNumber(), account.credit);
                }
            }
        }

        public bool addAccount(string accName, string accPassword, int accNumber)
        {
            foreach (Account account in accounts)
            {
                if(account.getNumber()==accNumber)
                {
                    Console.WriteLine("This account is already on the list");
                    return false;
                }
            }
            accounts.Add(new Account(this, accName, accPassword, accNumber));
            return true;
        }

    }
}
