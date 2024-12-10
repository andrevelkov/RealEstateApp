using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLogic
{
    public class ListManager<T> : IListManager<T>
    {
        private readonly List<T> m_list;
        public int Count
        {
            get { return m_list.Count; }
        }

        public ListManager() 
        {
            m_list = new List<T>();
        }

        public bool Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null.");
            }
            m_list.Add(item);
            return true;
        }

        public T GetAt(int index)
        {
            if (index  < 0 || index >= m_list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }
            return m_list[index];
        }

        public bool CheckIndex(int index)
        {
            return false;
        }

        public bool DeleteAt(int index)
        {
            if (index < 0 || index >= m_list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }

            m_list.RemoveAt(index);
            return true;
        }

        public bool Remove(T item)
        {
            return m_list.Remove(item);
        }

        public void DeleteAll()
        {
            m_list.Clear();
        }

        public void ReplaceAt(int index, T item)
        {
            if (index < 0 || index >= m_list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }
            m_list[index] = item;
        }

        public string[] ToStringArray()
        {
            return m_list.Select(obj => obj.ToString() ?? "null").ToArray();
        }


        public List<T> GetList()
        {
            return m_list;
        }
    }
}
