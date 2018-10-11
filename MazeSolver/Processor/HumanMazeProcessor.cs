using MazeSolver.Model;
using System;
using System.Collections.Generic;

namespace MazeSolver.Processor
{
    public class HumanMazeProcessor
    {
        //Properties
        private Maze Maze { get; set; }
        private Coordinate CurrentPoint { get; set; }
        private Coordinate StartPoint { get; set; }
        private Stack<Coordinate> PointTracker { get; set; }
        private bool IsMazeSolved { get; set; }


        //Constructor
        public HumanMazeProcessor()
        {
            IsMazeSolved = false;
            PointTracker = new Stack<Coordinate>();
        }


        //Helper Methods
        internal void SolveMaze(Maze maze)
        {
            Maze = maze;
            StartPoint = maze.FindStartPoint();
            CurrentPoint = StartPoint;

            if (CurrentPoint != null)
            {
                MazeSolver();
            }
        }

        private void MazeSolver()
        {
            while(!IsMazeSolved)
            {
                if(Maze.IsEndPoint(CurrentPoint.X, CurrentPoint.Y))
                {
                    IsMazeSolved = true;
                    Console.WriteLine("The End Point is Col: " + CurrentPoint.X + " Row: " + CurrentPoint.Y);
                    break;
                }

                if(PointTracker.Count != 0)
                {
                    if (CurrentPoint.X != StartPoint.X || CurrentPoint.Y != StartPoint.Y)
                    {
                        Maze.MarkPoint(CurrentPoint.X, CurrentPoint.Y);
                    }

                    CurrentPoint = PointTracker.Pop();
                }

                if (Maze.IsValidPoint(CurrentPoint.X + 1, CurrentPoint.Y))
                {
                    PointTracker.Push(new Coordinate(CurrentPoint.X + 1, CurrentPoint.Y));
                }

                if (Maze.IsValidPoint(CurrentPoint.X - 1, CurrentPoint.Y))
                {
                    PointTracker.Push(new Coordinate(CurrentPoint.X - 1, CurrentPoint.Y));
                }

                if (Maze.IsValidPoint(CurrentPoint.X, CurrentPoint.Y + 1))
                {
                    PointTracker.Push(new Coordinate(CurrentPoint.X, CurrentPoint.Y + 1));
                }

                if (Maze.IsValidPoint(CurrentPoint.X, CurrentPoint.Y - 1))
                {
                    PointTracker.Push(new Coordinate(CurrentPoint.X, CurrentPoint.Y - 1));
                }               
            }
        }

      
    }
}
