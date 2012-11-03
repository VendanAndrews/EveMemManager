using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MemManager
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetProcessWorkingSetSize(IntPtr hProcess, uint
           dwMinimumWorkingSetSize, uint dwMaximumWorkingSetSize);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        static void Main(string[] args)
        {
            uint min = 104857600;
            uint max = 1073741824;
            if(args.Length == 2)
            {
                min = Convert.ToUInt32(args[0]);
                max = Convert.ToUInt32(args[1]);
            }
            if(args.Length == 1)
            {
                max = Convert.ToUInt32(args[0]);
            }

            SetProcessWorkingSetSize(GetCurrentProcess(), min, max);
        }
    }
}
