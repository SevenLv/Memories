//--------------------------------------------------------------------------------
// RentableMemories.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-27
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

using System;

namespace Seven.Memories
{
    /// <summary>
    /// rentable memories
    /// </summary>
    public sealed class RentableMemories : IRentableMemories
    {
        #region fields
        private readonly Memory<byte> bytes;
        private readonly RentableMemoriesIndexer indexer;
        #endregion fields

        #region constructors
        /// <summary>
        /// initialize a new <see cref="RentableMemories"/> instance
        /// </summary>
        /// <param name="length">the length of memories</param>
        /// <param name="indexer">rentable memories indexer instance</param>
        internal RentableMemories(int length, RentableMemoriesIndexer indexer)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "length must be larger than zero");
            }

            bytes = new byte[length];
            this.indexer = indexer;
        }
        #endregion constructors

        #region methods
        /// <summary>
        /// try to rent some memory
        /// </summary>
        /// <param name="length">the length of memory</param>
        /// <param name="rentedMemory">rented memory</param>
        /// <returns>if false, rent operation is failed</returns>
        public bool TryRent(int length, out RentedMemory rentedMemory)
        {
            if (indexer.TryLock(length, out var range))
            {
                rentedMemory = new RentedMemory(this, range, bytes[range]);
                return true;
            }

            rentedMemory = default;
            return false;
        }

        /// <summary>
        /// return rented memory
        /// </summary>
        /// <param name="rentedMemory">rented memory</param>
        public void Return(RentedMemory rentedMemory)
        {
            indexer.Unlock(rentedMemory.RentedRange);
            rentedMemory.Memory.Span.Fill(0);
        }

        internal ReadOnlyMemory<byte> Get(Range range) =>
            bytes[range];
        #endregion methods
    }
}
