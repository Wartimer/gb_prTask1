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
    public partial class InputForm : Form
    {
        Random rnd;
        int number;
        int turnsLeft;
        int input;
        StartForm startForm;

        public InputForm()
        {
            InitializeComponent();
            StartGame();            
        }

        public void StartGame()
        {
            rnd = new Random();
            number = rnd.Next(1, 101);
            turnsLeft = 10;
            lblTurnsLeft.Text = turnsLeft.ToString();
            textBoxInput.Text = "";
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if(turnsLeft > 0 && InputFieldCheck())
            {
                turnsLeft--;
                if(input == number)
                {
                    lblTurnsLeft.Text = $"Turns left: {turnsLeft}";
                    DialogResult res = MessageBox.Show($"Your Number is right", "WIN!", MessageBoxButtons.RetryCancel);
                    if (res == DialogResult.Retry)
                        StartGame();
                    if (res == DialogResult.Cancel)
                    {
                        Dispose();
                    }

                }
                else if(input < number)
                {
                    lblTurnsLeft.Text = $"Turns left: {turnsLeft}";
                    MessageBox.Show("Your number is smaller. Try again");
                }
                else if (input > number)
                {
                    lblTurnsLeft.Text = $"Turns left: {turnsLeft}";
                    MessageBox.Show("Your number is larger. Try again");
                }
            }
            else if(turnsLeft == 0 && input != number)
            {
                DialogResult res = MessageBox.Show($"You spent all your turns", "GAME OVER", MessageBoxButtons.RetryCancel);
                if (res == DialogResult.Retry)
                    StartGame();
                if (res == DialogResult.Cancel)
                {
                    Dispose();
                }
            }
            else if (turnsLeft == 0 && input == number)
            {
                DialogResult res = MessageBox.Show($"You guessed the number", "WIN!", MessageBoxButtons.RetryCancel);
                if (res == DialogResult.Retry)
                    StartGame();
                if (res == DialogResult.Cancel)
                {
                    Dispose();
                }
            }
        }

        private bool InputFieldCheck()
        {
            int success;
            if(int.TryParse(textBoxInput.Text, out success))
            {
                input = success;
                return true;
            }  
            else
            {
                MessageBox.Show("Enter the correct number");
                return false;
            }

            
        }
    }
}
