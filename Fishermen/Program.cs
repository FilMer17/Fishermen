using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishermen
{
    class Program
    {
        const int Size = 1000;
        static bool[,] pond = new bool[Size, Size];
        static List<int> amount = new List<int>();

        static void Main(string[] args)
        {
            FishGeneration();
            CheckAmount();
            Console.WriteLine(FindBest());
            Console.ReadLine();
        }

        static void FishGeneration()
        {
            Random rnd = new Random();

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    pond[x, y] = rnd.NextDouble() > 0.5;
                }
            }
        }

        static void CheckAmount()
        {
            int temp = 0;
            for (int i = 1; i <= Size / 10; i++)
            { 
                for (int j = 1; j <= Size / 10; j++)
                {
                    temp = 0;

                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (pond[x * i, y * j])
                                temp++;
                        }
                    }

                    amount.Add(temp);
                }
            }
        }

        static string FindBest()
        {
            int temp = 0;
            int bestInt = 0;
            int times = -1;
            string best = "";

            for (int t = 0; t < 97; t++)
            {
                for (int u = 0; u < 97; u++)
                {
                    temp = 0;
                    times++;
                    for (int i = times; i < times + 3; i++)
                    {
                        temp += amount[i];
                    }
                    for (int i = times; i < times + 3; i++)
                    {
                        temp += amount[i + 100];
                    }
                    for (int i = times; i < times + 3; i++)
                    {
                        temp += amount[i + 200];
                    }
                    if (bestInt < temp)
                    {
                        bestInt = temp;
                        best = $"pozice: [{t}, {u}]";
                    }
                }
            }

            return best;
        }
    }
}
