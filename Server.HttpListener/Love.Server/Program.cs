using System;
using System.Net;
using Love.Server.Responses;

namespace Love.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine($"{nameof(HttpListener)} can be used with the current operating system.");
                Console.ReadKey();
                return;
            }
            using (var server = new RanOpt.Common.RemoteLib.Http.Server.HttpServer())
            {
                server.Responses.Add(new AddPensonResponse());
                Console.Title = server.Name;
                server.Run();
            }
        }
    }
}
