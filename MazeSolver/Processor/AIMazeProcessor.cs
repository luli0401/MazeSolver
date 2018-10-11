using MazeSolver.Model;
using System;

namespace MazeSolver.Processor
{
    public class AIMazeProcessor
    {
        //Properties
        private Maze Maze { get; set; }
        private Coordinate CurrentPoint { get; set; }
        private Coordinate StartPoint { get; set; }
        private bool IsMazeSolved { get; set; }


        //Constructor
        public AIMazeProcessor()
        {
            IsMazeSolved = false;
        }


        //Helper Methods
        internal void SolveMaze(Maze maze)
        {
            Maze = maze;
            StartPoint = maze.FindStartPoint();
            CurrentPoint = StartPoint;

            if (CurrentPoint != null)
            {
                MazeRunner(CurrentPoint.X, CurrentPoint.Y, 0);
            }
        }
        
        private void MazeRunner(int x, int y, int step)
        {
            if (Maze.IsValidPoint(x, y) && !Maze.IsEndPoint(x, y))
            {
                if (x != StartPoint.X || y != StartPoint.Y)
                {
                    Maze.MarkPoint(x, y);
                }

                MazeRunner(x + 1, y, step + 1);

                if (!IsMazeSolved)
                {
                    MazeRunner(x - 1, y, step + 1);
                }

                if (!IsMazeSolved)
                {
                    MazeRunner(x, y + 1, step + 1);
                }

                if (!IsMazeSolved)
                {
                    MazeRunner(x, y - 1, step + 1);
                }
            }
            else if (Maze.IsEndPoint(x, y))
            {
                IsMazeSolved = true;
                Console.WriteLine("The End Point is Col: " + x + " Row: " + y + " Steps using: " + step);
            }
        }

    }
}
