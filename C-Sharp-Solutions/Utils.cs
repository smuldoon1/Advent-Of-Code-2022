using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Utils
{
    public static int Mod(int a, int b)
    {
        return ((a % b) + b) % b;
    }
} 
