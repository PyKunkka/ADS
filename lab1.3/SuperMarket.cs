using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Laba2
{
    class SuperMarket
    {
        Queue<DateTime> peopleQueue = new Queue<DateTime>();
        Timer peopleComingTimer;
        Timer cashDequeueTimer;
        private EventHandler simulationFinishedEventHandler;
        int finishTime = 0;

        public event EventHandler SimulationFinishedEvent
        {
            add
            {
                simulationFinishedEventHandler += value;
            }
            remove
            {
                simulationFinishedEventHandler -= value;
            }
        }


        public void Start(int finishTime)
        {
            this.finishTime = finishTime;
            var timer = GetTimer(finishTime);

            timer.Elapsed += SimulationFinished;
            SetPeopleComingTimer();
            SetCashDequeueTimer();
            timer.Start();

        }

        private void SimulationFinished(object sender, ElapsedEventArgs e)
        {
            this.peopleComingTimer.Stop();
            this.cashDequeueTimer.Stop();
            simulationFinishedEventHandler(this, e);
        }

        private void GenerateNewPeople(DateTime time)
        {
            this.peopleQueue.Enqueue(time);
        }

        private void CashDequeue()
        {
            this.peopleQueue.Dequeue();
        }

        private void SetPeopleComingTimer()
        {
            int peopleComingInterval = GetRandomNumber(3,10);
            this.peopleComingTimer = GetTimer(peopleComingInterval);

            this.peopleComingTimer.Elapsed += OnPeopleComingEvent;
            this.peopleComingTimer.Start();
        }

        private void SetCashDequeueTimer()
        {
            int cashDequeueInterval = GetRandomNumber(5,12);
            cashDequeueTimer = GetTimer(cashDequeueInterval);

            cashDequeueTimer.Elapsed += OnCashDeskDequeue;
            cashDequeueTimer.Start();
        }

        private Timer GetTimer(int seconds)
        {
            var result = new Timer(seconds * 1000);

            result.AutoReset = false;
            result.Enabled = true;

            return result;
        } 

        private void OnCashDeskDequeue(object sender, ElapsedEventArgs e)
        {
            CashDequeue();
            PrintQueue();
            SetCashDequeueTimer();
        }

        private void OnPeopleComingEvent(object sender, ElapsedEventArgs e)
        {
            GenerateNewPeople(e.SignalTime);
            PrintQueue();
            SetPeopleComingTimer();
        }

        private int GetRandomNumber(int start, int end)
        {
            Random num = new Random();
            return num.Next(start, end);
        }

        public int GetPeopleCount()
        {
            return peopleQueue.Count;
        }

        void PrintQueue() {
            foreach (var p in peopleQueue) {
                var output = string.Format("({0}:{1}:{2})", p.Hour, p.Minute, p.Second);
                Console.Write(output);
            }
            if (peopleQueue.Count == 0)
            {
                Console.WriteLine("\n(Empty queue)");
            }
            else {
                Console.WriteLine();
            }
            
        }
    }
}
