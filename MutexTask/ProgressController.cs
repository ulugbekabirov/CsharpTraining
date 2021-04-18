using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutexTask
{
    public class ProgressController
    {
        private static Mutex mutex = new Mutex();
        public void Progress()
        {
            mutex.WaitOne();
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                ProgressChanged(i);
            }
            Progress();
        }

        public void ReleaseMutex()
        {
            mutex.ReleaseMutex();
        }

        public event Action<int> ProgressChanged;
    }
}
