using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLogic
{

    /// <summary>
    /// Interface for implementation by manager classes hosting a collection
    /// of the type List<T> where T can be any object type. In this documentation,
    /// the collection is referred to as m_list.
    /// IListManager can be implemented by different classes passing any type <T> at
    /// declaration but then T MUST HAVE THE SAME TYPE IN ALL METHODS INCLUDED IN THIS INTERFACE.
    /// </summary>
    /// <typeparam name="T">object type</typeparam>
    internal interface IListManager<T>
    {
        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds an item of type <T> to the collection.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        bool Add(T item);

        /// <summary>
        /// Replaces an item at a specified index with a new item.
        /// </summary>
        /// <param name="index">The index to replace the item at.</param>
        /// <param name="item">The new item to insert.</param>
        void ReplaceAt(int index, T item);

        /// <summary>
        /// Checks if a given index is within the collection bounds.
        /// </summary>
        /// <param name="index">Index to check.</param>
        /// <returns>True if the index is valid; otherwise, false.</returns>
        bool CheckIndex(int index);

        /// <summary>
        /// Deletes all items in the collection.
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Deletes an item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to delete.</param>
        /// <returns>True if the item was deleted successfully; otherwise, false.</returns>
        bool DeleteAt(int index);

        /// <summary>
        /// Removes the first occurrence of the specified item from the list.
        /// The item is identified using the object.Equals(object) method,
        /// which can be overridden in custom types to define equality based on specific properties.
        /// </summary>
        /// <param name="item">The item to remove from the list.</param>
        /// <returns>Returns true if the item was successfully removed; otherwise, false.</returns>
        bool Remove(T item);

        /// <summary>
        /// Gets an item at a specified index.
        /// </summary>
        /// <param name="index">Index of the item to retrieve.</param>
        /// <returns>The item at the specified index.</returns>
        T GetAt(int index);

        /// <summary>
        /// Converts the items in the collection to an array of strings.
        /// </summary>
        /// <returns>An array of strings representing the collection items.</returns>
        string[] ToStringArray();

        /// <summary>
        /// Converts the items in the collection to a List of strings.
        /// </summary>
        /// <returns>A list of strings representing the collection items.</returns>
        //List<string> ToStringList();
    }
}
