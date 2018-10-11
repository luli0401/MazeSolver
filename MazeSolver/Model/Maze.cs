using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver.Model
{
    public class Maze
    {

        //Properties
        public List<string> MazeMatrix { get; set; }


        //Constructor
        public Maze(List<string> m)
        {
            MazeMatrix = m;
        }


        //Helper Methods
        internal void MarkPoint(int x, int y)
        {
            var stringBuilder = new StringBuilder(MazeMatrix[y]);
            stringBuilder.Remove(x, 1);
            stringBuilder.Insert(x, ".");

            MazeMatrix[y] = stringBuilder.ToString();
        }

        internal Coordinate FindStartPoint()
        {
            int x = 0;
            int y = 0;
            Coordinate coordinate = null;

            foreach (var mazeLine in MazeMatrix)
            {
                x = mazeLine.IndexOf("S", StringComparison.CurrentCultureIgnoreCase);

                if (x != -1)
                {
                    coordinate = new Coordinate(x, y);
                }

                y++;
            }

            return coordinate;
        }

        internal bool IsEndPoint(int x, int y)
        {
            if (IsOutOfBound(x, y))
            {
                return false;
            }

            return MazeMatrix[y][x] == 'E';
        }

        internal bool IsValidPoint(int x, int y)
        {
            if (IsOutOfBound(x, y))
            {
                return false;
            }

            return MazeMatrix[y][x] != 'X' && MazeMatrix[y][x] != '.';
        }

        internal bool IsNotWall(int x, int y)
        {
            if (IsOutOfBound(x, y))
            {
                return false;
            }

            return MazeMatrix[y][x] != 'X';
        }

        private bool IsOutOfBound(int x, int y)
        {
            return x < 0 || x >= MazeMatrix[0].Length || y < 0 || y >= MazeMatrix.Count;
        }

        internal void PrintMaze()
        {
            foreach (var line in MazeMatrix)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(Environment.NewLine);
        }

    }
}
