using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ksp_timer
{
    // UnityEngine debug log warpper
    class Logger
    {
        public static void log(string info)
        {
            Debug.Log(info);
        }

        public static void error(string info)
        {
            Debug.LogError(info);
        }

        public static void exception(string info)
        {
            Debug.LogException(new Exception(info));
        }

        public static void warnning(string info)
        {
            Debug.LogWarning(info);
        }
    }
}
