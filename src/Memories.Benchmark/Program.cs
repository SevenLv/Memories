using BenchmarkDotNet.Running;
using Seven.Memories.Benchmark;
using System;

namespace Memories.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<InitializationTester>();
            Console.ReadLine();
        }
    }
}
