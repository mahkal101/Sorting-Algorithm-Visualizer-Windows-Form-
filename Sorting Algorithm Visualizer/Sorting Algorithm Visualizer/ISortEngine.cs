using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Visualizer
{
    interface ISortEngine
    {
        void NextStep();
        bool IsSorted();
        void ReDraw();
    }
}
