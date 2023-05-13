using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregLCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.WriteAllText("output.txt", string.Empty);
            var line = File.ReadLines("input.txt").ToList();
            var nr = Int32.Parse(line[0]);
            var numere = line[1].Split(' ').Select(Int32.Parse).ToList();

            int[] vector = new int[nr];
            for (int i = 0; i < nr; i++)
            {
                vector[i] = numere[i];
            }
            var nr1 = Int32.Parse(line[2]);
            var numere1 = line[3].Split(' ').Select(Int32.Parse).ToList();

            int[] vector1 = new int[nr1];
            for (int i = 0; i < nr1; i++)
            {
                vector1[i] = numere1[i];
            }

            int[,] LCS(int[] a, int[] b)
            {
                int n = a.Length, m = b.Length;
                int[,] lung = new int[n, m];
                lung[0, 0] = (a[0] == b[0]) ? 1 : 0;
                for (int j = 1; j < m; j++)
                    lung[0, j] = (a[0] == b[j]) ? 1 : lung[0, j - 1];
                for (int i = 1; i < n; i++)
                    lung[i, 0] = (a[i] == b[0]) ? 1 : lung[i - 1, 0];
                for (int i = 1; i < n; i++)
                    for (int j = 1; j < m; j++)
                        lung[i, j] = Math.Max(
                        (a[i] == b[j]) ? lung[i - 1, j - 1] + 1 : lung[i - 1, j - 1],
                        Math.Max(lung[i - 1, j], lung[i, j - 1])
                        );
                return lung;
            }
            /// <summary>
            /// Tipareste subsecventa crescatoare comuna subsirurilor a si b.
            /// </summary>
            void TipLCS(int[] a, int[] b, int[,] lung)
            {
                List<int> subsecventa = new List<int>();
                int i = a.Length - 1;
                int j = b.Length - 1;
                while (i >= 0 && j >= 0)
                {
                    if (a[i] == b[j])
                    {
                        subsecventa.Add(a[i]);
                        i--; j--;
                    }
                    else
                    if (i >= 1 && lung[i - 1, j] == lung[i, j]) i--;
                    else if (j >= 1 && lung[i, j - 1] == lung[i, j]) j--;
                }
                subsecventa.Reverse();
                foreach (int x in subsecventa)
                    Console.Write(x + ", ");
            }
            
            TipLCS(vector, vector1, LCS(vector, vector1));
            Console.ReadLine();
        }
    }
}
