using System;

namespace SchulzeMethod
{
    class Program
    {
        public static int Min = int.MinValue;
        static void Main(string[] args)
        {
            int[,] Graph = new int[5, 5]
            {
                { 0,18,Min,21,21},
                { Min,0,Min,17,19},
                { 19,16,0,Min,Min},
                { Min,Min,20,0,30},
                { Min,Min,20,Min,0}
            };


            //int[,] Graph = new int[5,5]
            //{
            //    { 0,Min,26,30,Min},
            //    { 25,0,Min,33,Min},
            //    { Min,29,0,Min,24},
            //    { Min,Min,28,0,Min},
            //    { 23,27,Min,31,0}
            //};

            dijkstra(Graph, 4);
            Console.ReadLine();

        }

        public static int[] dijkstra(int[,] weight, int start)
        {
            int n = weight.GetLength(1); //顶点个数
            int[] shortPath = new int[n]; // 保存start到其他个点的最短路径
            String[] path = new string[n];

            for (int i = 0; i < n; i++)
            {
                path[i] = new string(start + "-->" + i);
            }
            int[] visited = new int[n];

            shortPath[start] = 0;
            visited[start] = 1;

            for (int count = 1; count < n; count++)
            {
                int k = -1; // 选出一个距离初始顶点start最近的未标记顶点
                int defeat = 0;
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == 0 && weight[start,i] > defeat)
                    {
                        defeat = weight[start,i];
                        k = i;
                    }
                }

                shortPath[k] = defeat;
                visited[k] = 1;

                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == 0 && weight[k, i] != Min)
                    {
                        if (weight[start, k] <= weight[k, i])
                        {
                            if (weight[start, i] <= weight[start, k])
                            {
                                weight[start, i] = weight[start, k];
                                path[i] = path[k] + "-->" + i;
                            }  
                        }
                        else
                        {
                            if (weight[start, i] <= weight[k, i])
                            {
                                weight[start, i] = weight[k, i];
                                path[i] = path[k] + "-->" + i;
                            }
                        }                                              
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("From " + start + " to " + i + " shortest path: " + path[i]);
            }
            Console.WriteLine("======================================================");
            return shortPath;
        }
    }
}
