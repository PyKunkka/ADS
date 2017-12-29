using System;
using System.Timers;
using System.IO;
using System.Collections.Generic;

/*
 
  6.	Смоделировать очередь в супермаркете. 
 Новые покупатели (элементы) подходят к кассе и становятся в очередь с интервалом от 3 до 10 условных единиц времени (random). 
 Кассирша обслуживает клиента (выборка из очереди) с интервалом от 5 до 12 условных единиц времени (random). 
 Сообщить менеджеру количество людей в очереди через заданное количество условных единиц времени. 
 Для программной реализации в качестве условных единиц времени использовать секунды.    
        
*/


namespace Laba2
{ 
    class Program
    {
        static SuperMarket superMarket;
        static void Main(string[] args)
        {
            Console.WriteLine("Input seconds.");

            int finishTime = Convert.ToInt32(Console.ReadLine());

            superMarket = new SuperMarket();
            superMarket.SimulationFinishedEvent += SuperMarket_SimulationFinishedEvent;
            superMarket.Start(finishTime);
            Console.WriteLine(string.Format("\nStarting simulation time is: {0}\n", DateTime.Now.ToLocalTime()));
            Console.ReadLine();   
        }

        private static void SuperMarket_SimulationFinishedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("\nCount of people that left in queue: " + superMarket.GetPeopleCount());
        }
    }
}
