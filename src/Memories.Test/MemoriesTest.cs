﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Seven.Memories
{
    [TestClass]
    public sealed class MemoriesTest
    {
        [TestMethod]
        public void DefaultTest()
        {
            const int MEMORIES_LENGTH = 1024;
            const int MAX_RENT_LENGTH = 128;

            var memories = new Memories(MEMORIES_LENGTH);

            var random = new Random(DateTime.Now.Millisecond);

            var savedMemories = new List<RentedMemory>();
            for (int i = 0; i < 1000000; i++)
            {
                var disposedMemories = new List<RentedMemory>();
                foreach (var savedMemory in savedMemories)
                {
                    if (random.Next() > 0.5)
                    {
                        disposedMemories.Add(savedMemory);
                    }
                }

                foreach (var disposedMemory in disposedMemories)
                {
                    if (savedMemories.Contains(disposedMemory))
                    {
                        savedMemories.Remove(disposedMemory);
                        disposedMemory.Dispose();
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    byte size = (byte) random.Next(1, MAX_RENT_LENGTH);

                    if (memories.TryRent(size, out var rented))
                    {
                        Assert.AreEqual(size, rented.Memory.Length);
                        for (byte k = 0; k < size; k++)
                        {
                            rented.Memory.Span[k] = k;
                        }

                        var realMemory = memories.Get(rented.RentedRange);
                        for (byte k = 0; k < size; k++)
                        {
                            Assert.AreEqual(k, realMemory.Span[k]);
                        }

                        if (random.Next() > 0.5)
                        {
                            savedMemories.Add(rented);
                        }
                        else
                        {
                            rented.Dispose();
                        }
                    }
                }
            }
            {
                var disposedMemories = new List<RentedMemory>();
                foreach (var savedMemory in savedMemories)
                {
                    if (random.Next() > 0.5)
                    {
                        disposedMemories.Add(savedMemory);
                    }
                }

                foreach (var disposedMemory in disposedMemories)
                {
                    if (savedMemories.Contains(disposedMemory))
                    {
                        savedMemories.Remove(disposedMemory);
                        disposedMemory.Dispose();
                    }
                }

                var fullBytes = memories.Get(new Range(0, MEMORIES_LENGTH));
                for (int i = 0; i < MEMORIES_LENGTH; i++)
                {
                    Assert.AreEqual(0, fullBytes.Span[i]);
                }
            }
        }
    }
}
