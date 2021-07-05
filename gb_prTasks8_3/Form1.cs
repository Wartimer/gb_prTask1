using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gb_prTasks8_3
{
    public partial class Form1 : Form
    {

        private TrueFalse database;
        private TrueFalse currentDB;
        private AboutForm abForm;

        bool fileSizeExceeded = false;
        long fsLim;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Земля круглая?", true);
                database.Save();
                nudNumber.Maximum = 1;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.FileSizeExcess += OnFileSizeExcess;
                database.Load();               
            }
            if (!fileSizeExceeded)
            {
                nudNumber.Maximum = database.Count;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
                currentDB = database;
            }
            else
            {
                MessageBox.Show($"Your file exceeds the limit of {fsLim}. Please load smaller file");
                database = currentDB;
                nudNumber.Maximum = database.Count;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            else
                throw new Exception("DataBase is not created!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum = nudNumber.Maximum - 1;
            }
            else
                throw new Exception("DataBase is not created!");
        }

        private void OnFileSizeExcess(long fsLim)
        {
            fileSizeExceeded = true;
            this.fsLim = fsLim;
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFileDialog.FileName;
                database.Save();
            }

        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            abForm = new AboutForm();
            abForm.Show();
        }
    }
}

