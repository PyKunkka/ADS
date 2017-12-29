using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppLab21
{
    public class PiramidSort<T>
    {
        private T[] _array;
        private int heapsize;
        private IComparer<T> _comparer;

        public PiramidSort(T[] a, IComparer<T> comparer)
        {
            _array = a;
            heapsize = a.Length;
            _comparer = comparer;
        }

        public void HeapSort()
        {
            build_max_heap();

            for (int i = _array.Length - 1; i > 0; i--)
            {

                T temp = _array[0];
                _array[0] = _array[i];
                _array[i] = temp;

                heapsize--;
                max_heapify(0);
            }
        }

        public T[] GetSortedArray()
        {
            HeapSort();

            return _array;
        }

        private int parent(int i) { return (i - 1) / 2; }
        private int left(int i) { return 2 * i + 1; }
        private int right(int i) { return 2 * i + 2; }

        private void max_heapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int lagest = i;

            if (l < heapsize && _comparer.Compare(_array[l], _array[i]) > 0)
            {
                lagest = l;
            }
            if (r < heapsize && _comparer.Compare(_array[r], _array[lagest]) > 0)
            {
                lagest = r;
            }
            if (lagest != i)
            {
                T temp = _array[i];
                _array[i] = _array[lagest];
                _array[lagest] = temp;

                max_heapify(lagest);
            }
        }

        private void build_max_heap()
        {
            int i = (_array.Length - 1) / 2;

            while (i >= 0)
            {
                max_heapify(i);
                i--;
            }
        }

    }

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y) { return x - y; }
    }
}
