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
                string delimiter;
                int delimiterStartIndex = arg.IndexOf('[', 2);
                int delimiterEndIndex = arg.IndexOf(']', 2);
                //check if we have custom multychar delimeter
                //check if have [ and ] chars
                if(delimiterStartIndex != -1 && delimiterEndIndex != -1)
                {
                    string endCustomFormatString = arg.Substring(delimiterEndIndex, 2);
                    //check if format is [*]/n
                    if (delimiterEndIndex - delimiterStartIndex < 2 && endCustomFormatString == "/n")
                    {
                        //found [] - empty custom delimeter
                        throw new ArgumentException("Empty custom delimeter found, like //[]/n");
                    } else
                    {
                        delimiter = arg.Substring(3, delimiterEndIndex - 3);
                        arg = arg.Substring(delimiterEndIndex + 1);
                    }
                }
                else
                {
                    //support for 1 char custom delimiter
                    delimiter = arg[2].ToString();
                    arg = arg.Substring(4);
                }
                
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
