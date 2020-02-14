using System;
using System.Threading.Tasks;
using SIS.MvcFramework;

namespace PANDA
{
    class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}
