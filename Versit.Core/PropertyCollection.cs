//-----------------------------------------------------------------------
// <copyright file="VPropertyCollection.cs" company="4verse">
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
    /// A collection of <c>IVProperty</c> objects, typically used 
    /// within a <c>VObject</c> to hold lists of attributes or data.
    /// </summary>
    public class PropertyCollection : ICollection<IProperty>
    {
        /// <summary>
        /// Internal collection of items.
        /// </summary>
        private List<IProperty> collection = new List<IProperty>();

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
        /// Gets a specific item in this collection.
        /// </summary>
        /// <param name="index">Index of the <c>IVProperty</c></param>
        /// <returns>The <c>IVProperty</c> if present, otherwise <c>null</c></returns>
        public IProperty this[int index]
        {
            get { return this.collection[index]; }
            set { this.collection[index] = value; }
        }

        /// <summary>
        /// Gets a specific item in this collection based on the
        /// <c>IVProperty</c>'s <c>Name</c> value.
        /// </summary>
        /// <param name="key">Name key of the <c>IVProperty</c></param>
        /// <returns>The <c>IVProperty</c> if present, otherwise <c>null</c></returns>
        public IProperty this[string key]
        {
            get
            {
                if (!this.collection.Any())
                {
                    return null;
                }

                return this.collection.Where(f => f.Name == key).First();
            }

            set
            {
                var index = this.collection.IndexOf(this[key]);
                this.collection[index] = value;
            }
        }

        /// <summary>
        /// Adds a new item to this collection.
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(IProperty item)
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
        public bool Contains(IProperty item)
        {
            return this.collection.Any(c => c.Name == item.Name);
        }

        /// <summary>
        /// Determines whether an element is in this list.
        /// </summary>
        /// <param name="name">Name key of the <c>IVProperty</c></param>
        /// <returns><c>True</c> if an item of that name is in the collection</returns>
        public bool Contains(string name)
        {
            return this.collection.Any(f => f.Name == name);
        }

        /// <summary>
        /// Copy an item to a new array.
        /// </summary>
        /// <param name="array">Array to copy to</param>
        /// <param name="arrayIndex">Index of the item to copy</param>
        public void CopyTo(IProperty[] array, int arrayIndex)
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
        public bool Remove(IProperty item)
        {
            return this.collection.Remove(item);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The collection enumerator</returns>
        public IEnumerator<IProperty> GetEnumerator()
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
    /// A strongly-typed collection of <c>VProperty</c> objects,
    /// accepting only a specific implementation of <c>IVProperty</c>.
    /// </summary>
    /// <typeparam name="T">Type of <c>IVProperty</c> this list accepts</typeparam>
    /// <remarks>
    /// Use this for lists of <c>VAddress</c> or <c>VEmail</c> 
    /// properties, where only one type of object is valid.
    /// </remarks>
    public class VPropertyCollection<T> : PropertyCollection
        where T : IProperty
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
