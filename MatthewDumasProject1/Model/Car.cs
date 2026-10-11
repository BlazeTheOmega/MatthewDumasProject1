namespace MatthewDumasProject1.Model
{
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public double Mpg { get; }
        public decimal Price { get; }

        public Car(string make, string model, double mpg, decimal price)
        {
            // Validate make model mpg and price
            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException(
                    "Make cannot be empty.", nameof(make));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(
                    "Model cannot be empty.", nameof(model));
            }

            if (mpg <= 0 || !double.IsFinite(mpg))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(mpg), "MPG must be greater than zero and finite.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(price), "Price cannot be negative.");
            }

            // Assign the validated values.
            Make = make;
            Model = model;
            Mpg = mpg;
            Price = price;
        }
    }
}