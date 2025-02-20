using System;
using Lab05;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a fraction (numerator/denominator): ");
            string input = Console.ReadLine() ?? string.Empty;

            // it Split the input to get numerator and denominator
            string[] parts = input.Split('/');
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input. Please enter a fraction in the form numerator/denominator.");
                return;
            }

            // Parse n and d 
            if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
            {
                Console.WriteLine("Invalid input. Numerator and denominator must be integers.");
                return;
            }

            // Create a MixedNumber object
            MixedNumber mixedNumber = new MixedNumber(numerator, denominator);

            // Output the mixed number
            if(mixedNumber.WholeUnits == 0)
            {
                Console.WriteLine($"The mixed number is: {mixedNumber.PartialUnits.Numerator}/{mixedNumber.PartialUnits.Denominator}");
            }
            else
            {
                Console.WriteLine($"The mixed number is: {mixedNumber.WholeUnits} {mixedNumber.PartialUnits.Numerator}/{mixedNumber.PartialUnits.Denominator}");
            }
        }
    }
}