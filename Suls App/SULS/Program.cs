﻿namespace SULS.App
{
    using SIS.MvcFramework;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}