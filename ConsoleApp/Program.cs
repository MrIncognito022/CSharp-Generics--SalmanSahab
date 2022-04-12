// See https://aka.ms/new-console-template for more information
using Handlers;
using Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var utility = new Utility();

            //utility.Max<int>(2, 10);
            //utility.Max<char>('r', 'a');
            //utility.Max<string>("salman", "taj");

            IBankAccountHandler bankAccountHandler = new BankAccountHandler();
            string title, accountType, code, toCode;
            decimal amount;
            bool choice = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\t               ***** Enter your choice *****");
                Console.WriteLine("\t1...................Create a new Account......................");
                Console.WriteLine("\t2...................Search an Existing Account ...............");
                Console.WriteLine("\t3...................Deposit amount into the account...........");
                Console.WriteLine("\t4...................Withdraw amount from account..............");
                //Console.WriteLine("\t5...................Transfer amount to other account..........");
                Console.WriteLine("\t5...................Display All Account details...............");
                Console.WriteLine("6.................... Compare 2 accounts based on code..........");

                string? option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Account Title");
                            title = Console.ReadLine().Trim();
                            Console.WriteLine("Select the account type. 1) Saving 2) Current");
                            accountType = Console.ReadLine().Trim();
                            if (accountType == "1")
                                bankAccountHandler.Add(new CurrentBankAccount { Title =title});
                            else if (accountType == "2")
                            {
                                bankAccountHandler.Add(new CurrentBankAccount { Title = title});

                            }
                            Console.WriteLine("Account created");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Your Account Number");
                            code = Console.ReadLine().Trim();
                            BankAccount bankaccount = bankAccountHandler.GetBankAccount(code, false);
                            Console.WriteLine(bankaccount.ToString());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the account number");
                            code = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the amount to deposit");
                            amount = decimal.Parse(Console.ReadLine());
                            BankAccount bankAccount = bankAccountHandler.GetBankAccount(code);

                            if (bankAccount.PayIn(amount) == true)
                            {
                                Console.WriteLine("Amount deposit successfully");
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                        }
                        break;
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the account number");
                            code = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the amount to Withdraw");
                            amount = decimal.Parse(Console.ReadLine());
                            BankAccount bankAccount = bankAccountHandler.GetBankAccount(code);
                            bankAccount.WithDraw(amount);
                            Console.WriteLine("Amount Withdraw successfully");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                        }
                        break;
                    case "5":
                        {
                            Console.Clear();
                            IEnumerable<BankAccount> bankAccounts = bankAccountHandler.GetBankAccounts();
                            foreach (BankAccount bankAccount in bankAccounts)
                            {
                                Console.WriteLine(bankAccount.ToString());
                            }
                            Console.WriteLine("Press Any Key");
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        {
                            Console.WriteLine("Enter first account code");
                            code=Console.ReadLine().Trim();
                            BankAccount bankAccount=bankAccountHandler.GetBankAccount(code);
                            Console.WriteLine("Enter Second Account Code");
                            toCode = Console.ReadLine().Trim();
                            BankAccount toBankAccount = bankAccountHandler.GetBankAccount(toCode);
                            



                        }
                        break;
                    default:
                        {
                            choice = false;
                        }
                        break;
                }
            }
            while (choice);
        }
    }
}
