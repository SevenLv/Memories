//--------------------------------------------------------------------------------
// DefaultRentableMemories.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-28
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

namespace Seven.Memories
{
    /// <summary>
    /// rentalbe memories with default indexer
    /// </summary>
    public sealed class DefaultRentableMemories : RentableMemories
    {
        #region constructors
        internal DefaultRentableMemories(int length) : base(length) { }
        #endregion constructors

        #region methods
        /// <summary>
        /// create rentable memories indexer instance
        /// </summary>
        /// <param name="length">the length of memories</param>
        /// <returns>rentable memories indexer instance</returns>
        protected sealed override RentableMemoriesIndexer CreateIndexer(int length) =>
            new DefaultRentableMemoriesIndexer(length);
        #endregion methods
    }
}
