// See https://aka.ms/new-console-template for more information
using MyBenchmarkTests;

Console.WriteLine("Hello, World!");


AyncEx_vs_MSVSThreading tester = new AyncEx_vs_MSVSThreading();
tester.ev += DoStuffAsync;

async Task DoStuffAsync(object sender, EventArgs args)
{

}


await tester.test();

