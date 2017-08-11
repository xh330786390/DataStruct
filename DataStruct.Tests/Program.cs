using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStruct;

namespace DataStruct.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //@线性-链表
            LinkList<string> linklist = new LinkList<string>();
            linklist.Add("1");
            linklist.Add("2");
            linklist.Add("4");
            linklist.Add("5");

            linklist.Insert("3", 2);
            linklist.Delete(3);
            Console.Read();

            //@字典
            DictionaryNew<int, string> dict = new DictionaryNew<int, string>();
            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, i.ToString());
            }

            string strDict = dict[0];

            Console.Read();

            //@线性-顺序表
            ISList<string> list = new SequenList<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Insert("A", 2);

            list.Add("4");
            list.Insert("B", 2);
            list.Add("5");

            var str = list.Get(3);
            list.Clear();
            Console.Read();

        }
    }
}
