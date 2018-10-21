using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace ClassLibWinForms
{
    public interface IWindowApp
    {
        void Run(IntPtr callbackFun, IntPtr callbackAct);
        void ChangeValue(int a);
        int GetValue();
    }
    
    public delegate void action(int a, int b);

    public delegate int function();
    
    public class ManagedClass:IWindowApp
    {
        public event EventHandler propertyChanged;
        private WindowForm winForm;

        public void Run(IntPtr callbackAct, IntPtr callbackFun)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var act = (action)Marshal.GetDelegateForFunctionPointer(callbackAct, typeof(action));
            var func = (function)Marshal.GetDelegateForFunctionPointer(callbackFun, typeof(function));
            var form = new WindowForm(act, func);
            propertyChanged = form.handler;
            winForm = form;
            Application.Run(form);
        }

        public void ChangeValue(int a)
        {
            propertyChanged?.Invoke((object)a, new EventArgs());
        }

        public int GetValue()
        {
            if (winForm == null) return 0;
            else return winForm.GetValue();
        }
    }
}
