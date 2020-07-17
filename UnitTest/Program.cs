﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Cmp
    {
        public static int Largest(int[] list)
        {
            if (list.Length == 0)
                throw new ArgumentException("larget: Empty List");
            int max = int.MinValue;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
