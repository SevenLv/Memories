using System;

namespace Seven.Memories
{
    /// <summary>
    /// one memory owns some bytes
    /// </summary>
    public class RentedMemory : IDisposable
    {
        #region fields
        private readonly IRentableMemories memories;

        private readonly object disposationLocker;
        private bool disposing;
        private bool disposed;
        #endregion fields

        #region constructors
        /// <summary>
        /// initialize a new <see cref="RentedMemory"/> instance
        /// </summary>
        /// <param name="memories">rentable memories</param>
        /// <param name="rentedRange">rented range</param>
        /// <param name="memory">rented memory</param>
        public RentedMemory(
            IRentableMemories memories,
            Range rentedRange,
            Memory<byte> memory)
        {
            disposationLocker = new object();
            disposing = false;
            disposed = false;

            this.memories = memories;
            RentedRange = rentedRange;
            Memory = memory;
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// rented range
        /// </summary>
        public Range RentedRange { get; }

        /// <summary>
        /// rented bytes
        /// </summary>
        public Memory<byte> Memory { get; }
        #endregion

        #region methods
        /// <summary>
        /// override <see cref="IDisposable.Dispose"/>. return the rented memory
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

                try
                {
                    memories.Return(this);
                }
                finally
                {
                    disposed = true;
                }
            }
        }
        #endregion methods
    }
}
