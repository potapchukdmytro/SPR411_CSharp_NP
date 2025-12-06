using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Delegates
{
    public class Color
    {
        public string Code { get; set; }
        public string Name { get; set; } 
    }

    public delegate bool CollectionDelegate(int x);
    public delegate bool PredicateSort(int a, int b);
    public delegate bool PredicateColorSort(Color a, Color b);

    internal class CollectionService
    {
        private readonly int[] data = [];
        public Color[] colors = [];

        public CollectionService(int[] data)
        {
            this.data = data;
        }

        public CollectionService(Color[] colors)
        {
            this.colors = colors;
        }

        public int[] FindValues(CollectionDelegate pred)
        {
            int[] res = [];
            foreach (var item in data)
            {
                if (pred(item))
                {
                    res = res.Append(item).ToArray();
                }
            }

            return res;
        }

        public int FindValue(CollectionDelegate pred)
        {
            foreach (var item in data)
            {
                if(pred(item))
                {
                    return item;
                }
            }

            return default;
        }

        public void Sort(PredicateColorSort pred)
        {
            for (int i = 0; i < colors.Length - 1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < colors.Length - i - 1; j++)
                {
                    if (pred(colors[j + 1], colors[j]))
                    {
                        Color temp = colors[j];
                        colors[j] = colors[j + 1];
                        colors[j + 1] = temp;
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    break;
                }
            }
        }

        public int[] Sort(PredicateSort pred)
        {
            int[] arr = [..data];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (pred(arr[j + 1], arr[j]))
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSorted = false;
                    }
                }
                if(isSorted)
                {
                    break;
                }
            }
            return arr;
        }

        public void Print()
        {
            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
        }
    }
}
