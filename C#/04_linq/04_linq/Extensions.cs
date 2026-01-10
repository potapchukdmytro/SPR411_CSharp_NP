namespace _04_linq
{
    public static class Extensions
    {
        public static int Power(this int value, int power)
        {
            return (int)Math.Pow(value, power);
        }

        public static string Multiply(this string value, int n)
        {
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                result += value;
            }
            return result;
        }

        public static void Print<T>(this IEnumerable<T> col, bool newLine = true)
        {
            foreach (var item in col)
            {
                if(newLine)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
