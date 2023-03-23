// See https://aka.ms/new-console-template for more information
using MyBenchmarkTests;

Console.WriteLine("Hello, World!");


AyncEx_vs_MSVSThreading tester = new AyncEx_vs_MSVSThreading();
await tester.test();

