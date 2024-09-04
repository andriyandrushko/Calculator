namespace Calculator
{
    public static class Calculator
    {
        public static int CalculateSum(string arg)
        {
            if(arg == null) return 0;

            // support for custom delimiter
            if (arg.StartsWith("//"))
            {
                char delimiter = arg[2]; 
                arg = arg.Substring(4);
                arg = arg.Replace(delimiter.ToString(), ",");
            }

            //support for /n as delimeter
            arg = arg.Replace("\n", ",");

            string[] numbers = arg.Split(',');

            //check for negative numbers
            var negativeNumbers = numbers
                .Select(n => int.TryParse(n, out int value) ? value : 0)
                .Where(n => n < 0)
                .Select(n => n.ToString());
            
            if (negativeNumbers.Any())
            {
                var q = string.Join(",", negativeNumbers);
                throw new ArgumentException($"Negative numbers found: {string.Join(",", negativeNumbers)}");
            }

            return numbers
                .Select(n => int.TryParse(n, out int value) && value <= 1000 ? value : 0)
                .Sum();
        }
    }
}
