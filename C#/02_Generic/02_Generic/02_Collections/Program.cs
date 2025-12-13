using System.Collections;
using System.Collections.Generic;

namespace _02_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Non Generic Collections

            // Stack
            Stack stack = new Stack();

            //stack.Push(2);
            //stack.Push("Hello world");
            //stack.Push(7.4);
            //stack.Push(10);
            //stack.Push(DateTime.Now);

            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}
            

            // Queue
            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);

            //while (queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}




            // Array list
            //ArrayList list = new ArrayList();
            //list.Add(60);
            //list.Insert(0, 1);
            //list.Insert(0, 9);
            //list.Add(2);
            //list.Add(10);
            //list.Add(10);
            //list.Add(10);
            //list.Add(10);
            //list.Add(76);
            //list.Add(3);

            //list.Sort();
            //int index = list.IndexOf(10);
            //int indexLast = list.LastIndexOf(10);
            //foreach (var item in list)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Index = " + index.ToString());
            //Console.WriteLine("Index last = " + indexLast.ToString());

            //Console.WriteLine(list[5]);



            // SortedList
            //SortedList sortedList = new SortedList();
            //sortedList.Add("jan", 1);
            //sortedList.Add("feb", 2);
            //sortedList.Add("mar", 3);
            //sortedList.Add("apr", 4);

            //foreach (var item in sortedList)
            //{
            //    Console.WriteLine(item);
            //}




            // Generic collections
            //Stack<int> intsStack = new Stack<int>();
            //intsStack.Push(8);
            //intsStack.Push(10);
            //intsStack.Push(1);
            //intsStack.Push(5);

            //while (intsStack.Count > 0)
            //{
            //    Console.WriteLine(intsStack.Pop());
            //}

            Queue<int> qInts = new Queue<int>();
            qInts.Enqueue(8);
            qInts.Enqueue(10);
            qInts.Enqueue(1);
            qInts.Enqueue(5);
            qInts.Enqueue(2);

            //while (qInts.Count > 0)
            //{
            //    Console.WriteLine(qInts.Dequeue());
            //}



            // list - масив
            //List<int> listInts = new List<int> { 2,4,6,7,32,3,5,7,8,5,4,8 };

            //Console.WriteLine(listInts[6]);
            //listInts[0] = 100;

            //listInts.Add(6);
            //listInts.AddRange(qInts);
            //listInts.Insert(2, 143);
            ////int res = listInts.RemoveAll((int a) => a % 2 != 0);
            ////Console.WriteLine(res);

            //Console.WriteLine("Array");
            //foreach (var item in listInts)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //var sliceRes = listInts.Slice(5, 2);


            // LinkedList - двозв'язний список на нодах
            //LinkedList<string> colors = new LinkedList<string>();
            //colors.AddLast("red");
            //colors.AddFirst("green");
            //colors.AddFirst("yellow");
            //colors.AddLast("blue");

            //var node = colors.FindLast("red");
            //if(node != null)
            //{
            //    colors.AddAfter(node, "black");
            //}

            //foreach (var color in colors)
            //{
            //    Console.WriteLine(color);
            //}




            // Dictionary
            Dictionary<int, string> months = new Dictionary<int, string>();
            months.Add(1, "April");
            months.Add(2, "February");
            months.Add(3, "March");
            bool res = months.TryAdd(5, "May");
            Console.WriteLine("Add 5 month " + res.ToString());
            res = months.TryAdd(1, "May");
            Console.WriteLine("Add 1 month " + res.ToString());
            months[1] = "January";

            if (months.ContainsKey(4))
            {
                months[4] = "April";
            }
            else
            {
                months.Add(4, "April");
            }

            Console.WriteLine(months.ContainsValue("April"));

            foreach (var pair in months)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            foreach (var item in months.Values)
            {
                Console.WriteLine(item);
            }



            //Dictionary<ConsoleKey, Action> keyActions = new Dictionary<ConsoleKey, Action>();
            //keyActions.Add(ConsoleKey.W, () => Console.WriteLine("Up"));
            //keyActions.Add(ConsoleKey.A, () => Console.WriteLine("Left"));
            //keyActions.Add(ConsoleKey.S, () => Console.WriteLine("Right"));
            //keyActions.Add(ConsoleKey.D, () => Console.WriteLine("Down"));

            //while(true)
            //{
            //    ConsoleKey key = Console.ReadKey(true).Key;
            //    keyActions[key]();
            //}



            //HashSet<double> set = new HashSet<double>();

            //set.Add(5);
            //set.Add(1);
            //set.Add(5);
            //set.Add(10);
            //set.Add(2);
            //set.Add(1);

            //foreach (int i in set)
            //{
            //    Console.WriteLine(i);
            //}



            SortedDictionary<int, int> sortDict;
            SortedSet<int> sortSet = new SortedSet<int>();

            sortSet.Add(8);
            sortSet.Add(10);
            sortSet.Add(1);
            sortSet.Add(5);
            sortSet.Add(2);
            sortSet.Add(3);

            Console.WriteLine("Sort set");
            foreach (var item in sortSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
