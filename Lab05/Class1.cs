namespace Lab05
{
    public class RationalNumber
    {
        private int numerator;
        private int denominator;
        public int Numerator
        {
            get { return numerator; }
        }
        public int Denominator
        {
            get { return denominator; }
        }

        public RationalNumber(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            // Simplify the fraction
            int gcd = GreatestCommonDenominator(numerator, denominator);
            this.numerator /= gcd;
            this.denominator /= gcd;
            //if the denominator is negative, make the numerator negative and the denominator positive
            if(this.denominator < 0 && this.numerator < 0)
            { //if both are negative, make them both positive
                this.numerator *= -1;
                this.denominator *= -1;
            }
            else if(this.denominator < 0)
            {
                this.numerator *= -1;
                this.denominator *= -1;
            }
            //Console.WriteLine($"Received: {numerator}/{denominator}, Simplified: {this.numerator}/{this.denominator}");
        }

        static int GreatestCommonDenominator(int a, int b)
        {
            //given 2/4
            //call gcd(4,2%4) 2%4 = 2 -> gcd(4,2)
            //call gcd(2,4%2) 4%2 = 0 -> gcd(2,0) -> return 2
            //2 is the greatest common denominator
            //so divide 2/4 by 2 to get 1/2

            // if the denominator is 0, return the absolute value of the numerator
            if (b == 0)
            {
                return Math.Abs(a);
            }
            else
            { // else, return the greatest common denominator of the denominator and the remainder of the numerator divided by the denominator
                return GreatestCommonDenominator(b, a % b);
            }
        }

        public override bool Equals(object? obj)
        {
            // Check if the object is null or not a RationalNumber
            if (obj == null || !(obj is RationalNumber))
            {
                return false;
            }

            // Cast the object to RationalNumber
            RationalNumber other = (RationalNumber)obj;

            // Compare the numerator and denominator
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            // Use HashCode.Combine to combine the hash codes of the numerator and denominator
            return HashCode.Combine(numerator, denominator);
        }
    }
}
namespace Lab05
{
    public class MixedNumber
    {
        public int WholeUnits { get; }
        public RationalNumber PartialUnits { get; }

        public MixedNumber(int numerator, int denominator)
        {
            WholeUnits = numerator / denominator;
            int remainder = numerator % denominator;
            PartialUnits = new RationalNumber(remainder, denominator);
            //Console.WriteLine($"Received: {numerator}/{denominator}, Whole: {WholeUnits}, Partial: {remainder}/{denominator}");
        }

        public override bool Equals(object? obj)
        {
            // Check if the object is null or not a MixedNumber
            if (obj == null || !(obj is MixedNumber))
            {
                return false;
            }

            // Cast the object to MixedNumber
            MixedNumber other = (MixedNumber)obj;

            // Compare the WholeUnits and PartialUnits
            //if equal, return true, else return false
            return this.WholeUnits == other.WholeUnits && this.PartialUnits.Equals(other.PartialUnits);
        }

        public override int GetHashCode()
        {
            // Use HashCode.Combine to combine the hash codes of the WholeUnits and PartialUnits
            //this makes sure that the hash code is unique for each MixedNumber
            return HashCode.Combine(WholeUnits, PartialUnits);
        }
    }
}