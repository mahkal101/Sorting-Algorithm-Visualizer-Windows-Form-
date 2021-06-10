using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Visualizer
{
    class MoveToBack : ISortEngine
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        Brush BlackBrush = new System.Drawing.SolidBrush(Color.Teal);
        Brush WhiteBrush = new System.Drawing.SolidBrush(Color.PaleGreen);

        private int CurrentListPointer;



        public MoveToBack(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;
        }

        public void NextStep()
        {
            if (CurrentListPointer >= TheArray.Count() - 1) CurrentListPointer = 0;
            if (TheArray[CurrentListPointer] > TheArray[CurrentListPointer + 1])
            {
                Rotate(CurrentListPointer);
            }
            CurrentListPointer++;
        }

        private void Rotate(int currentListPointer)
        {
            int temp = TheArray[currentListPointer];
            int endPoint = TheArray.Count() - 1;

            for (int i = currentListPointer; i < endPoint; i++)
            {
                TheArray[i] = TheArray[i + 1];
                DrawBar(i, TheArray[i]);
            }

            TheArray[endPoint] = temp;
            DrawBar(endPoint, TheArray[endPoint]);
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
