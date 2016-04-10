namespace _02.NestedLoopsToRecursion
{
    using System;

    public static class NestedLoopsToRecursion
    {
        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            NestedLoopSimulator(n, new int[n]);
        }

        private static void NestedLoopSimulator(int n, int[] arr, int index = 0)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                NestedLoopSimulator(n, arr, index + 1);
            }
        }
    }
}
