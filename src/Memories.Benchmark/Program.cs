using BenchmarkDotNet.Running;
using Seven.Memories.Benchmark;
using System;

namespace Memories.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DefaultInitializationTester>();
            //BenchmarkRunner.Run<DefaultRentTester>();
            Console.ReadLine();
        }
    }
}
