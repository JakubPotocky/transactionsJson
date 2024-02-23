using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace oop3
{
    public class FinanceTracker : Finance
    {
        public List<Transaction> transactions = new();
        public List<Transaction> Transactions
        {
            get { return transactions; } //you can call for this function to get the list
        }

        public void SetTransactions(List<Transaction> newTransactions)
        {
            this.transactions = newTransactions; //to set the list bcs it doesnt have access by itself
        }

        private readonly List<string> categories = new() { "Paycheck", "Utilities", "Groceries" };

        public override void Add()
        {
            int loop = 1;
            bool makeMoney = false;
            string category = "Empty";
            Console.WriteLine("Select category of your transaction:\n(Enter number of your choice from this list)");
            foreach (string choose in categories)
            {
                Console.WriteLine($"{loop}. {choose}");
                loop++;
            }
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    makeMoney = true;
                    category = "Paycheck";
                    break;
                case "2":
                    category = "Utilities";
                    break;
                case "3":
                    category = "Groceries";
                    break;
                default:
                    Console.WriteLine("Wrong selection, please try again.");
                    break;
            }

            Console.WriteLine("Enter description of your transaction:");
            string? description = Console.ReadLine();

            Console.WriteLine("Enter amount:");
            bool isInt = decimal.TryParse(Console.ReadLine(), out decimal amount);
            if (isInt)
            {
                if (!makeMoney) { amount *= -1; }
                if (category != "Empty" && isInt && description != null)
                {
                    Transaction temp = new(description, amount, category);
                    transactions.Add(temp);
                }
            }
            else
            {
                Console.WriteLine("This ain't number bud. xd");
            }

        }

        public override void ViewAll()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            int numberOfTransactions = 0;
            foreach (Transaction transaction in transactions)
            {
                numberOfTransactions++;
                Console.WriteLine($"\n\nTransaction number {numberOfTransactions}\nDate: {transaction.Date}");
                Console.WriteLine($"Description: {transaction.Description}");
                Console.WriteLine($"Category: {transaction.Category}");
                Console.WriteLine($"Amount: {transaction.Amount}");
            }
            Console.WriteLine($"You have {numberOfTransactions} tranasctions.");
        }

        public override void Balance()
        {
            decimal balance = 0;
            decimal totalMade = 0;
            decimal totalLoss = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Category == "Paycheck")
                {
                    totalMade += transaction.Amount;
                }
                else
                {
                    totalLoss += transaction.Amount;
                }
                balance += transaction.Amount;
            }
            Console.WriteLine($"Your total balance: {balance}");
            Console.WriteLine($"Your total money made: {totalMade}");
            Console.WriteLine($"Your total money spent: {totalLoss}");
        }

        public override void Categorized()
        {
            int loop = 1;
            int selection = 0;
            int numberOfTransactions = 0;
            Console.WriteLine("Select category of your transaction:\n(Enter number of your choice from this list)");
            foreach (string choose in categories)
            {
                Console.WriteLine($"{loop}. {choose}");
                loop++;
            }
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    selection = 1;//"Paycheck";
                    break;
                case "2":
                    selection = 2;//"Utilities";
                    break;
                case "3":
                    selection = 3;//"Groceries";
                    break;
                default:
                    Console.WriteLine("Wrong selection, please try again.");
                    break;
            }
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Category == categories[selection - 1])
                {
                    numberOfTransactions++;
                    Console.WriteLine($"\n\nTransaction number {numberOfTransactions}\nDate: {transaction.Date}");
                    Console.WriteLine($"Description: {transaction.Description}");
                    Console.WriteLine($"Category: {transaction.Category}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                }
            }
            Console.WriteLine($"You have {numberOfTransactions} transactions with {categories[selection - 1]} category.");
        }
    }
}