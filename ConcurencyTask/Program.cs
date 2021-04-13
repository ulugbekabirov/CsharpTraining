using System;
using System.Threading.Tasks;

namespace ConcurencyTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var i in data)
            {
                var task = new Task(() => Console.WriteLine(i));
                await Task.Run(() => task.Start());
            }

            Console.ReadLine();
        }
    }

}
