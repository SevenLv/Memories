using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Seven.Memories.Benchmark
{
    [SimpleJob(RuntimeMoniker.CoreRt31)]
    [MarkdownExporterAttribute.GitHub]
    public class InitializationTester
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
            using var pool = new MemoryPool(Count, Count, Size);
        }
        #endregion methods
    }
}
