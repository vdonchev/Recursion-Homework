namespace _07.ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;

    public static class ConnectedAreasInAMatrix
    {
        private static bool[,] maze;
        private static SortedSet<ConectedArea> connectedAreas;

        public static void Main()
        {
            // True means visited or obsticle
            maze = new[,]
            {
                { true, false, false, true, false, false, false, true, false, false },
                { true, false, false, true, false, false, false, true, false, false },
                { true, false, false, true, true, true, true, true, false, false },
                { true, false, false, true, false, false, false, true, false, false },
                { true, false, false, true, false, false, false, true, false, false }
            };

            connectedAreas = new SortedSet<ConectedArea>();

            ConectedArea area;
            while (FindArea(out area))
            {
                CrawArea(area, area.X, area.Y);
                connectedAreas.Add(area);
            }

            var index = 1;
            foreach (var connectedArea in connectedAreas)
            {
                Console.WriteLine($"Area #{index++} at {connectedArea}");
            }
        }

        private static void CrawArea(ConectedArea area, int row, int col)
        {
            if (row < 0 || row >= maze.GetLength(0) ||
                col < 0 || col >= maze.GetLength(1) ||
                maze[row, col])
            {
                return;
            }

            maze[row, col] = true;
            area++;

            CrawArea(area, row, col - 1); // Left
            CrawArea(area, row - 1, col); // Up
            CrawArea(area, row, col + 1); // Right
            CrawArea(area, row + 1, col); // Down
        }

        private static bool FindArea(out ConectedArea area)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (!maze[row, col])
                    {
                        area = new ConectedArea(0, row, col);
                        return true;
                    }
                }
            }

            area = null;
            return false;
        }

        internal class ConectedArea : IComparable<ConectedArea>
        {
            public ConectedArea(int size, int x, int y)
            {
                this.Size = size;
                this.X = x;
                this.Y = y;
            }

            public int Size { get; set; }

            public int X { get; private set; }

            public int Y { get; private set; }

            public int CompareTo(ConectedArea other)
            {
                var res = -this.Size.CompareTo(other.Size);
                if (res == 0)
                {
                    res = this.X.CompareTo(other.X);
                    if (res == 0)
                    {
                        res = this.Y.CompareTo(other.Y);
                    }
                }

                return res;
            }

            public static ConectedArea operator ++(ConectedArea area)
            {
                area.Size++;
                return area;
            }

            public override string ToString()
            {
                return $"({this.X}, {this.Y}), size: {this.Size}";
            }
        }
    }
}