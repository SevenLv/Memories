using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Seven.Memories
{
    /// <summary>
    /// some bytes
    /// </summary>
    internal sealed class Memories
    {
        #region fields
        private readonly Memory<byte> bytes;
        private readonly Range fullRange;

        private readonly object rentedRangesLocker = new object();
        private readonly LinkedList<Range> rentedRanges = new LinkedList<Range>();
        #endregion fields

        #region constructors
        internal Memories(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "length must larger than zero");
            }

            bytes = new byte[length];
            fullRange = new Range(0, length);
        }
        #endregion constructors

        #region methods
        internal bool TryRent(int length, out RentedMemory rentedMemory)
        {
            lock (rentedRangesLocker)
            {
                if (rentedRanges.Count <= 0)
                {
                    var rentedRange = Rent(0, length - 1, out rentedMemory);
                    rentedRanges.AddLast(rentedRange);
                    return true;
                }

                //int lastOffset = 0;
                var currentNode = rentedRanges.First;
                while (currentNode != null)
                {
                    var next = currentNode.Next;
                    if (next == null)
                    {
                        // last rented range
                        if (fullRange.End.Value - currentNode.Value.End.Value >= length)
                        {
                            var rentedRange = Rent(currentNode.Value.End.Value + 1, currentNode.Value.End.Value + length, out rentedMemory);
                            rentedRanges.AddLast(rentedRange);
                            return true;
                        }
                    }

                    var previous = currentNode.Previous;
                    if (previous == null)
                    {
                        // first rented range
                        if (currentNode.Value.Start.Value >= length)
                        {
                            var rentedRange = Rent(0, length - 1, out rentedMemory);
                            rentedRanges.AddBefore(currentNode, rentedRange);
                            return true;
                        }
                    }
                    else
                    {
                        var freeLength = currentNode.Value.Start.Value - previous.Value.End.Value - 1;
                        if (freeLength >= length)
                        {
                            var rentedRange = Rent(previous.Value.End.Value + 1, previous.Value.End.Value + length, out rentedMemory);
                            rentedRanges.AddBefore(currentNode, rentedRange);
                            return true;
                        }
                    }

                    currentNode = currentNode.Next;
                }
            }

            rentedMemory = default;
            return false;
        }

        private Range Rent(int from, int end, out RentedMemory rentedMemory)
        {
            var rentedRange = new Range(from, end);

            rentedMemory = new RentedMemory(this, rentedRange, bytes[rentedRange]);

            return rentedRange;
        }

        internal void Return(RentedMemory memory)
        {
            lock (rentedRangesLocker)
            {
                if (!rentedRanges.Contains(memory.RentedRange))
                {
                    Trace.TraceWarning($"invalid memory range ({memory.RentedRange}) to return.{Environment.NewLine}rented ranges: {string.Join(", ", rentedRanges.Select(e => e.ToString()))}");
                    return;
                }

                memory.Memory.Span.Fill(0);
                rentedRanges.Remove(memory.RentedRange);
            }
        }
        #endregion methods
    }
}
