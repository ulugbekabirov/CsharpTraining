using System;
using System.Threading.Tasks;

namespace ConcurencyTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new Task[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                int j = i;
                tasks[i] = new Task(() => Console.WriteLine(j+1));
                await Task.Run(()=>tasks[i].Start());
            }

            Console.ReadLine();
        }
    }

}
