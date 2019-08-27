using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class Program
    {
        public static int C = 0;
        public static int M = 0;
        public static int[] Insert(int[] a)
        {
            int temp, j = 0;
            for (int i = 1; i < a.Length; i++)
            {
                temp = a[i];
                j = i - 1;
                C++;
                while (j >= 0 && a[j] > temp)
                {
                    a[j + 1] = a[j];
                    j--;
                    C++;
                    M++;
                }
                a[j + 1] = temp;
            }
            return a;
            //Console.WriteLine("C: " + C + " M: " + M);
        }
        public static int[] Shell(int[] a)
        {
            int C = 0, M = 0;
            {
                for (int i = 0; i < 4; i++)
                {
                    int[] b = new int[a.Length / 4];
                    for (int k = 0; k < a.Length / 4; k++)
                    {

                        b[k] = a[i + k * 4];

                    }
                    b = Insert(b);
                    for (int k = 0; k < a.Length / 4; k++)
                    {
                        a[i + k * 4] = b[k];
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    int[] b = new int[a.Length / 2];
                    for (int k = 0; k < a.Length / 2; k++)
                    {

                        b[k] = a[i + k * 2];

                    }
                    b = Insert(b);
                    for (int k = 0; k < a.Length / 2; k++)
                    {
                        a[i + k * 2] = b[k];
                    }
                }
                a = Insert(a);
                return a;
            }
        }

        static void Main(string[] args)
        {
            int n;
            int[] a;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Random rand = new Random();
            Console.WriteLine("Введiть величину масива: ");
            n = Convert.ToInt32(Console.ReadLine());
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = (rand.Next(-10, 10));
            }
            Console.WriteLine("Random arrey:\n");
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            int choise = 0;
            Console.WriteLine("\nВиберiть алгоритм:\n1)Insert\n2)Shell");
            choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
                Insert(a);
            else Shell(a);
            sw.Stop();
            Console.WriteLine("C: "+C+"M: "+M);
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds + " ms");
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            Console.ReadKey();
        }
    }
}





