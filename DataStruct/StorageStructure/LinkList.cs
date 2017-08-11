using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.StorageStructure
{
    /// <summary>
    /// 线性表-链式
    /// </summary>
    public class LinkList<T>
    {
        private LinkNode<T> firstNode;

        public LinkNode<T> FirstNode
        {
            get { return firstNode; }
        }

        private LinkNode<T> lastNode;
        public LinkNode<T> LastNode
        {
            get { return lastNode; }
        }

        private int size = 0;
        public int Count
        {
            get { return size; }
        }


        public LinkList()
        {

        }

        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {

            if (firstNode == null)
            {
                firstNode = new LinkNode<T>()
                {
                    Current = item
                };

                lastNode = firstNode;
            }
            else
            {
                LinkNode<T> Current = new LinkNode<T>() { Current = item, PreNode = lastNode };

                lastNode.NextNode = Current;
                lastNode = Current;
            }

            size++;
        }

        public void Insert(T item, int index)
        {
            if (index > size)
            {
                Console.WriteLine("超出索引");
                return;
            }

            var node = firstNode;
            int i;
            for (i = 1; i < index && node != null; i++)
            {
                node = node.NextNode;
            }

            if (i == index)
            {
                LinkNode<T> Current = new LinkNode<T>() { Current = item, PreNode = node, NextNode = node.NextNode };
                node.NextNode = Current;
                size++;
            }

            node = firstNode;
            Console.WriteLine(node.Current);
            for (i = 1; i < size && node != null; i++)
            {
                node = node.NextNode;
                Console.WriteLine(node.Current);
            }
        }

        public void Delete(int index)
        {
            if (index > size)
            {
                Console.WriteLine("超出索引");
                return;
            }

            var node = firstNode;
            int i;
            for (i = 1; i < index && node != null; i++)
            {
                node = node.NextNode;
            }


            if (i == index)
            {
                node.PreNode.NextNode = node.NextNode;
                node.NextNode = null;
                size--;
            }

            node = firstNode;
            Console.WriteLine(node.Current);
            for (i = 1; i < size && node != null; i++)
            {
                node = node.NextNode;
                Console.WriteLine(node.Current);
            }

        }
    }

    public class LinkNode<T>
    {
        public T Current { get; set; }

        public LinkNode<T> PreNode { get; set; }

        public LinkNode<T> NextNode { get; set; }
    }
}

