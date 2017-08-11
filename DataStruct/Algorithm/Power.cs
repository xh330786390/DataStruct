using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Algorithm
{
    /// <summary>
    /// 次方
    /// </summary>
    public class Power
    {
        public void SeekPower(int n)
        {
            IsPower(10);

        }

        //判断一个整数是否是2的n次方
        private static bool IsPower(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            while (true)
            {
                if (number == 1)
                {
                    return true;
                }
                //如果是奇数
                if ((number & 1) == 1)
                {
                    return false;
                }
                //右移一位
                number >>= 1;
            }
        }
    }
}
