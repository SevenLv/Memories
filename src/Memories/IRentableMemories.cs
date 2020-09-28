namespace Seven.Memories
{
    /// <summary>
    /// rentable memories
    /// </summary>
    public interface IRentableMemories
    {
        #region methods
        /// <summary>
        /// try to rent some memory
        /// </summary>
        /// <param name="length">the length of memory</param>
        /// <param name="rentedMemory">rented memory</param>
        /// <returns>if false, rent operation is failed</returns>
        bool TryRent(int length, out RentedMemory rentedMemory);

        /// <summary>
        /// return rented memory
        /// </summary>
        /// <param name="rentedMemory">rented memory</param>
        void Return(RentedMemory rentedMemory);
        #endregion methods
    }
}
