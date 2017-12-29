using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов в массиве: ");

            int num = Convert.ToInt16(Console.ReadLine());
            int[] array = new int[num];
            int temp;

            for (int i = 0; i < array.Length; i++)                // Заполнение массива заданными значениями
            {
                Console.WriteLine("Введите {0} элемент массива.", i);
                array[i] = Convert.ToInt16(Console.ReadLine());
            }

            for (int i = 0; i < array.Length; i++)            // Сортировка методом пузырька
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }


            Console.WriteLine("Сортированный массив: ");          // Вывод сортированного массива
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }
    }
}

