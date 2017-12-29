using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\"Я программа которая сортирует массив методом вставки. Created by Oleksandr Kozachuk 2017 v2.0\"");
            Console.WriteLine("--------------Для заполнения массива в вручную введите 1.---------"
                + "\n--Для заполнения массива случайными числами с случайным размером введите 2.--");

            int answer = Convert.ToInt16(Console.ReadLine());
            there: switch (answer)
            {
                case 1:

                    try
                    {
                        int Vflag = 0;
                        Console.WriteLine("Введите количество элементов в массиве: ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        int[] array = new int[count];

                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine("Введите {0} элемент массива: ", i);
                            array[i] = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine("Количество элементов в массиве = {0}", count);
                        Console.Write("Заданный вами массив: ");

                        foreach (int x in array)
                            Console.Write(x + " ");

                        Console.WriteLine();
                        Console.Write("Сортированный массив методом вставки (Inserting Sort): ");

                        var date1 = DateTime.Now;

                        for (int i = 1; i < array.Length; i++)
                        {

                            if (Vflag != 0)
                            {
                                int cur = array[i];
                                int j = i;
                                while (j > 0 && cur < array[j - 1])
                                {
                                    array[j] = array[j - 1];
                                    j--;
                                    Vflag++;
                                }
                                array[j] = cur;
                            }
                        }

                        var date2 = DateTime.Now;

                        foreach (int x in array)
                            Console.Write(x + " ");

                        TimeSpan span = date2 - date1;
                        double seconds = span.TotalSeconds;

                        Console.WriteLine("\nВремя роботы программы = {0}", seconds);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Не соответствуют форматы ввода.\n");
                        Console.WriteLine("Запустить программу ещё раз, введите (Eng) y/n.");
                        char answer2 = Convert.ToChar(Console.ReadLine());

                        if (answer2 == 'y')
                            goto there;
                        else
                        {
                            Console.WriteLine("OK, Bye");
                            break;
                        }
                    }
                    break;

                case 2:

                    Random RandomNum = new Random();

                    int num = RandomNum.Next(1, 10);
                    int[] arrayR = new int[num];

                    for (int i = 0; i < arrayR.Length; i++)
                    {
                        arrayR[i] = RandomNum.Next(-100, 100);
                    }

                    Console.WriteLine("Количество элементов в массиве = {0}", num);
                    Console.Write("Заданный вами массив: ");

                    foreach (int x in arrayR)
                        Console.Write(x + " ");

                    Console.WriteLine();
                    Console.Write("Сортированный массив методом вставки (Inserting Sort): ");

                    var date3 = DateTime.Now;

                    for (int i2 = 1; i2 < arrayR.Length; i2++)
                    {
                        int cur2 = arrayR[i2];
                        int j2 = i2;
                        while (j2 > 0 && cur2 < arrayR[j2 - 1])
                        {
                            arrayR[j2] = arrayR[j2 - 1];
                            j2--;
                        }
                        arrayR[j2] = cur2;
                    }

                    var date4 = DateTime.Now;

                    foreach (int x in arrayR)
                        Console.Write(x + " ");

                    TimeSpan span1 = date4 - date3;
                    double seconds1 = span1.TotalSeconds;

                    Console.WriteLine("\nВремя роботы программы = {0}", seconds1);
                    break;
            }
        }
    }
}