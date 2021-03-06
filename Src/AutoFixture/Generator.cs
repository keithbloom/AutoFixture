﻿using System.Collections;
using System.Collections.Generic;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture
{
    /// <summary>
    /// Generates a perpetual sequence of items.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <remarks>
    /// <para>
    /// This is a generator that generates a perpetual sequence of items of type
    /// <typeparamref name="T" />, based on an encapsulated
    /// <see cref="ISpecimenBuilderComposer" />. This can be useful when zipping a against a finite
    /// sequence, since this sequence will go on for as long as required.
    /// </para>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "A Generator is (or ought to be) a generally known concept, based on the Iterator design pattern.")]
    public class Generator<T> : IEnumerable<T>
    {
        private readonly ISpecimenBuilderComposer composer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Generator&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="composer">A composer which is used to generate items.</param>
        public Generator(ISpecimenBuilderComposer composer)
        {
            this.composer = composer;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
                yield return this.composer.CreateAnonymous<T>();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
