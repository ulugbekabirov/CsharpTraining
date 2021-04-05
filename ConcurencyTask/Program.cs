using System;
using System.Threading.Tasks;

namespace ConcurencyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[10];
            int j = 1;
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Factory.StartNew(() => Console.WriteLine(++j));
            Console.ReadLine();
        }
    }

}
