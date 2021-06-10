using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Visualizer
{
    class MergeSort : ISortEngine
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        private int left;
        private int right;
        Brush BlackBrush = new System.Drawing.SolidBrush(Color.Teal);
        Brush WhiteBrush = new System.Drawing.SolidBrush(Color.PaleGreen);


        public MergeSort(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;
            left = 0;
            right = TheArray.Length - 1;
        }

        public void NextStep()
        {
            Sort(TheArray,left,right);
        }

        private void Sort(int[] TheArray, int left, int right)
        {
            if (left < right)
            {
                // Find the middle
                // point
                int m = left + (right - left) / 2;

                // Sort first and
                // second halves
               
                Sort(TheArray, left, m);
                Sort(TheArray, m + 1, right);

                // Merge the sorted halves
                merge(TheArray, left, m, right);
            }
        }

        private void DrawBar(int position, int height)
        {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, position, MaxVal - TheArray[position], 1, MaxVal);
        }


        public bool IsSorted()
        {
            for (int i = 0; i < TheArray.Count() - 1; i++)
            {
                if (TheArray[i] > TheArray[i + 1]) return false;
            }
            return true;
        }
        public void ReDraw()
        {
            for (int i = 0; i < TheArray.Count() - 1; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(Color.Navy), i, MaxVal - TheArray[i], 1, MaxVal);

            }

        }
        void merge(int[] TheArray, int l, int m, int r)
        {
            
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = TheArray[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = TheArray[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    TheArray[k] = L[i];
                    DrawBar(k, TheArray[k]);
                    Thread.Sleep(1);
                    i++;
                }
                else
                {
                    TheArray[k] = R[j];
                    DrawBar(k, TheArray[k]);
                    Thread.Sleep(1);
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                TheArray[k] = L[i];
                DrawBar(k, TheArray[k]);
                //Thread.Sleep(1);
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                TheArray[k] = R[j];
                DrawBar(k, TheArray[k]);
                //Thread.Sleep(1);
                j++;
                k++;
            }
        }
    }
}
