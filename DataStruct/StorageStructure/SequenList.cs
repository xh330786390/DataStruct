using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.StorageStructure
{

    public interface ISList<T>
    {
        /// <summary>
        /// 长度
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// 指定位置添加元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        void Insert(T item, int index);

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);

        /// <summary>
        /// 获取元素
        /// </summary>
        /// <param name="index"></param>
        T Get(int index);

        /// <summary>
        /// 清空元素
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// 线性表-顺序
    /// </summary>
    public class SequenList<T> : ISList<T>
    {
        /// <summary>
        /// 列表长度
        /// </summary>
        private int _size = 0;
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// 容量
        /// </summary>
        private int capacity = 0;

        /// <summary>
        /// 列表数组
        /// </summary>
        private T[] items;

        public SequenList()
            : this(4)
        {
        }

        public SequenList(int length)
        {
            items = new T[length];
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (_size == items.Length) EnsureCapacity();

            items[_size++] = item;
        }

        /// <summary>
        /// 扩容
        /// </summary>
        private void EnsureCapacity()
        {
            capacity = items.Length * 2;
            T[] newItems = new T[capacity];
            Array.Copy(items, newItems, items.Length);
            items = newItems;
        }

        /// <summary>
        /// 指定位置添加元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(T item, int index)
        {
            if (_size < index)
            {
                Console.WriteLine("超出索引");
                return;
            }

            if (_size == items.Length) EnsureCapacity();
            if (index < _size)
            {
                Array.Copy(items, index, items, index + 1, _size - index);

                //for (int i = _size - 1; i >= index; i--)
                //{
                //    items[i + 1] = items[i];
                //}
            }
            items[index] = item;
            _size++;
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="item"></param>
        public void Delete(T item)
        {
            _size--;
            int index = Array.IndexOf(items, item);
            if (index < _size)
            {
                Array.Copy(items, index + 1, items, index, _size - index);
            }

            items[_size] = default(T);
        }

        /// <summary>
        /// 获取元素
        /// </summary>
        /// <param name="index"></param>
        public T Get(int index)
        {
            if (index < _size)
            {
                return items[index];
            }
            return default(T);
        }

        /// <summary>
        /// 清空元素
        /// </summary>
        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(items, 0, _size);
                _size = 0;
            }
        }
    }
}
