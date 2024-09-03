namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by a comma (e.g., 1,2):");
            string input = Console.ReadLine();

            try
            {
                int result = Calculator.CalculateSum(input);
                Console.WriteLine("The sum is: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
