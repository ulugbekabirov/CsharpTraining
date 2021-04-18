﻿using System;
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
        ProgressController _progressController = new ProgressController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            _progressController.ProgressChanged += ProgressChanged;
            Thread thread = new Thread(_progressController.Progress);
            thread.Start();
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            _progressController.ReleaseMutex();
        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }

        private void ProgressChanged(int value)
        {
            Action action = () => { ProgressBar1.Value = value; };
            Invoke(action);
        }
    }
}
