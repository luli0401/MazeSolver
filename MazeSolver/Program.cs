using MazeSolver.Processor;
using MazeSolver.Service;

namespace MazeSolver
{
    class Program
    {
        private const string FILE_NAME = "F:\\Maze1.txt";

        static void Main(string[] args)
        {
            FirstWayToResolveMaze();
            SecondWayToResolveMaze();
        }

        /* 
         * This is the first method came to my mind. 
         * Resolve the maze like a human walking in the maze. 
         * When there is a fork in the road, take one path.
         * If it's a dead end, come back to the fork and take another path.
         * keep this loop unitl we find the end point.
         * So I call it HumanProcessor.
         */
        private static void FirstWayToResolveMaze()
        {
            var maze = MazeService.InitialMaze(FILE_NAME);

            if (maze != null)
            {
                HumanMazeProcessor processor = new HumanMazeProcessor();
                processor.SolveMaze(maze);

                MazeService.OutputMaze(maze.MazeMatrix, "F:\\MazeSolution1.txt");
            }
        }

        /* 
         * After I finished the first method, I try to think this problem again 
         * (because I like solving puzzle games as I mentioned in the interview), 
         * and I came up with another solution.
         * This method will like an AI calculating the maze. 
         * It will try to check the four directions of one point, 
         * and then recursively check the four directions of the next point 
         * until it finds the end point.
         * So I call it AIProcessor.
         */
        private static void SecondWayToResolveMaze()
        {
            var maze = MazeService.InitialMaze(FILE_NAME);

            if (maze != null)
            {
                AIMazeProcessor processor = new AIMazeProcessor();
                processor.SolveMaze(maze);

                MazeService.OutputMaze(maze.MazeMatrix, "F:\\MazeSolution2.txt");
            }
        }

    }
}
