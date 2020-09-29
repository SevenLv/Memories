//--------------------------------------------------------------------------------
// Program.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-26
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

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
