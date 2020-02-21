﻿namespace EnumerableSequences
{
    /// <summary>
    /// IPredicate interface.
    /// </summary>
    /// <typeparam name="T">Input parameter.</typeparam>
    public interface IPredicate<in T>
    {
        /// <summary>
        /// Determines whether an integer number matches a specific condition.
        /// </summary>
        /// <param name="value">Integer number.</param>
        /// <returns>true if an integer number matches a specific condition; otherwise, false.</returns>
        bool IsMatch(T value);
    }
}