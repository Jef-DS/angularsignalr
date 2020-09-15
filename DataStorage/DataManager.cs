using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace angularsignalr.DataStorage
{
    public static class DataManager
    {
        public static String GetTime()
        {
          
            return DateTime.Now.ToLongTimeString();
        }
    }
}
