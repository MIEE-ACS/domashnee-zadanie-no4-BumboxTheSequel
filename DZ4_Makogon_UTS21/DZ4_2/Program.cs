using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_2
{
    internal class Program
    {
        //ВАРИАНТ 8!
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк и столбцов:");
            int k = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[k, m];
            int Backup;
            int summ = 0;
            int summFull = 0;
            Random rand = new Random();
            int[] charac = new int[m];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }
            Console.WriteLine("Двумерная матрица:");
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("\n");  
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0:00}\t",arr[i, j]);   
                }
            }
            for (int i = 0; i < m;i++) // cоставление матрицы характеристик
            {
                for (int j = 0; j < k; j++)
                {
                    if ((arr[j, i] % 2 == -1) && (arr[j,i] < 0))
                    {
                        summ += Math.Abs(arr[j, i]);
                    }
                }
                charac[i] = summ;
                summ = 0;
            }
            for (int i = 0; i < m-1; i++)
            {
                if (charac[i] > charac[i+1]) // cортировка матрицы характеристик, а затем и столбцов в двумерной матрице
                {
                    Backup = charac[i + 1];
                    charac[i + 1] = charac[i];
                    charac[i] = Backup;
                    for (int j = 0; j < k; j++)
                    {
                        Backup = arr[j, i + 1];
                        arr[j, i+1] = arr[j, i];
                        arr[j, i] = Backup;
                    }
                    i = -1;
                }
              
            }
            Console.WriteLine("\nДвумерная матрица после сортировки:");
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0:00}\t", arr[i, j]);
                }
            }
            for (int i = 0; i < m; i++) // Расчёт и печать сумм элементов столбцов с отрицательными элементами
            {
                for (int j = 0; j < k; j++)
                {
                    if ((arr[j, i] < 0))
                    {
                        for (int n = 0; n < k; n++)
                        {
                            summFull += arr[n, i];
                        }
                        break;
                    }
                }
                Console.Write("\n Cумма всех элементов для {0:0}-го столбца:\n", i + 1);
                Console.WriteLine(summFull);        
                summFull = 0;
            }
        }
    }
}
