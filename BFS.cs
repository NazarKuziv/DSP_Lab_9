using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_9
{
    internal class BFS
    {
        string[,] mat = null;
        int n = 0;

        public string[,] Search(Adjacency AdjacencyMat, int[,] matrix, int point)
        {
            Queue<int> Queue = new Queue<int>();
            Dictionary<int, int> Dictionary = new Dictionary<int, int>();

            this.n = AdjacencyMat.GetN();

            String[,] Table = new string[n * 2 + 1, 3];

            Dictionary.Add(point, 1);
            Queue.Enqueue(point);

            Table[1, 0] = Queue.Peek().ToString();
            Table[1, 1] = 1.ToString();
            string joinedString = String.Join(",", Queue);
            Table[1, 2] = joinedString;

            int BFSNum = 2;
            bool isFound = false;
            int pointer;

            for (int itr = 2; Queue.Count > 0; itr++)
            {
                pointer = Queue.Peek();
                isFound = false;
                for (int i = 1; i < n + 1; i++)
                {
                    if (matrix[pointer, i] == 1 && pointer != i)
                    {
                        if (!Dictionary.ContainsKey(i))
                        {
                            Dictionary.Add(i, BFSNum);
                            Queue.Enqueue(i);

                            Table[itr, 0] = i.ToString();
                            Table[itr, 1] = BFSNum.ToString();
                            BFSNum++;
                            isFound = true;
                            break;
                        }
                    }
                }
                if (!isFound)
                {
                    Table[itr, 0] = "-";
                    Table[itr, 1] = "-";
                    Queue.Dequeue();
                }
                joinedString = String.Join(",", Queue);
                Table[itr, 2] = joinedString;
            }
            this.mat = Table;
            return Table;
        }
        public void PrintResult()
        {
            for (int i = 1; i < this.n * 2 + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{this.mat[i, j],20}");
                }
                Console.WriteLine();
            }
        }
    }
}
