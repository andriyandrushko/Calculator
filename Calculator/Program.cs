using Microsoft.Extensions.DependencyInjection;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<ICalculator, CalculatorService>()

            .BuildServiceProvider();

            var calculator = serviceProvider.GetRequiredService<ICalculator>();
            Console.WriteLine("Enter numbers separated by a comma (e.g., 1,2):");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    // Check for Ctrl+C
                    if (input == null)
                    {
                        break;
                    }

                    (int, string) result = calculator.CalculateSum(input);
                    Console.WriteLine("The sum is: " + result.Item1);
                    Console.WriteLine("The formula is: " + result.Item2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
    }
}
