namespace oop3
{
    public abstract class FinanceStorage
    {
        public abstract void Save(List<Transaction> transactions);
        public abstract void Load();
    }
}