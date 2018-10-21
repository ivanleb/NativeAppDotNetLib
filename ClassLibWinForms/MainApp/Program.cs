using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibWinForms;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace MainApp
{
    class Program
    {
        static void PrintCoordinates(int x, int y) => Console.WriteLine($"x={x}, y={y}");

        static int SendValue()
        {
            return 42;
        }

        static void Main(string[] args)
        {
            var mc = new ManagedClass();

            action actionDelegateInstance = PrintCoordinates;
            var act =  Marshal.GetFunctionPointerForDelegate(actionDelegateInstance);

            function functionDelegateInstance = SendValue;
            var func = Marshal.GetFunctionPointerForDelegate(functionDelegateInstance);

            Task.Run(() => {mc.Run(act, func); });

            int j = 0;
            while (true)
            {
                //mc.ChangeValue(j);
                Console.WriteLine("Value from Lib: " + mc.GetValue());
                j++;
                Thread.Sleep(3000);
            }
        }
    }
}
