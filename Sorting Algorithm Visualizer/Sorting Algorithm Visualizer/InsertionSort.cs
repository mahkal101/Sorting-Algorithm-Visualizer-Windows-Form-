using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Visualizer
{
    class InsertionSort: ISortEngine
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        Brush BlackBrush = new System.Drawing.SolidBrush(Color.Teal);
        Brush WhiteBrush = new System.Drawing.SolidBrush(Color.PaleGreen);





        public InsertionSort(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;
        }

        public void NextStep()
        {

            int n = TheArray.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = TheArray[i];
                int j = i - 1;

                // Move elements of TheArray,
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && TheArray[j] > key)
                {
                    TheArray[j + 1] = TheArray[j];
                    DrawBar(j, TheArray[j]);
                    j = j - 1;
                }
                TheArray[j + 1] = key;
                DrawBar(i, TheArray[i]);
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
    }
}
