using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            var result = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            var resul2t = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");


            /*Task<HttpResponseMessage> task = Task.Run<HttpResponseMessage>(async () =>
                await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1"));*/

            var data = Task.Run(async () => await Task.WaitAll(result, resul2t));

        }
    }
}