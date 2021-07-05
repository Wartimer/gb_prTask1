using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gb_prTasks8_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = nud1.Value.ToString();
        }

        private void nud1_ValueChanged(object sender, EventArgs e)
        {

            textBox1.Text = nud1.Value.ToString();
        }
    }
}
