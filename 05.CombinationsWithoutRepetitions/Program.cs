namespace _05.CombinationsWithoutRepetitions
{
    using System;

    public static class CombinationsWithoutRepetitions
    {
        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());
            GenerateCombination(new int[k], 0, 1, n);
        }

        static void GenerateCombination(int[] arr, int index, int start, int end)
        {
            if (index == arr.Length)
            {
                Console.WriteLine($"({string.Join(" ", arr)})");
                return;
            }

            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                GenerateCombination(arr, index + 1, i + 1, end);
            }
        }
    }
}