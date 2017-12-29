using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormAppLab21
{
    class SortMethods
    {
        private List<int> numbers;

        public int[] SortedResult { get; set; }

        public SortMethods(List<int> numbers)
        {
            this.numbers = numbers;
        }

        public TimeSpan PiramidSort()
        {
            var timer = new Stopwatch();
            timer.Start();

            var piramidSort = new PiramidSort<int>(numbers.ToArray(), new IntComparer());
            SortedResult = piramidSort.GetSortedArray();

            timer.Stop();
            return timer.Elapsed;
        }

        public TimeSpan TournirSort()
        {
            var timer = new Stopwatch();
            timer.Start();

            var tournirSorting = new TurnirSorting(numbers.ToArray<int>());
            SortedResult = tournirSorting.GetSortedArray();

            timer.Stop();
            return timer.Elapsed;
        }
    }
}
