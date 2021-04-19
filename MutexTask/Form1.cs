using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutexTask
{
    public partial class Form1 : Form
    {
        private static Mutex mutex = new Mutex();
        private bool switched = false;
        private bool stoped = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            stoped = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {

            var thread1 = new Thread(() => Progress(ProgressBar1));
            var thread2 = new Thread(() => Progress(ProgressBar2));
            thread1.Start();
            thread2.Start();
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            switched = true;
        }

        private void ProgressChanged(ProgressBar progressBar, ref int value)
        {

            if (value >= 100)
            {
                value = 0;
            }

            progressBar.Value = value;
            value++;
        }

        public void Progress(ProgressBar progressBar)
        {
            int i = 0;
            while (true)
            {
                mutex.WaitOne();
                while (true)
                {
                    if (switched)
                    {
                        mutex.ReleaseMutex();
                        switched = false;
                        break;
                    }
                    Thread.Sleep(50);
                    ProgressChanged(progressBar, ref i);
                }
            }


        }

        private void Stop_Click(object sender, EventArgs e)
        {
            stoped = true;
        }
    }
}
