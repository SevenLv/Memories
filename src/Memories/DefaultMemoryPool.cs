namespace Seven.Memories
{
    /// <summary>
    /// default memory pool
    /// </summary>
    public sealed class DefaultMemoryPool : MemoryPool
    {
        #region constructors
        /// <summary>
        /// initialize a new <see cref="DefaultMemoryPool"/> instance.
        /// </summary>
        /// <param name="initialBlockCount">the initial count of blocks. each block maintains some bytes, and the length of the bytes is defined by <paramref name="blockSize"/></param>
        /// <param name="maxBlockCount"></param>
        /// <param name="blockSize">the length of each block</param>
        public DefaultMemoryPool(int initialBlockCount, int maxBlockCount, int blockSize)
            : base(initialBlockCount, maxBlockCount, blockSize) { }
        #endregion constructors

        #region methods
        /// <summary>
        /// create rentable memories instance
        /// </summary>
        /// <param name="blockSize">the length of memories</param>
        /// <returns>rentable memories instance</returns>
        protected sealed override RentableMemories CreateRentableMemories(int blockSize) =>
            new DefaultRentableMemories(blockSize);
        #endregion methods
    }
}
