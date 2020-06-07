using System;
using System.Collections.Generic;
using System.Linq;

namespace KataRange
{
    public class Overlaps
    {
        public class Interval
        {
            public int start;
            public int end;
            public Interval(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        };

        public static bool isOverlap(Interval[] arr, int size)
        {
            int max_ele = 0;

            for (int i = 0; i < size; i++)
            {
                if (max_ele < arr[i].end)
                    max_ele = arr[i].end;
            }
 
            int[] aux = new int[max_ele + 1];
            for (int i = 0; i < size; i++)
            {
 
                int x = arr[i].start;

                int y = arr[i].end;
                aux[x]++;
                aux[y]--;
            }

            for (int i = 1; i <= max_ele; i++)
            {
                aux[i] += aux[i - 1];

                // Overlap  
                if (aux[i] > 1)
                    return true;
            }
            return false;
        }
    }
}
