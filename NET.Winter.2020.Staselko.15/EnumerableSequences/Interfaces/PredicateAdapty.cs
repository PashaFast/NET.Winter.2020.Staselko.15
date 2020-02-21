using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableSequences.Interfaces
{
    /// <summary>
    /// Class PredicateAdapty.
    /// </summary>
    /// <typeparam name="T">Input parameter.</typeparam>
    public class PredicateAdapty<T> : IPredicate<T>
    {
        private Predicate<T> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateAdapty{T}"/> class.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        public PredicateAdapty(Predicate<T> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            this.predicate = predicate;
        }

        /// <summary>
        /// IsMatch method.
        /// </summary>
        /// <param name="value">input value.</param>
        /// <returns>Bool value.</returns>
        public bool IsMatch(T value)
        {
            return this.predicate(value);
        }
    }
}
