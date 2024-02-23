using System.Text.Json;
using System.IO;

namespace oop3
{
    public class JsonFinanceStorage : FinanceStorage
    {
        private FinanceTracker financeTracker;

        public JsonFinanceStorage(FinanceTracker financeTracker)
        {
            this.financeTracker = financeTracker;
        }
        public override void Save(List<Transaction> transactions)
        {
            string jsonString = JsonSerializer.Serialize(transactions);
            File.WriteAllText("transactions.json", jsonString);
            Console.WriteLine("Saving files...");
        }

        public override void Load()
        {
            string filePath = "transactions.json";
            string content = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("The file is empty.");
            }
            else
            {
                Console.WriteLine("Your data has successfully loaded :)");
                financeTracker.SetTransactions(JsonSerializer.Deserialize<List<Transaction>>(content));
            }
        }
    }
}