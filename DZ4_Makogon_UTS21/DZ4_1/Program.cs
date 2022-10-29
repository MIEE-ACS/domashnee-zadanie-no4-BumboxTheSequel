using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива:");
            int arrlen = int.Parse(Console.ReadLine());
            double arrmin = 101;
            Random rand = new Random();
            double[] arr = new double[arrlen];
            int countNeg = 0;
            double summ = 0;
            double Backup;
            for (int i = 0; i < arrlen; i++)
            {
                arr[i] = rand.Next(-20, 20) / 10.0; // максимально число 100, минимальное - -100
            }
            Console.Write("\n");
            Console.WriteLine("Массив:");
            for (int i = 0; i < arrlen; i++)
            {
                Console.Write("{0:0.0} \t", arr[i]);
            }
            for (int i = 0; i < arrlen; i++)
            {
                if (arr[i] < arrmin)
                {
                    arrmin = arr[i];
                }
            }
            Console.WriteLine("\n номер минимального элемента массива:\n {0:0.0}", arrmin);
            for (int i = 0; i < arrlen; i++)
            {
                if (arr[i] < 0)
                {
                    countNeg += 1;
                }
                else
                if (countNeg == 1)
                {
                    summ += arr[i];
                }
                else if (countNeg > 1)
                {
                    break;
                }
            }
            Console.Write("\n Сумма чисел между первым и втрорым отрицательными числами:\n{0:0.0} \n", summ);
            for (int i = 0; i < arrlen - 1; i++)
            {
                
                if ((Math.Abs(arr[i]) >= 1) && (Math.Abs(arr[i+1]) < 1)) // программа проверяет, есть ли впереди число, удовлетворяющее критерию. При если данное число, на котором остановился цикл, не удовлетворять критериям подбора числа. В противном случае циул просто "перешагнёт" число.
                {
                    Backup = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = Backup;
                    while (i != 0) //число перемещается в самый конец массива, и так происходит с каждым найденным числом. После этого цикл обнуляется и считает заново.
                    {
                        i -= 1;
                        Backup = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = Backup;
                    }
                }
            }
            Console.WriteLine("Массив после сортировки:");
            for (int i = 0; i < arrlen; i++)
            {
                Console.Write("{0:0.0} \t", arr[i]);
            }
        }
        }
}
