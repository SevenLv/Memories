//--------------------------------------------------------------------------------
// DefaultInitializationTester.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-26
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Seven.Memories.Benchmark
{
    [SimpleJob(RuntimeMoniker.CoreRt31)]
    [MarkdownExporterAttribute.GitHub]
    public class DefaultInitializationTester
    {
        #region properties
        [Params(10, 100, 1000, 10000, 100000)]
        public int Count { get; set; }

        [Params(1024, 2048, 10240, 20480)]
        public int Size { get; set; }
        #endregion properties

        #region methods
        [Benchmark]
        public void InitializeAndDispose()
        {
            using var pool = new DefaultMemoryPool(Count, Count, Size);
        }
        #endregion methods
    }
}
