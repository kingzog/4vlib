//-----------------------------------------------------------------------
// <copyright file="VObjectCollection.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A list of <c>VObject</c> items.
    /// </summary>
    public class VersitObjectCollection : ICollection<IVersitObject>
    {
        /// <summary>
        /// Internal collection of items.
        /// </summary>
        private List<IVersitObject> collection = new List<IVersitObject>();

        /// <summary>
        /// Gets the <c>IVObject</c> at the specified index.
        /// </summary>
        /// <param name="index">Index of the value to return</param>
        /// <returns>An IVObject object</returns>
        public IVersitObject this[int index]
        {
            get { return this.collection[index]; }
        }

        /// <summary>
        /// Gets the number of items in this collection.
        /// </summary>
        public int Count
        {
            get { return this.collection.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Adds a new item to this collection.
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(IVersitObject item)
        {
            this.collection.Add(item);
        }

        /// <summary>
        /// Clears all items from this collection.
        /// </summary>
        public void Clear()
        {
            this.collection.Clear();
        }

        /// <summary>
        /// Determines whether this collection contains the specified
        /// item.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns><c>True</c> if the collection contains the item</returns>
        public bool Contains(IVersitObject item)
        {
            return this.collection.Contains(item);
        }

        /// <summary>
        /// Copy an item to a new array.
        /// </summary>
        /// <param name="array">Array to copy to</param>
        /// <param name="arrayIndex">Index of the item to copy</param>
        public void CopyTo(IVersitObject[] array, int arrayIndex)
        {
            this.collection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an item from this collection.
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns><c>True</c> if the item was removed, or
        /// <c>False</c> if removal was unsuccessful or the 
        /// item was not there to begin with.</returns>
        public bool Remove(IVersitObject item)
        {
            return this.collection.Remove(item);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The collection enumerator</returns>
        public IEnumerator<IVersitObject> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The collection enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }
    }

    /// <summary>
    /// A strongly-typed collection of <c>VObject</c> objects,
    /// accepting only a specific implementation of <c>IVObject</c>.
    /// </summary>
    /// <typeparam name="T">Type of <c>IVObject</c> this list accepts</typeparam>
    public class VObjectCollection<T> : VersitObjectCollection
        where T : IVersitObject
    {
        /// <summary>
        /// Adds an item to this collection.
        /// </summary>
        /// <param name="item">Item to add to the collection</param>
        public void Add(T item)
        {
            base.Add(item);
        }
    }
}
