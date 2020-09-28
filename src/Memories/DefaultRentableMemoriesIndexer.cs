using System;
using System.Collections.Generic;

namespace Seven.Memories
{
    /// <summary>
    /// default rentable memories indexer
    /// </summary>
    public sealed class DefaultRentableMemoriesIndexer : RentableMemoriesIndexer
    {
        #region fields
        private readonly Range fullRange;

        private readonly object rentedRangesLocker = new object();
        private readonly LinkedList<Range> rentedRanges = new LinkedList<Range>();
        #endregion fields

        #region constructors
        internal DefaultRentableMemoriesIndexer(int length)
            : base(length) =>
            fullRange = new Range(0, length);
        #endregion constructors

        #region methods
        /// <summary>
        /// try lock indexed range
        /// </summary>
        /// <param name="length">length of memories</param>
        /// <param name="range">locked range</param>
        /// <returns>if false, rent operation is failed</returns>
        public sealed override bool TryLock(int length, out Range range)
        {
            lock (rentedRangesLocker)
            {
                if (rentedRanges.Count <= 0)
                {
                    range = new Range(0, length);
                    rentedRanges.AddLast(range);
                    return true;
                }

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
                            range = new Range(currentEnd + 1, currentEnd + length + 1);
                            rentedRanges.AddLast(range);
                            return true;
                        }
                    }

                    var previous = currentNode.Previous;
                    if (previous == null)
                    {
                        // first rented range
                        if (currentStart >= length)
                        {
                            range = new Range(0, length);
                            rentedRanges.AddBefore(currentNode, range);
                            return true;
                        }
                    }
                    else
                    {
                        var previousEnd = previous.Value.End.Value;
                        var freeLength = currentStart - previousEnd - 1;
                        if (freeLength >= length)
                        {
                            range = new Range(previousEnd + 1, previousEnd + length + 1);
                            rentedRanges.AddBefore(currentNode, range);
                            return true;
                        }
                    }

                    currentNode = currentNode.Next;
                }
            }

            range = default;
            return false;
        }

        /// <summary>
        /// unlock locked range
        /// </summary>
        /// <param name="range">locked range</param>
        public sealed override void Unlock(Range range)
        {
            lock (rentedRangesLocker)
            {
                if (!rentedRanges.Contains(range))
                {
                    return;
                }

                rentedRanges.Remove(range);
            }
        }
        #endregion methods
    }
}
