using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _01_Delegates
{
    internal class Program
    {
        public delegate void VoidDelegate();
        public delegate void PrintDelegate(int a);
        public delegate double OperationalDelegate(double a, double b);
        public delegate bool PredicateDelegate(int a);

        static void Method()
        {
            Console.WriteLine("Method 1 work");
        }


        static void PrintCollection(int[] ints, PrintDelegate pd)
        {
            foreach (var item in ints)
            {
                pd(item);
            }
        }

        static void WriteMethod(int a)
        {
            if(!File.Exists("file.txt"))
            {
                var stream = File.Create("file.txt");
                stream.Dispose();
            }
            File.AppendAllText("file.txt", a.ToString() + "\n");
        }

        static void PrintMethod(int a)
        {
            Console.WriteLine(a);
        }


        static double Sum(double a, double b)
        {
            return a + b;
        }

        static double Sub(double a, double b)
        {
            return a - b;
        }

        static double Mul(double a, double b)
        {
            return a * b;
        }

        static double Div(double a, double b)
        {
            return a / b;
        }

        static void Operation(double a, double b, OperationalDelegate opDelegate)
        {
            Console.WriteLine(opDelegate(a,b));
        }


        static int[] SearchValues(int[] data, PredicateDelegate pred)
        {
            int[] res = [];
            foreach (var item in data)
            {
                if(pred(item))
                {
                    res = res.Append(item).ToArray();
                }
            }

            return res;
        }

        static bool EvenNumbers(int a)
        {
            return a % 2 == 0;
        }

        static bool NegativeNumbers(int a)
        {
            return a < 0;
        }

        static bool FiveNumbers(int a)
        {
            return a % 5 == 0;
        }

        static void MainCode()
        {
            //VoidDelegate vd = Method;
            //int[] values = [2, 4, 6, 75, 2, 3, 5, 78, 5, 2, 6, 9];

            //PrintCollection(values, PrintMethod);
            //PrintCollection(values, WriteMethod);

            OperationalDelegate sum = Sum;
            OperationalDelegate sub = Sub;
            OperationalDelegate mul = Mul;
            OperationalDelegate div = Div;

            //double res = sum(2.6, 15.8);
            //Console.WriteLine(res);

            //res = sub(6.7, 9.0);
            //Console.WriteLine(res);


            //Operation(7.9, 733.6, Mul);


            int[] data = [-4, 57, 435, 45, -112, 4, -5, 78, 9, -6, 32, 23, -66, 8796, -4, 4, 79];

            //int[] res = SearchValues(data, NegativeNumbers);
            //res = SearchValues(data, EvenNumbers);

            int[] res = SearchValues(data, FiveNumbers);

            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Anonymus function
            // (args) => { code };  // може бути безліч рядків коду
            // (args) => code line; // може бути тільки 1 рядок коду

            OperationalDelegate opd = (double a, double b) => { return a % b; };

            OperationalDelegate opd2 = (double a, double b) => a % b;
            PrintDelegate pd2 = (int a) => Console.WriteLine(a + 1);

            Console.WriteLine(opd2(1, 7));
        }

        static bool CheckString(string value)
        {
            return value.Length > 0;
        }


        static int ToInt(string str)
        {
            return int.Parse(str);
        }

        static int[] ToArray(int a, int b, int c, int d)
        {
            return [a, b, c, d];
        }

        static void Main(string[] args)
        {
            // MainCode();

            //string str = default; // null
            //int i = default;
            //double d = default;
            //bool b = default;
            //DateTime dt = default; // default contructor
            //Array arr = default;

            //DateTime dt2 = new DateTime(2025, 12, 6, 10, 50, 0);
            //DateTime now = DateTime.Now;
            //DateTime nowUtc = DateTime.UtcNow;



            int[] data = [-4, 57, 435, 45, -112, 4, -5, 78, 9, -6, 32, 23, -66, 8796, -4, 4, 79];
            CollectionService cs = new CollectionService(data);

            int value = cs.FindValue((int x) => x > 100);
            Console.WriteLine(value);

            value = cs.FindValue((int x) => x < -50);
            Console.WriteLine(value);

            value = cs.FindValue((int x) => x * x > 400);
            Console.WriteLine(value);

            int[] values = cs.FindValues(x => x > 50);
            foreach (var item in values)
            {
                Console.Write(item + " ");
            }



            // Standart delegates

            // Action    - void method              void Action()
            // Predicate - bool method              bool Predicate(value)
            // Func      - universal delegate   


            Action action = () => Console.WriteLine("");
            Action<int> actionInt = (int a) => Console.WriteLine(a);
            Action<int, int> actionIntInt = (int a, int b) => Console.WriteLine(a + b);

            // Predicate - bool Method(T value);
            Predicate<string> pred = (string value) => value.Length > 0;
            Predicate<string> pred2 = CheckString;

            // Func T Method(T values);

            // int ToInt(string str);
            Func<string, int> conv = ToInt;

            // int[] ToArray(int a, int b, int c, int d)
            Func<int, int, int, int, int[]> toArr = ToArray;

            //var res = cs.Sort((a, b) => a > b);
            //Console.WriteLine("\nSorted");
            //foreach (var item in res)
            //{
            //    Console.Write(item + " ");
            //}


            Color black = new Color { Code = "#000", Name = "Black" };
            Color white = new Color { Code = "#FFF", Name = "White" };

            Color[] colors = [
                black, 
                white,
                new Color{ Code = "#FF0000", Name = "Red" },
                new Color{ Code = "#00FF00", Name = "Green" },
                new Color{ Code = "#0000FF", Name = "Blue" },
                new Color{ Code = "#FF00FF", Name = "Purple" }
                ];

            cs.colors = colors;
            cs.Sort((c1, c2) => c1.Name.CompareTo(c2.Name) == 1);

            Console.WriteLine("\nColors");
            foreach (var color in cs.colors)
            {
                Console.WriteLine($"{color.Code} - {color.Name}");
            }

            cs.Sort((c1, c2) => c1.Code.CompareTo(c2.Code) == 1);

            Console.WriteLine("\nColors");
            foreach (var color in cs.colors)
            {
                Console.WriteLine($"{color.Code} - {color.Name}");
            }
        }
    }
}
