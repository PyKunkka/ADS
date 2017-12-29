using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
         ___ Вариант 5____
Дано два непересекающихся линейных списка. 
В списке №1 имеется указатель t, в списке №2 – указатель х. 
Вставить в список №1 после указателя t все узлы списка №2, следующие после указателя х.
*/


namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();    // создание первого списка 

            numbers.Add("one");                         // инициализация списка
            numbers.Add("two");
            numbers.Add("three");
            numbers.Add("four");
            numbers.Add("five");

            Console.Write("List#1: ");

            foreach (string word in numbers)                // вывод 1 списка
                Console.Write(word + " ");

            List<string> dinosaurs = new List<string>();    // создание 2 списка

            dinosaurs.Add("Tyrannosaurus");                 // инициализация списка
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            Console.Write("\nList#2: ");

            foreach (string dino in dinosaurs)              // вывод 1 списка
                Console.Write(dino + " ");

            Console.WriteLine("\n");

            List<string> Result = new List<string>();


            Console.WriteLine("Введите (t) номер эл. для 1 списка, после которого добавить 2 список.");
            int list1T = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите (x) номер эл. для 2 списка, после которого мы все эл. добавим в 1 список.");
            int list2X = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numbers.Count; i++)
            {
                Result.Add(numbers[i]);

                if(i == list1T)
                {
                    for (int k = list2X + 1; k < dinosaurs.Count; k++)
                    {
                        Result.Add(dinosaurs[k]);
                    }
                }
            }

            foreach (string words in Result)
                Console.Write(words + " ");

            Result.Clear();

        }
    }
}
