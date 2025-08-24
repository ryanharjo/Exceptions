namespace Exceptions_Harjo_Ryan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create and assign two float variables (one is zero)
            float num1 = 25.0f;
            float num2 = 0.0f;
            float result = 0.0f;

            // Step 2: Initialize a random int from 2 to 30
            Random r = new Random();
            int randomAge = r.Next(2, 31); // inclusive of 2, exclusive of 31

            try
            {
                // Step 3: Try dividing with num2 as zero
                result = Divide(num1, num2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                // Ask user to try again with non-zero input
                Console.Write("Please enter a non-zero floating point number: ");

                try
                {
                    num2 = float.Parse(Console.ReadLine());
                    result = Divide(num1, num2);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception innerEx)
                {
                    Console.WriteLine($"Error: {innerEx.Message}");
                }
            }
            finally
            {
                Console.WriteLine($"Calculations completed, with result of {result}!");
            }

            // Step 4: Try calling CheckAge
            try
            {
                CheckAge(randomAge);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Custom Error: You're too young to play mature games.");
            }
        }

        // Divide method: returns a float
        static float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        // CheckAge method
        static void CheckAge(int age)
        {
            if (age >= 17)
            {
                Console.WriteLine($"You are {age}, you can play mature games!");
            }
            else
            {
                throw new ArgumentException("Age below 17 is not allowed for mature games.");
            }
        }
    }

}     
 