using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Poker
{
    internal class Program
    {
        static void Calc(List<int> list_)
        {
            //среднее 
            var mean = list_.Sum() / list_.Count();
            
            //Console.WriteLine($"сумма {sum}");
            //Console.WriteLine($"среднее {mean}");

            List<int> list_c = new List<int> {};


            //for (int i = 0; i < list_.Count; i++) {
            //    list_c.Add(list_[i] - mean);
            //}

            foreach (var item in list_)
            {
                list_c.Add(item - mean);
            }

            //кумулятивная сумма элементов
            int sum_c = 0;
            List<int> list_cs = new List<int> {};
            //for (int i = 0; i < list_c.Count; i++)
            //{
            //   list_cs.Add(list_c[i] + sum_c);
            //   sum_c = sum_c + list_c[i];
            //}

            foreach (var item in list_c)
            {
                list_cs.Add(item + sum_c);
                sum_c = sum_c + item;
            }

            //ищем медиану
            //for (int i = 0; list_cs.Count > i; i++)
            //{
            //    Console.WriteLine($"{list_c[i]} \t {list_cs[i]}");
            //}

            //foreach (var item in list_cs)
            //{
            //    Console.WriteLine($"\t{item}");
            //}

            var med = ((int)Median(list_cs));

            Console.WriteLine($"медианна {med}");

            for (int i = 0; i < list_cs.Count; i++)
            {
                list_cs[i] = Math.Abs(list_cs[i] - med);
            }

            //for (int i = 0; list_cs.Count > i; i++)
            //{
            //    Console.WriteLine($"\t {list_cs[i]}");
            //}

            var ret = list_cs.Sum();
            Console.WriteLine($"{ret}");

        }

        static decimal Median(List<int> source)
        {
            int[] temp = source.ToArray();
            Array.Sort(temp);

            int count = temp.Length;
            if (count % 2 == 0)
            {
                // count is even, average two middle elements
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }



        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input:");

                List<int> list_int = new List<int> { };

                try
                {
                    list_int = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32).ToList();
                }
                catch {
                    Console.WriteLine($"Enter the data in the format: 1,2,3,4,5");
                    continue;
                }

                if (list_int.Min() < 0)
                {
                    Console.WriteLine($"The number of chips cannot be negative or equal to 0");
                    continue;
                }

                Calc(list_int);

            }
            
        }
    }
}
