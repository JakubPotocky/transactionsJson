namespace oop3
{
    public class Transaction
    {
        public Guid ID {get;}
        public DateTime Date {get;}
        public string? Description {get; set; } //?
        public decimal Amount {get; set; }
        public string? Category {get; set; } //?

        public Transaction(string Description, decimal Amount, string Category)
        {
            this.ID = Guid.NewGuid();
            this.Date = DateTime.Now;
            this.Description = Description;
            this.Amount = Amount;
            this.Category = Category;
        }

    }
}