//--------------------------------------------------------------------------------
// IRentableMemories.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-28
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

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
