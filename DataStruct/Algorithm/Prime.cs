using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Algorithm
{
    /// <summary>
    /// 查找质数
    /// 出
    /// </summary>
    public class Prime
    {

        public List<int> SeekPrime(int n)
        {
            int max_sqrt = (int)Math.Floor(Math.Sqrt(n));

            List<int> lt_sqrt_prime = new List<int>();
            for (int i = 2; i <= max_sqrt; i++)
            {
                if (isPrime(i))
                {
                    lt_sqrt_prime.Add(i);
                }
            }


            List<int> lt_prime = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime(lt_sqrt_prime.ToArray(), i))
                {
                    lt_prime.Add(i);
                }
            }
            return lt_prime;
        }
        //@1：O(n)
        //bool isPrime(int n)
        //{
        //    if (n < 2) return false;

        //    for (int i = 2; i < n; ++i)
        //        if (n % i == 0) return false;

        //    return true;
        //}

        //@2：O(n/2)
        //bool isPrime(int n)
        //{
        //    if (n < 2) return false;
        //    if (n == 2) return true;
        //    if (n % 2 == 0) return false;

        //    for (int i = 3; i < n; i += 2)
        //        if (n % i == 0) return false;

        //    return true;
        //}

        //@3：O(sqrt(n))
        bool isPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;

            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;

            return true;
        }

        //// primes[i]是递增的素数序列: 2, 3, 5, 7, ...
        //// 更准确地说primes[i]序列包含1->sqrt(n)范围内的所有素数

        bool isPrime(int[] primes, int n)
        {
            if (n < 2) return false;

            for (int i = 0; i < primes.Length; i++)
            {
                if (n % primes[i] == 0) return false;
            }

            return true;
        }
    }
}
