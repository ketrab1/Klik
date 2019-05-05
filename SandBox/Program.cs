using System;
using System.Threading.Tasks;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasker = Asyncc();
            tasker.ContinueWith(task => Console.WriteLine(task.Exception.Message));
            Console.WriteLine("abv");
            Console.ReadKey();
        }

        public static Task<string> Asyncc()
        {
          var x = Task.Run((() =>
          {
              throw new Exception();
              return "abc";
          }));

          return x;
        }
        
    }
}