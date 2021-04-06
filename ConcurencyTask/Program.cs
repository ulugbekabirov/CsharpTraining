using System;
using System.Threading.Tasks;

namespace ConcurencyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Task[10];
            var j = 1;
            
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => Console.WriteLine(i));
            }

            Console.ReadLine();

        }
    }

}
