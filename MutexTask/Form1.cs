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
        public static Mutex mutex = new Mutex();
        public bool switched = false;
        public Form1()
        {
            InitializeComponent();
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

        private void Stop_Click(object sender, EventArgs e)
        {

        }
        private void ProgressChanged(ProgressBar progressBar, int value)
        {
            Action action = () =>
            {
                progressBar.Value = value;
            };

            Invoke(action);

        }
        public void Progress(ProgressBar progressBar)
        {
            mutex.WaitOne();

            for (int i = 0; i <= 100; i++)
            {
                if (switched)
                {
                    mutex.ReleaseMutex();
                    switched = false;
                    break;
                }
                Thread.Sleep(50);
                ProgressChanged(progressBar, i);
            }

            Progress(progressBar);
        }
    }
}
