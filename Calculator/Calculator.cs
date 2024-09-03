namespace Calculator
{
    public static class Calculator
    {
        public static int CalculateSum(string arg)
        {
            if(arg == null) return 0;

            string[] numbers = arg.Split(',');

            return numbers.Select(n => int.TryParse(n, out int value) ? value : 0).Sum();
        }
    }
}
