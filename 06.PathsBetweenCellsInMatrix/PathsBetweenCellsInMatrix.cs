namespace _06.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PathsBetweenCellsInMatrix
    {
        private const char Start = 's';
        private const char End = 'e';
        private const char Empty = ' ';
        private const char Visited = 'v';

        private static char[,] maze;
        private static int totalPaths;

        public static void Main()
        {
            maze = new[,]
            {
                { 's', ' ', ' ', ' ', ' ', ' ' },
                { ' ', '*', '*', ' ', '*', ' ' },
                { ' ', '*', '*', ' ', '*', ' ' },
                { ' ', '*', 'e', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ' }
            };

            var currentCell = GetStartPos();
            FindAllPaths(currentCell.Item1, currentCell.Item2, 'S', new LinkedList<char>());
            Console.WriteLine($"Total paths found: {totalPaths}");
        }

        private static void FindAllPaths(int row, int col, char currentDir, LinkedList<char> path)
        {
            if (!IsReachableCell(row, col))
            {
                return;
            }

            path.AddLast(currentDir);

            if (maze[row, col] == End)
            {
                Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
                totalPaths++;
            }

            if (maze[row, col] == Empty || maze[row, col] == Start)
            {
                maze[row, col] = Visited;

                FindAllPaths(row, col - 1, 'L', path);
                FindAllPaths(row - 1, col, 'U', path);
                FindAllPaths(row, col + 1, 'R', path);
                FindAllPaths(row + 1, col, 'D', path);

                maze[row, col] = Empty;
            }

            path.RemoveLast();
        }

        private static bool IsReachableCell(int row, int col)
        {
            return row >= 0 && row < maze.GetLength(0) &&
                   col >= 0 && col < maze.GetLength(1);
        }

        private static Tuple<int, int> GetStartPos()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == Start)
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }

            throw new InvalidOperationException("Start point not found in the matrix");
        }
    }
}