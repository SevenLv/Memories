using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Seven.Memories
{
    /// <summary>
    /// memory pool
    /// </summary>
    public sealed class MemoryPool : IDisposable
    {
        #region fields
        private readonly ManualResetEvent rentableResetEvent = new ManualResetEvent(true);
        private readonly ManualResetEvent expansionRequiredResetEvent = new ManualResetEvent(false);
        private int rentingCount = 0;

        private readonly Task expansionThread;

        private readonly List<RentableMemories> pool = new List<RentableMemories>();

        private readonly object disposationLocker = new object();
        private bool disposing = false;
        private bool disposed = false;
        #endregion fields

        #region constructors
        /// <summary>
        /// initialize a new <see cref="MemoryPool"/> instance.
        /// </summary>
        /// <param name="initialBlockCount">the initial count of blocks. each block maintains some bytes, and the length of the bytes is defined by <paramref name="blockSize"/></param>
        /// <param name="maxBlockCount"></param>
        /// <param name="blockSize">the length of each block</param>
        public MemoryPool(int initialBlockCount, int maxBlockCount, int blockSize)
        {
            if (initialBlockCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBlockCount), initialBlockCount, "value must be larger than zero");
            }

            if (maxBlockCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxBlockCount), maxBlockCount, "value must be larger than zero");
            }

            if (maxBlockCount < initialBlockCount)
            {
                throw new ArgumentException(nameof(maxBlockCount), $"{nameof(maxBlockCount)} can not be less than {nameof(initialBlockCount)}");
            }

            if (blockSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockSize), blockSize, "value must be larger than zero");
            }

            for (int i = 0; i < initialBlockCount; i++)
            {
                pool.Add(new RentableMemories(blockSize));
            }

            InitialBlockCount = initialBlockCount;
            MaxBlockCount = maxBlockCount;
            BlockSize = blockSize;

            expansionThread = Task.Factory.StartNew(ExpansionLoop, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// initial block count
        /// </summary>
        public int InitialBlockCount { get; }

        /// <summary>
        /// current block count
        /// </summary>
        public int BlockCount => pool.Count;

        /// <summary>
        /// max block count
        /// </summary>
        public int MaxBlockCount { get; }

        /// <summary>
        /// the length of each block
        /// </summary>
        public int BlockSize { get; }
        #endregion properties

        #region methods
        /// <summary>
        /// try to rent some memory
        /// </summary>
        /// <param name="length">the length of memory</param>
        /// <param name="rentedMemory">rented memory</param>
        /// <returns>if false, rent operation is failed</returns>
        public bool TryRent(int length, out RentedMemory rentedMemory)
        {
            if (length > BlockSize)
            {
                rentedMemory = default;
                return false;
            }

            rentableResetEvent.WaitOne();

            Interlocked.Increment(ref rentingCount);

            try
            {
                foreach (var rentableMemories in pool)
                {
                    if (rentableMemories.TryRent(length, out rentedMemory))
                    {
                        return true;
                    }
                }

                if (BlockCount < MaxBlockCount)
                {
                    rentableResetEvent.Reset();
                    expansionRequiredResetEvent.Set();
                }

                rentedMemory = default;
                return false;
            }
            finally
            {
                Interlocked.Decrement(ref rentingCount);
            }
        }

        private void ExpansionLoop()
        {
            while (!Environment.HasShutdownStarted
                && !disposing
                && !disposed)
            {
                if (!expansionRequiredResetEvent.WaitOne(100))
                {
                    Thread.Sleep(1);
                    continue;
                }

                if (rentingCount > 0)
                {
                    Thread.Sleep(1);
                    continue;
                }

                try
                {
                    pool.Add(new RentableMemories(BlockSize));
                }
                finally
                {
                    expansionRequiredResetEvent.Reset();
                    rentableResetEvent.Set();
                }
            }
        }

        /// <summary>
        /// override <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            lock (disposationLocker)
            {
                if (disposing || disposed)
                {
                    return;
                }

                disposing = true;

                rentableResetEvent.Reset();
                expansionRequiredResetEvent.Reset();

                expansionThread.Wait();

                pool.Clear();

                disposing = false;
                disposed = true;
            }
        }
        #endregion methods
    }
}
