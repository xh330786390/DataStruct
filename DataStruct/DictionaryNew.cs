using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    /// <summary>
    /// 字典
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryNew<TKey, TValue>
    {
        private struct Entry
        {
            public int hashCode;    // Lower 31 bits of hash code, -1 if unused
            public int next;        // Index of next entry, -1 if last
            public TKey key;           // Key of entry
            public TValue value;         // Value of entry
        }

        private int[] buckets;
        private Entry[] entries;
        private int count;
        private int version;
        private int freeList;
        private int freeCount;

        private void Initialize(int capacity)
        {
            int size = capacity;
            buckets = new int[size];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
            entries = new Entry[size];
            freeList = -1;
        }

        public TValue this[TKey key]
        {
            get
            {
                int i = FindEntry(key);
                if (i >= 0) return entries[i].value;
                return default(TValue);
            }
            set
            {
                Insert(key, value, false);
            }
        }

        private int FindEntry(TKey key)
        {
            if (key == null)
            {
            }

            if (buckets != null)
            {
                //int hashCode = key.GetHashCode() & 0x7FFFFFFF;
                int hashCode = key.GetHashCode() & 0x3;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
                {
                    if (entries[i].hashCode == hashCode && Equals(entries[i].key, key)) return i;
                }
            }
            return -1;
        }


        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        private void Insert(TKey key, TValue value, bool add)
        {
            if (buckets == null) Initialize(7);
            int hashCode = key.GetHashCode() & 0x3;
            //int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;

            //循环冲突
            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && Equals(entries[i].key, key))
                {
                    entries[i].value = value;
                    version++;
                    return;
                }
            }

            //添加元素
            int index;
            //是否有空列表
            if (freeCount > 0)
            {
                index = freeList;
                freeList = entries[index].next;
                freeCount--;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();//自动扩容
                    targetBucket = hashCode % buckets.Length;//哈希函数寻址
                }
                index = count;
                count++;
            }

            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            buckets[targetBucket] = index;
        }

        private void Resize()
        {
            Resize(11, false);
        }

        private void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;
            Entry[] newEntries = new Entry[newSize];
            Array.Copy(entries, 0, newEntries, 0, count);
            if (forceNewHashCodes)
            {
                for (int i = 0; i < count; i++)
                {
                    if (newEntries[i].hashCode != -1)
                    {
                        newEntries[i].hashCode = (newEntries[i].key.GetHashCode() & 0x7FFFFFFF);
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                int bucket = newEntries[i].hashCode % newSize;
                newEntries[i].next = newBuckets[bucket];
                newBuckets[bucket] = i;
            }
            buckets = newBuckets;
            entries = newEntries;
        }
    }
}
