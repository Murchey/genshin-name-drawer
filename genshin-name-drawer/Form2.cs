using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _894UP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe",".\\AllNames.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", ".\\Gold.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", ".\\Purple.txt");
        }
    }
}
