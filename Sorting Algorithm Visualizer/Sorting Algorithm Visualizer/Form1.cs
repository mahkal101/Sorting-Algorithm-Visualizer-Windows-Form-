using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sorting_Algorithm_Visualizer
{
    public partial class Form1 : Form
    {

        int[] TheArray;
        Graphics g;
        BackgroundWorker backgroundWorker = null;
        bool isPaused;

        public Form1()
        {
            InitializeComponent();
            PopulateDropDown();
        }

        private void PopulateDropDown()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            foreach(string entry in ClassList) 
            {
                comboBox1.Items.Add(entry);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (TheArray == null) button1_Click(null, null);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(argument: comboBox1.SelectedItem);
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (!isPaused) 
            {
                backgroundWorker.CancelAsync();
                isPaused = true;
            }
            else
            {
                if (backgroundWorker.IsBusy) return;
                int NumEntries = panel1.Width;
                int MaxVal = panel1.Height;
                isPaused = false;
                for (int i = 0; i < NumEntries; i++)
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.Teal), i, 0, 1, MaxVal);
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.PaleGreen), i, MaxVal - TheArray[i], 1, MaxVal);
                }
                backgroundWorker.RunWorkerAsync(argument: comboBox1.SelectedItem);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            TheArray = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(Color.Teal), 0, 0, NumEntries, MaxVal);
            Random rand = new Random();
            for(int i =0; i < NumEntries; i++) 
            {
                TheArray[i] = rand.Next(0, MaxVal);
            }            
            for(int i =0; i < NumEntries; i++) 
            {
                g.FillRectangle(new System.Drawing.SolidBrush(Color.PaleGreen), i, MaxVal - TheArray[i], 1, MaxVal);
            }

        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #region BackGround

        public void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            string SortingEngineName = (string)e.Argument;
            Type type = Type.GetType("Sorting_Algorithm_Visualizer." + SortingEngineName);
            var constructs = type.GetConstructors();
            try
            {
                ISortEngine se = (ISortEngine)constructs[0].Invoke(new object[] { TheArray, g, panel1.Height });
                while(!se.IsSorted() && !backgroundWorker.CancellationPending)
                {
                    se.NextStep();
                }

            }
            catch (Exception ex)
            {
                ex = null;
            }
        }

        #endregion


    }
}
