using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Test
    {
        static void Main(string[] args)
        {
            var newTimer = new Timer(2, 10);
            newTimer.InvokeDelegate();
        }
    }
}
