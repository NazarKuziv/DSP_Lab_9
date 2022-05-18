using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            FileViewer file = new FileViewer();
            int[,] graf = file.ReadFile();
            Adjacency AdjacencyMat = new Adjacency();

            BFS bfs = new BFS();
            bfs.Search(AdjacencyMat, AdjacencyMat.CreateMatrix(file, graf),1);
            Console.WriteLine(" Обхід графа пошуком вшир:\n");
            bfs.PrintResult();
        }
    }
}
