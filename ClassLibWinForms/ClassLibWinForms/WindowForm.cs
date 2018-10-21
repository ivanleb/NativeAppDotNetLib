using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibWinForms
{
    public partial class WindowForm : Form
    {
        public function callbackFunction;
        public action callbackAction;

        object lockObject = new object();

        public EventHandler handler;

        public int GetValue()
        {
            try
            {
                return int.Parse(textBox3.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        private void changeLabel(object o, EventArgs e)
        {
            int i = (int) o;
            
            lock (lockObject)
            {
                label2.Text = "Value sent off from native: " + i.ToString();
            }
        } 
        public WindowForm(action callbackA, function callbackF)
        {
            InitializeComponent();
            callbackAction = callbackA;
            callbackFunction = callbackF;
            handler +=  changeLabel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            try
            {
                x = int.Parse(textBox1.Text);
                y = int.Parse(textBox2.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //throw;
            }

            callbackAction(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = callbackFunction().ToString();
        }
    }
}
