using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Poker
{
    internal class Program
    {
        static int Calculation(List<int> list_)
        {
            //среднее
            var mean = list_.Sum() / list_.Count();
            for (int i = 0; i < list_.Count; i++)
            {
                list_[i] -= mean;
            }



            //кумулятивная сумма элементов
            int sum_c = 0;
            List<int> list_cs = new List<int> {};
            foreach (var item in list_)
            {
                list_cs.Add(item + sum_c);
                sum_c += item;
            }

            //ищем медиану
            var med = ((int)Median(list_cs));
            for (int i = 0; i < list_cs.Count; i++)
            {
                list_cs[i] = Math.Abs(list_cs[i] - med);
            }
            return list_cs.Sum();
        }

        static decimal Median(List<int> source)
        {
            int[] temp = source.ToArray();
            Array.Sort(temp);

            int count = temp.Length;
            if (count % 2 == 0)
            {
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                return temp[count / 2];
            }
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Input:");
                List<int> list_int = new List<int> { };

                Stream inputStream = Console.OpenStandardInput();
                byte[] bytes = new byte[10000];
                int outputLength = inputStream.Read(bytes, 0, 10000);
                char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);

                var s = new string(chars);

                try
                {
                    list_int = Array.ConvertAll(s.Trim().Split(','), Convert.ToInt32).ToList();
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

                //List<int> list_cs = new List<int> { 22, 2, 16, 11, 10, 16, 18, 27, 20, 9, 17, 24, 26, 5, 3, 2, 22, 6, 22, 26, 7, 3, 10, 23, 0, 17, 11, 29, 9, 6, 16, 5, 25, 3, 8, 14, 17, 0, 22, 16, 29, 17, 2, 4, 18, 1, 15, 17, 15, 19, 6, 6, 15, 14, 9, 14, 30, 19, 28, 4, 9, 18, 18, 1, 7, 4, 23, 1, 24, 15, 4, 1, 3, 28, 20, 20, 21, 0, 12, 26, 8, 17, 10, 29, 5, 9, 6, 2, 12, 7, 15, 18, 10, 16, 25, 30, 26, 7, 27, 39 };
                Console.WriteLine($"{Calculation(list_int)}"); 
            }
        }
    }
}
