using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace gb_prTasks7
{
    public partial class Form1 : Form
    {
        int turnsLeft = 0;
        int currentNumber;
        bool gameActive = false;
        int index;
        int[] minTurns = { 4, 3, 4, 8, 6, 4 };
        int[] numbers = { 16, 8, 9, 22, 33, 12 };
        Stack<int> turns = new Stack<int>();
        public event Action<int> WinCondition;
        public event Action<int> LoseCondition;
        List<Button> buttons;
        

        public Form1()
        {

            InitializeComponent();
            WinCondition += OnWin;
            LoseCondition += OnLose; 
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Reset";
            this.Text = "Doubler";
            buttons = new List<Button> { btnCommand1, btnCommand2, btnReset};
            btnUndo.Enabled = false;
            lblNumber.Text = "0";
            lblCmdsCount.Text = $"Оставшиеся ходы: / ";
            foreach(var btn in buttons)
            {
                btn.Enabled = false;
            }

        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            turnsLeft--;
            lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
            turns.Push(int.Parse(lblNumber.Text));
            ResetBtnUndo();
            ResetButtons();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            turnsLeft--;
            lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
            turns.Push(int.Parse(lblNumber.Text));
            ResetBtnUndo();
            ResetButtons();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            turnsLeft = minTurns[index];
            lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
            ResetBtnUndo();
            ResetButtons();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {                
                ResetBtnUndo();
                turnsLeft++;
                turns.Pop();
                ResetButtons();
                lblNumber.Text = turns.Peek().ToString();
                lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
                if(turnsLeft == minTurns[index])
                {
                    ResetBtnUndo();
                    lblNumber.Text = "1";
                    lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
                }            
        }

        private void ResetBtnUndo()
        {
            if (turnsLeft < minTurns[index])
            {
                btnUndo.Enabled = true;
            }
            if(turnsLeft == minTurns[index])
                btnUndo.Enabled = false;   
        }

        private void ResetButtons()
        {
            if (!gameActive)
            {
                foreach(var btn in buttons)
                {
                    btn.Enabled = false;
                }
            }
            else if(gameActive && int.Parse(lblNumber.Text) >= currentNumber)
            {
                btnCommand1.Enabled = false;
                btnCommand2.Enabled = false;
                btnReset.Enabled = true;
            }
            else if(gameActive && int.Parse(lblNumber.Text) < currentNumber)
            {
                btnCommand1.Enabled = true;
                btnCommand2.Enabled = true;
                btnReset.Enabled = true;
            }
        }

        public void OnWin(int cmds)
        {
            if (!gameActive)
            {
                lblCmdsCount.Text = $"Оставшиеся ходы: {cmds}";
                ResetButtons();
                DialogResult result;
                MessageBox.Show($"Вы получили {currentNumber} за {minTurns[index]} хода", "Вы выиграли!");
                result = MessageBox.Show($"Хотите начать заново?", "Перезапуск игры", MessageBoxButtons.YesNoCancel);
                if(result == DialogResult.Yes)
                {
                    turns.Clear();
                    StartGame();
                }
                else if(result == DialogResult.No)
                {
                    Dispose();
                }
                else if(result == DialogResult.Cancel)
                {
                    gameActive = true;
                    ResetButtons();
                }
            }      
        }

        public void OnLose(int cmds)
        {
            if (!gameActive)
            {
                lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
                ResetButtons();
                DialogResult result;
                MessageBox.Show($"Вы не получили {currentNumber} за {minTurns[index]} попытки", "ВЫ ПРОИГРАЛИ!");
                result = MessageBox.Show($"Хотите начать заново?", "Перезапуск игры", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    turns.Clear();
                    btnUndo.Enabled = false;
                    StartGame();
                }
                else if (result == DialogResult.No)
                {
                    Dispose();
                }
                else if (result == DialogResult.Cancel)
                {
                    gameActive = true;
                    ResetButtons();
                }
            }
        }

        private void StartGame()
        {
            gameActive = true;
            Random rnd = new Random();
            index = rnd.Next(0, numbers.Length);
            turnsLeft = minTurns[index];
            currentNumber = numbers[index];
            MessageBox.Show($"{numbers[index]}", $"Получите это число за наименьшее количество попыток");
            lblGoal.Text = $"Цель: {numbers[index]}";
            lblCmdsCount.Text = $"Оставшиеся ходы: {turnsLeft}";
            lblNumber.Text = "1";

            turns.Push(int.Parse(lblNumber.Text));
            ResetButtons();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCmdsCount_TextChanged(object sender, EventArgs e)
        {
            if (turnsLeft == 0 && int.Parse(lblNumber.Text) == currentNumber && gameActive && int.Parse(lblNumber.Text) > 1)
            {
                lblNumber.Text = currentNumber.ToString();
                gameActive = false;
                WinCondition?.Invoke(turnsLeft);
            }

            else if (turnsLeft == 0 && gameActive && int.Parse(lblNumber.Text) > 1 &&
                (int.Parse(lblNumber.Text) > currentNumber || int.Parse(lblNumber.Text) < currentNumber))
            {
                lblNumber.Text = currentNumber.ToString();
                gameActive = false;
                LoseCondition?.Invoke(turnsLeft);
            }

            
        }

        private void lblNumber_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(lblNumber.Text) > currentNumber && gameActive)
            {
                lblNumber.Text = currentNumber.ToString();
                //lblCmdsCount.Text = countCmds.ToString();
                gameActive = false;
                LoseCondition?.Invoke(turnsLeft);
            }
        }
    }
}
