using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EnumerableSequences.Interfaces
{
    /// <summary>
    /// Class ComparisonAdapty.
    /// </summary>
    /// <typeparam name="T">Input parameter.</typeparam>
    public class ComparisonAdapty<T> : IComparer<T>
    {
        private Comparison<T> comparison;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComparisonAdapty{T}"/> class.
        /// </summary>
        /// <param name="comparison">Comprasion.</param>
        public ComparisonAdapty(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// Compare method.
        /// </summary>
        /// <param name="x">first parameter.</param>
        /// <param name="y">second parameter.</param>
        /// <returns>Int number.</returns>
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            return this.comparison(x, y);
        }
    }
}
