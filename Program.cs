using System;

namespace oop3
{
    public class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker financeTracker = new();
            JsonFinanceStorage jfs = new(financeTracker);
            
            jfs.Load();

            Console.WriteLine("Welcome to this finance tracker!\n(Every bank app has this but now you can flex you have the source code of this xd)");
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\nWhat would you like to do:\n1.Add transaction\n2.View all transactions\n3.Categorized view\n4.View balance\n5.Quit");
                var choice = Console.ReadLine();
                switch(choice)
                {
                    
                    case "1":
                    financeTracker.Add();
                        break;
                    case "2":
                    financeTracker.ViewAll();
                        break;
                    case "3":
                    financeTracker.Categorized();
                        break;
                    case "4":
                    financeTracker.Balance();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
            }

            jfs.Save(financeTracker.Transactions);
            Console.WriteLine("Good bye;)");
        }
    }
}