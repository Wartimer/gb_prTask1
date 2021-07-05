using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gb_prTasks7_2
{
    public partial class StartForm : Form
    {
        InputForm inputForm;

        public StartForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            inputForm = new InputForm();
            inputForm.Show();
            
        }
    }
}
