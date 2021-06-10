using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Visualizer
{
    class BubbleSort : ISortEngine
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        Brush BlackBrush = new System.Drawing.SolidBrush(Color.Teal);
        Brush WhiteBrush = new System.Drawing.SolidBrush(Color.PaleGreen);





        public BubbleSort(int[] TheArray_In, Graphics g_In, int MaxVal_In) 
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;
        }

        public void NextStep()
        {

            for (int i = 0; i < TheArray.Count() - 1; i++)
            {
                if (TheArray[i] > TheArray[i + 1])
                {
                    Swap(i);
                }
            }
        }

        private void Swap(int i)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];
            TheArray[i + 1] = temp;

            DrawBar(i, TheArray[i]);
            DrawBar(i+1, TheArray[i + 1]);
            


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
