using System;

namespace LibraryWebApp.Dto.Filters
{
    /// <summary>
    /// Модель фильтра книг
    /// </summary>
    public class BookFilter
    {
        /// <summary>
        /// Является ли оригиналом
        /// </summary>
        public bool? EqualsToIsOriginal { get; set; }

        /// <summary>
        /// Фильтрация по диапазону количества страниц
        /// </summary>
        public IntRange PageRange { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookFilter);
        }

        protected bool Equals(BookFilter other)
        {
            return EqualsToIsOriginal == other.EqualsToIsOriginal && Equals(PageRange, other.PageRange);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EqualsToIsOriginal, PageRange);
        }
    }
}
