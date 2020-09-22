using System;

namespace Seven.Memories
{
    /// <summary>
    /// one memory owns some bytes
    /// </summary>
    public struct RentedMemory : IDisposable
    {
        #region fields
        private readonly Memories memories;

        private readonly object disposationLocker;
        private bool disposing;
        private bool disposed;
        #endregion fields

        #region constructors
        internal RentedMemory(Memories memories, Range rentedRange, Memory<byte> memory)
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
        internal Range RentedRange { get; }

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
