using MazeSolver.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MazeSolver.Service
{
    public class MazeService
    {
        internal static Maze InitialMaze(string fileName)
        {
            var mazeMatrix = new List<string>();
            Maze maze = null;

            try
            {
                StreamReader sr = new StreamReader(fileName);
                string line = sr.ReadLine();

                while (line != null)
                {
                    mazeMatrix.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            if (mazeMatrix.Count > 0)
            {
                maze = new Maze(mazeMatrix);
            }

            return maze;
        }

        internal static void OutputMaze(List<string> mazeMatrix, string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);

                foreach (var line in mazeMatrix)
                {
                    sw.WriteLine(line);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
