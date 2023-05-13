using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.WriteAllText("output.txt",string.Empty);

            var linie = File.ReadAllLines("input.txt").ToList();
            var nr = Int32.Parse(linie[0]);
            var numere = linie[1].Split(' ').Select(Int32.Parse).ToList();

            int[] Vect=new int[nr];

            for (int i=0;i<nr;i++)
            {
                Vect[i] = numere[i];
            }

            

             int[] LIS(int[] a, int n)
            {
                int[] lung = new int[n];
                lung[n - 1] = 1;

                for (int i = n - 2; i >= 0; i--)
                {
                    int max = 0;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (a[i] <= a[j])
                        {
                            if (max < lung[j])
                            {
                                max = lung[j];
                            }
                        }
                    }
                    lung[i] = max + 1;
                }

                return lung;
            }

           
             void TipLIS(int[] a, int n, int[] lung)
            {
                int max = lung[0];
                int poz = 0;

                for (int i = 1; i < n; i++)
                {
                    if (max < lung[i])
                    {
                        max = lung[i];
                        poz = i;
                    }
                }

                Console.WriteLine("Lungimea maximă este " + max);
                Console.WriteLine("Iar subsecvenţa este:");

                Console.Write(a[poz] + " ");
                for (int i = poz + 1; i < n; i++)
                {
                    if (lung[i] == max - 1 && a[i] >= a[poz])
                    {
                        Console.Write(a[i] + " ");
                        poz = i;
                        max--;
                    }
                }

                Console.WriteLine();
            }

            var raspuns = LIS(Vect, nr);
            TipLIS(Vect,nr, raspuns);
            File.AppendAllText("output.txt", string.Join(" ", raspuns));

            Console.ReadLine();
        }
    }
}
