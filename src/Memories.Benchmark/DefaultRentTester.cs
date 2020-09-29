//--------------------------------------------------------------------------------
// DefaultRentTester.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-26
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;

namespace Seven.Memories.Benchmark
{
    [SimpleJob(RuntimeMoniker.CoreRt31)]
    [MarkdownExporterAttribute.GitHub]
    public class DefaultRentTester
    {
        #region consts
        private const int RENT_COUNT = 1000;
        #endregion consts

        #region fields
        private readonly Random random = new Random(DateTime.Now.Millisecond);
        private DefaultMemoryPool pool;
        #endregion fields

        #region properties
        [Params(10, 100, 1000, 10000)]
        public int Count { get; set; }

        [Params(20000)]
        public int MaxCount { get; set; }

        [Params(1024, 2048, 10240, 20480)]
        public int Size { get; set; }


        [Params(16, 32, 64, 128, 256, 1024)]
        public int MaxRentSize { get; set; }
        #endregion properties

        #region methods
        [GlobalSetup]
        public void Initialize() =>
            pool = new DefaultMemoryPool(Count, MaxCount, Size);

        [Benchmark]
        public void RandomRentAndReturn1000()
        {
            var rented = new Queue<RentedMemory>();

            for (int i = 0; i < RENT_COUNT; i++)
            {
                var rentSize = random.Next(1, MaxRentSize);
                if (pool.TryRent(rentSize, out var memory))
                {
                    if (random.Next() > 0.5)
                    {
                        rented.Enqueue(memory);
                    }
                }
            }

            while (rented.Count > 0)
            {
                rented.Dequeue().Dispose();
            }
        }

        [GlobalCleanup]
        public void Dispose() =>
            pool.Dispose();
        #endregion methods
    }
}
