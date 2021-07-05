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
    public partial class MainForm : Form
    {
        private Recipe recipe;

        private RecipiesDB database;
        private RecipiesDB currentDb;
        private AddNewRecForm addForm;
        bool fileSizeExceeded = false;
        long fsLim;

        public MainForm()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            tbRecipe.Text = "Create New Recipe List to add Recipies";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new RecipiesDB(saveFileDialog.FileName);
                addForm = new AddNewRecForm();
                addForm.AddRecipeEvent += OnAddRecipeEvent;
                addForm.Show();
            }
        }

        private void OnAddRecipeEvent(string title, List<string> ingredients, int cookingTime, int rating)
        {
            database.Add(title, ingredients, cookingTime, rating);
            ddRecList.Items.Add(title);
            ddRecList.SelectedIndex = database.Count -1;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            
        }

        public void FormUpdate(Recipe recipe)
        {

            StringBuilder str = new StringBuilder();
            var count = 1;
            foreach (var s in recipe.Ingredients)
            {
                str.AppendLine($"{count}: {s}");
                count++;
            }
            str.AppendLine($"Cooking Time: {recipe.CookingTime} mins");
            str.AppendLine($"Rating: {recipe.Rating}");

            tbRecipe.Text = str.ToString();
        }

        public void FormClear()
        {
            tbRecipe.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addForm = new AddNewRecForm();
            addForm.AddRecipeEvent += OnAddRecipeEvent;
            addForm.Show();
        }

        private void ddRecList_SelectedValueChanged(object sender, EventArgs e)
        {           
            FormUpdate(database[ddRecList.SelectedIndex]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to delete the recipe?", "Delete Recipe", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if (database != null)
                {
                    database.Remove(ddRecList.SelectedIndex);
                    ddRecList.Items.RemoveAt(ddRecList.SelectedIndex);
                    if (database.Count > 0)
                    {
                        ddRecList.SelectedIndex = database.Count - 1;
                        //ddRecList.SelectedIndex = database.Count - 1;

                        FormUpdate(database[database.Count - 1]);
                    }

                    else
                        FormClear();

                }
                else
                    throw new Exception("DataBase is not created!");
            }
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFileDialog.FileName;
                database.Save();
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new RecipiesDB(openFileDialog.FileName);
                database.FileSizeExcess += OnFileSizeExcess;
                database.Load();
            }
            if (!fileSizeExceeded)
            {
                ResetFields();
                currentDb = database;
            }
            else
            {
                MessageBox.Show($"Your file exceeds the limit of {fsLim}. Please load smaller file");
                database = currentDb;
                ddRecList.MaxDropDownItems = database.Count;
                FormUpdate(database[database.Count - 1]);
                FillComboBox(database);
                ddRecList.SelectedIndex = database.Count - 1;

            }
        }

        private void ResetFields()
        {
            ddRecList.MaxDropDownItems = database.Count;
            FormUpdate(database[database.Count - 1]);
            FillComboBox(database);
            ddRecList.SelectedIndex = database.Count - 1;
        }

        private void FillComboBox(RecipiesDB database)
        {
            for (int i = 0; i < ddRecList.MaxDropDownItems; i++)
            {
                ddRecList.Items.Add(database[i].Title);
            }
        }

        private void OnFileSizeExcess(long fsLim)
        {
            fileSizeExceeded = true;
            this.fsLim = fsLim;
        }
    }
}
