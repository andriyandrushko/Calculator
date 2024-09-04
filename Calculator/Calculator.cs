namespace Calculator
{
    public static class Calculator
    {
        public static int CalculateSum(string arg)
        {
            if (arg == null) return 0;

            // support for custom delimiter
            if (arg.StartsWith("//"))
            {
                int endOfCustomFormatString = arg.IndexOf("\n");
                if (endOfCustomFormatString == -1)
                {
                    throw new ArgumentException("Wrong arguments format");
                }

                string customFormats = arg.Substring(2, endOfCustomFormatString - 2);
                int delimiterStartIndex = customFormats.IndexOf('[');
                int delimiterEndIndex = customFormats.LastIndexOf(']');
                //check if we have custom multychar delimeter
                //check if have [ and ] chars
                if (delimiterStartIndex != -1 && delimiterEndIndex != -1)
                {
                    //check if format is [*]/n
                    if (delimiterEndIndex - delimiterStartIndex < 2)
                    {
                        //found [] - empty custom delimeter
                        throw new ArgumentException("Empty custom delimeter found, like //[]");
                    }
                    else
                    {
                        string[] delimiters = customFormats.Split(']');
                        //cutoff custom delimeters formats
                        arg = arg.Substring(endOfCustomFormatString + 1);
                        //apply all providet delimeters
                        foreach (string item in delimiters)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                arg = arg.Replace(item.Substring(1), ",");
                            }
                        }
                    }
                }
                else
                {
                    //support for 1 char custom delimiter
                    string delimiter = arg[2].ToString();
                    arg = arg
                            .Substring(4)
                            .Replace(delimiter.ToString(), ",");
                }
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
