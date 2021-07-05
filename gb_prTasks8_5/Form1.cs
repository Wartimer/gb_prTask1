using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gb_prTasks8_5
{
    public partial class MainForm : Form
    {
        private long fsLim = 1024;
        private StudentsDB database;

        public MainForm()
        {
            InitializeComponent();
            tbStatus.Text = "Load CSV file first.";
            btnSaveXML.Enabled = false;

        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            string fileName="";
            string filePath="";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName; 
                database = new StudentsDB(fileName);
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] s = sr.ReadLine().Split(';');
                            database.Add(s[0], s[1], s[2], s[3], s[4],
                                                    int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error in StreamReader sr.", MessageBoxButtons.OK);
                        }
                    }
                }

                MessageBox.Show("File uploaded to database", "Successfull Upload", MessageBoxButtons.OK);
                tbStatus.Text = $"{filePath} loaded successfully...";
                btnSaveXML.Enabled = true;
                btnLoadCSV.Enabled = false;
            }
            
        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            database.ConvertedToXmlSuccess += OnConvertToXmlSuccess;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFileDialog.FileName;
                database.Save();
            }
        }

        private void OnConvertToXmlSuccess(string fileName)
        {

            tbStatus.Text = $"{fileName} Successfully converted...";
            tbStatus.ForeColor = Color.Green;
            btnLoadCSV.Enabled = true;
            btnSaveXML.Enabled = false;

        }
    }
}
