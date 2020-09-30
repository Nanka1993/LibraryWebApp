using System;

namespace LibraryWebApp.Dto
{
    /// <summary>
    /// Диапазон
    /// </summary>
    public class IntRange
    {
        /// <summary>
        /// от включительно
        /// </summary>
        public int? Gte { get; set; }

        /// <summary>
        /// до включительно
        /// </summary>
        public int? Lte { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as IntRange);
        }

        protected bool Equals(IntRange other)
        {
            return Gte == other.Gte && Lte == other.Lte;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Gte, Lte);
        }
    }
}
