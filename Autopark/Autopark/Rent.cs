namespace Autopark
{
    public sealed class Rent
    {
        public DateTime Date { get; private set; } = default(DateTime);
        public double Cost
        {
            get => _cost;
            private set
            {
                if (value < 0) throw new ArgumentException("cost must be positive");
                _cost = value;
            }
        }
        public int Id { get; private set; }
        public Rent(int id, DateTime date, double cost)
        {
            Id = id;
            Date = date;
            Cost = cost;
        }

        private double _cost;
    }
}
