using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Seven.Memories
{
    /// <summary>
    /// rentable memories
    /// </summary>
    internal sealed class RentableMemories
    {
        #region fields
        private readonly Memory<byte> bytes;
        private readonly Range fullRange;

        private readonly object rentedRangesLocker = new object();
        private readonly LinkedList<Range> rentedRanges = new LinkedList<Range>();
        #endregion fields

        #region constructors
        internal RentableMemories(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "length must be larger than zero");
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
                    var rentedRange = Rent(0, length, out rentedMemory);
                    rentedRanges.AddLast(rentedRange);
                    if (rentedMemory.Memory.Length != length)
                    {

                    }
                    return true;
                }

                //int lastOffset = 0;
                var currentNode = rentedRanges.First;

                while (currentNode != null)
                {
                    var currentStart = currentNode.Value.Start.Value;
                    var currentEnd = currentNode.Value.End.Value;

                    var next = currentNode.Next;
                    if (next == null)
                    {
                        // last rented range
                        if (fullRange.End.Value - currentEnd - 1 >= length)
                        {
                            var rentedRange = Rent(currentEnd + 1, currentEnd + length + 1, out rentedMemory);
                            rentedRanges.AddLast(rentedRange);
                            if (rentedMemory.Memory.Length != length)
                            {

                            }
                            return true;
                        }
                    }

                    var previous = currentNode.Previous;
                    if (previous == null)
                    {
                        // first rented range
                        if (currentStart >= length)
                        {
                            var rentedRange = Rent(0, length, out rentedMemory);
                            rentedRanges.AddBefore(currentNode, rentedRange);
                            if (rentedMemory.Memory.Length != length)
                            {

                            }
                            return true;
                        }
                    }
                    else
                    {
                        var previousEnd = previous.Value.End.Value;
                        var freeLength = currentStart - previousEnd - 1;
                        if (freeLength >= length)
                        {
                            var rentedRange = Rent(previousEnd + 1, previousEnd + length + 1, out rentedMemory);
                            rentedRanges.AddBefore(currentNode, rentedRange);
                            if (rentedMemory.Memory.Length != length)
                            {

                            }
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

        internal ReadOnlyMemory<byte> Get(Range range) => bytes[range];
        #endregion methods
    }
}
