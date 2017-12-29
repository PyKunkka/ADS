using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppLab21
{
    static class Consts
    {
        public static Int32 N;
    }

    class TurnirSorting
    {
        private Int32[] A;

        public TurnirSorting(int[] array) {
            A = array;
            Consts.N = A.Length;

            A = new int[Consts.N + 1];

            for (var i = 0; i < array.Length; i++)
            {
                A[i + 1] = array[i];
            } 
        }


        private void Initialize(Int32[] tree, Int32 size)
        {
            Int32 j = 1, k;

            while (j <= Consts.N)
            {
                tree[size + j - 1] = A[j];
                j++;
            }
            for (j = size + Consts.N; j <= 2 * size - 1; j++)
            {
                tree[j] = Int32.MinValue;
            }

            j = size;
            while (j <= 2 * size - 1)
            {
                if (tree[j] >= tree[j + 1])
                {
                    tree[j / 2] = j;
                }
                else
                {
                    tree[j / 2] = j + 1;
                }

                j += 2;
            }

            k = size / 2;
            while (k > 1)
            {
                j = k;
                while (j <= 2 * k - 1)
                {
                    if (tree[tree[j]] >= tree[tree[j + 1]])
                    {
                        tree[j / 2] = tree[j];
                    }
                    else
                    {
                        tree[j / 2] = tree[j + 1];
                    }
                    j += 2;
                }
                k /= 2;
            }
        }
        private void Readjust(Int32[] tree, ushort i)
        {
            unchecked
            {
                ushort j;

                if ((i % 2) != 0)
                {
                    tree[i / 2] = i - 1;
                }
                else
                {
                    tree[i / 2] = i + 1;
                }

                i /= 2;
                while (i > 1)
                {
                    if ((i % 2) != 0)
                    {
                        j = (ushort)(i - 1);
                    }
                    else
                    {
                        j = (ushort)(i + 1);
                    }
                    if (tree[tree[i]] > tree[tree[j]])
                    {
                        tree[i / 2] = tree[i];
                    }
                    else
                    {
                        tree[i / 2] = tree[j];
                    }
                    i /= 2;
                }
            }
        }

        public int[] GetSortedArray()
        {
            unchecked
            {
                const Int32 size = 128;
                Int32[] tree = new Int32[256];
                Int32 k;
                ushort i;

                Initialize(tree, size);

                for (k = Consts.N; k >= 2; k--)
                {
                    i = (ushort)tree[1];
                    A[k] = tree[i];
                    tree[i] = Int32.MinValue;
                    Readjust(tree, i);
                }
                A[1] = tree[tree[1]];
            }

            return A.Skip(1).ToArray<int>();
        }
    }
}
