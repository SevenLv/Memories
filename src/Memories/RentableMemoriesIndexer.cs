using System;

namespace Seven.Memories
{
    /// <summary>
    /// rentable memories indexer
    /// </summary>
    public abstract class RentableMemoriesIndexer
    {
        #region constructors
        /// <summary>
        /// initialize a new <see cref="RentableMemoriesIndexer"/>
        /// </summary>
        /// <param name="length">length of rentable memories</param>
        protected RentableMemoriesIndexer(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "length must be larger than zero");
            }

            Length = length;
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// length of rentable memories
        /// </summary>
        protected int Length { get; }
        #endregion properties

        #region methods
        /// <summary>
        /// try lock indexed range
        /// </summary>
        /// <param name="length">length of memories</param>
        /// <param name="range">locked range</param>
        /// <returns>if false, rent operation is failed</returns>
        public abstract bool TryLock(int length, out Range range);

        /// <summary>
        /// unlock locked range
        /// </summary>
        /// <param name="range">locked range</param>
        public abstract void Unlock(Range range);
        #endregion methods
    }
}
