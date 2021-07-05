using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gb_prTasks8_4
{
    public partial class AddNewRecForm : Form
    {
        public Action<string, List<string>, int, int> AddRecipeEvent;
        private MainForm mainForm;
        private Recipe recipe;

        public AddNewRecForm()
        {
            InitializeComponent();

        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecipeEvent?.Invoke(tbTitle.Text, GetIngredients(), (int)(numericUpDown1.Value), GetRating());
            Close();
        }

        private List<string> GetIngredients()
        {
            var list = new List<string>();
            list.Add(tbIngr0.Text.ToString());
            list.Add(tbIngr1.Text.ToString());
            list.Add(tbIngr2.Text.ToString());
            list.Add(tbIngr3.Text.ToString());
            return list;
        }

        private int GetRating()
        {           
            if (rbRate1.Checked) return 1;
            if (rbRate2.Checked) return 2;
            if (rbRate3.Checked) return 3;
            return 0;
        }
    }
}
