using BenchmarkDotNet.Running;
using Seven.Memories.Benchmark;
using System;

namespace Memories.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<InitializationTester>();
            BenchmarkRunner.Run<RentTester>();
            Console.ReadLine();
        }
    }
}
