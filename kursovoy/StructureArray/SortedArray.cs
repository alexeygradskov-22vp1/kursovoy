using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoy.StructureArray
{
    internal class SortedArray
    {
        private List<string> array;
        private int _size;
        public SortedArray(int size)
        {
            this._size = size;
            array = new List<string>(size);
        }

        public void Add(string value)
        {
            array.Add(value);
        }
        public void sort()
        {
            array.Sort();
        }

        public ResultDTO search(string value)
        {
            int start = Environment.TickCount;
            int count = 0;
            int left = 0;
            int right = array.Count-1;
            while (left <= right)
            {
                int middle =left+ (right - left) / 2;
                count++;
                int comparisonResult = string.Compare(array[middle], value);
                if (comparisonResult == 0)
                {
                  
                    return new ResultDTO(Environment.TickCount-start, count, true);
                }
                else if (comparisonResult < 0)
                {
                  
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
       
            return new ResultDTO(Environment.TickCount - start, count, false);

        }
    }
}

