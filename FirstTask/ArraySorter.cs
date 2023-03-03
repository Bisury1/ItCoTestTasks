using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public class ArraySorter : ISorter<int>
    {
        private int[] _inputMas;
        public ArraySorter(int[] inputMas)
        {
            _inputMas = inputMas;
        }

        public int[] Sort()
        {
            QuickSort(0, _inputMas.Length - 1);
            return _inputMas;
        }
        private void QuickSort(int first, int last)
        {
            int f = first, l = last;
            int mid = _inputMas[((l - f) >> 1) + f];
            while (f <= l)
            {
                while (_inputMas[f].CompareTo(mid) < 0 && f < last) f++;
                while (_inputMas[l].CompareTo(mid) > 0 && first < l) l--;
                if (f > l) continue;
                (_inputMas[f], _inputMas[l]) = (_inputMas[l], _inputMas[f]);
                f++;
                l--;
            }
            if (first < l) QuickSort(first, l);
            if (f < last) QuickSort(f, last);
        }
    }


    public interface ISorter<T> where T: IComparable
    {
        T[] Sort();
    }
}
