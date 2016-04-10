namespace _01.ReverseArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ReverseArray
    {
        private static void Main()
        {
            var arr = Enumerable.Range(0, 10).ToArray(); // [0, 1, 2 ...9]
            arr.PrintReverse();
        }

        private static void PrintReverse<T>(this IList<T> arr, int index = 0)
        {
            if (index == arr.Count)
            {
                return;
            }

            arr.PrintReverse(index + 1);
            Console.Write($"{arr[index],-2}");

            if (index == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
