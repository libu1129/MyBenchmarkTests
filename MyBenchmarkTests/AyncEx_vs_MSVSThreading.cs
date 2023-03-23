using BenchmarkDotNet.ConsoleArguments.ListBenchmarks;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBenchmarkTests
{
    internal class AyncEx_vs_MSVSThreading
    {
        int run_count = 1000;


        public async Task test()
        {
            List<long> elapsed_list = new List<long>();
            for (int i = 0; i < 500; i++)
            {
                var elapsed = await run();
                elapsed_list.Add(elapsed);
            }
            var avg = elapsed_list.Average();

            Debug.WriteLine($"elapsed ticks : {avg.ToString("n0")}");
        }

        /// <summary>
        /// nito asyncex 쪽이 조금더 빠르다
        /// </summary>
        /// <returns></returns>
        private async Task<long> run()
        {
            Nito.AsyncEx.AsyncManualResetEvent are = new();
            //Microsoft.VisualStudio.Threading.AsyncManualResetEvent are = new();

            Stopwatch st = new Stopwatch();

            _ = Task.Run(async () =>
            {
                await Task.Delay(50);
                st.Restart();
                are.Set();
            });


            await are.WaitAsync();
            st.Stop();

            return st.ElapsedTicks;
        }
    }
}
