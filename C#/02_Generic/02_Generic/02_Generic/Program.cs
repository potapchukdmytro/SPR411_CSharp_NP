namespace _02_Generic
{
    interface IMath<T>
    {
        T Sum(T a);
    }

    struct IntValue : IMath<int>, IComparable<IntValue>
    {
        public int Value;

        public int CompareTo(IntValue other)
        {
            return Value.CompareTo(other.Value);
        }

        public int Sum(int a)
        {
            return Value + a;
        }
    }

    class DefaultCtr
    {
        public DefaultCtr()
        {
            
        }
    }

    class ParamsCtr
    {
        public ParamsCtr(int a)
        {
            
        }
    }

    class MyCollection<T>
        where T : IComparable<T>
    {
        private T[] data;

        public MyCollection(params T[] values)
        {
            data = new T[values.Length];
            for (int i = 0; i < values.Length; i++)
            { 
                data[i] = values[i];
            }
        }

        public void Push(T value)
        {
            data = data.Append(value).ToArray();
        }

        public void Sort()
        {
            data = data.Order().ToArray();
        }

        public void Print()
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }

    internal class Program
    {
        // Generic - шаблони
        static void RedPrint<T>(T data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(data);
            Console.ResetColor();
        }

        static T? GenerateDefaultValue<T>()
        {
            return default;
        }

        static string Concat<T1, T2>(T1 value1, T2 value2)
            where T1 : notnull
            where T2 : notnull
        {
            return value1.ToString() + value2.ToString();
        }

        static T Sum<T, T2>(T a, T b)
            where T : struct        
        {

            return default;
        }
        // where
        // struct -> тільки структура
        // class -> тільки клас
        // enum -> тільки enum
        // notnull -> не може бути null
        // base class, interface -> успадковує вказаний клас або інтерфейс

        static void Main(string[] args)
        {
            //RedPrint(6);
            //RedPrint("Text");

            //RedPrint<float>(6.7F);

            //RedPrint(6.7);
            //RedPrint(6.7M);

            //string? value = GenerateDefaultValue<string>();

            //if(value != null)
            //{
            //    Console.WriteLine(value.ToString());
            //}

            //string res = Concat<DateTime, int>(value, 500);
            //Console.WriteLine(res);


            var collection = new MyCollection<IntValue>(new IntValue { Value = 6}, new IntValue { Value = 2 });
            var ints = new MyCollection<int>(3,6,7,9,3,4,7,8);

            ints.Sort();
            ints.Print();




            List<List<Dictionary<int, string>>>? obj = null;
            DateTime? dt = null;
        }
    }
}
