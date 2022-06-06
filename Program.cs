using System;

namespace Bank
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            Account curAccount = null;
            Admin admin = new Admin(bank);

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("\n\x1b[1m Log in as: \x1b[0m " +
                                  "\nAdmin - PRESS 1 " +
                                  "\nUser - PRESS 2");
                int key = int.Parse(Console.ReadLine());

                if (key == 1) //ADMIN
                {
                    admin.adminLogin = true;
                    while (admin.adminLogin == true)
                    {
                        Console.WriteLine("\n \x1b[1m Please chose the option from the list below:\x1b[0m" +
                                            "\n1. Add new account" +
                                            "\n2. Delete account" +
                                            "\n3. Block account" +
                                            "\n4. Unblock account" +
                                            "\n5. Summary" +
                                            "\n6. Credit history" +
                                            "\n7. Exit");

                        int option = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (option)
                        {
                            case 1:
                                admin.addAccount();
                                break;
                            case 2:
                                admin.delAccount();
                                break;
                            case 3:
                                admin.blockAccount();
                                break;
                            case 4:
                                admin.unblockAccount();
                                break;
                            case 5:
                                bank.summary();
                                break;
                            case 6:
                                bank.debtor();
                                break;
                            default:
                                Console.WriteLine("Chose another option:");
                                break;
                            case 7:
                                admin.adminLogin = false;
                                break;
                        }
                    }
                }
                else if (key == 2)// USER
                {
                    Console.WriteLine("Enter your account number:");
                    int accNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your password:");
                    string accPassword = Console.ReadLine();

                    foreach (Account account in bank.accounts)
                    {
                        if (accNumber == account.getNumber())
                        {
                            curAccount = account;
                            break;
                        }
                    }
                    if (curAccount != null)
                    {
                        if (curAccount.isBlocked)
                        {
                            Console.WriteLine("Account is blocked");
                        }

                        else if (curAccount.chceckPassword(accPassword))
                        {
                            curAccount.userLogin = true;
                            while (curAccount.userLogin == true)
                            {
                                Console.WriteLine("\n\x1b[1m Please chose the option from the list below:\x1b[0m" +
                                        "\n1. Pay money" +
                                        "\n2. Withdraw money" +
                                        "\n3. Acc history" +
                                        "\n4. Take a credit" +
                                        "\n5. Pay a credit" +
                                        "\n6. Make a transfer" +
                                        "\n7. Exit");

                                int userOption = int.Parse(Console.ReadLine());
                                //Console.Clear();
                                switch (userOption)
                                {
                                    case 1:
                                        curAccount.payMoney();
                                        break;
                                    case 2:
                                        curAccount.withdrawMoney();
                                        break;
                                    case 3:
                                        curAccount.accHistory();
                                        break;
                                    case 4:
                                        curAccount.takeCredit();
                                        break;
                                    case 5:
                                        curAccount.payCredit();
                                        break;
                                    case 6:
                                        curAccount.sendTransfer();
                                        break;
                                    case 7:
                                        curAccount.userLogin = false;
                                        break;
                                    default:
                                        Console.WriteLine("Chose another option:");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n \x1bInvalid password\x1b");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account is deleted"); //логика
                    }
                }
                else
                {
                    Console.WriteLine("Please chose the correct option");
                }
            }
        }
    }
}
