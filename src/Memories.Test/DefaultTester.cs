//--------------------------------------------------------------------------------
// DefaultTester.cs is part of Seven.Memories
// Created by Seven Lv, 2020-9-23
// Licensed to the Seven.Memories under one or more agreements.
// The Seven.Memories licenses this file to you under the MIT license.
//--------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Seven.Memories.Test
{
    [TestClass]
    public sealed class DefaultTester : Tester
    {
        #region methods
        private protected sealed override MemoryPool CreateMemoryPool(int count, int maxCount, int blockSize) =>
            new DefaultMemoryPool(count, maxCount, blockSize);

        private protected sealed override RentableMemories CreateRentableMemories(int length) =>
            new DefaultRentableMemories(length);
        #endregion methods
    }
}
