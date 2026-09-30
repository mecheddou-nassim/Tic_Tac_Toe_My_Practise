using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_My_Practise
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        stGameStatus GameStataus;
        enPlayerTurn PlayerTurn = enPlayerTurn.Player1;
        
       enum enWinner
        {
            player1,
            player2,
            Draw
        };
        enum enPlayerTurn
        {
            Player1,
            Player2

        };
        struct stGameStatus
        {
            public enWinner winner;
            public int Playcount;
            public bool GameOver;
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Color white=Color.FromArgb(255,255,255);    
            Pen pen=new Pen(white);
            pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap=System.Drawing.Drawing2D.LineCap.Round;
            e.Graphics.DrawLine(pen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(pen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(pen, 610, 140, 610, 620);
            e.Graphics.DrawLine(pen, 840, 140, 840, 620);
        }
        void EndGame()
        {
            switch (GameStataus.winner)
            {
                case enWinner.player1:
                    {
                        ResultLabel.Text = "Player1";
                        break;
                    }
                case enWinner.player2:
                    {
                        ResultLabel.Text = "Player2";
                        break;
                    }
                case enWinner.Draw:
                    {
                        ResultLabel.Text = "Draw";
                        break;
                    }
            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      public  bool cheackValue(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.Green; 
                btn2.BackColor=Color.Green; 
                btn3.BackColor=Color.Green;
                if (btn1.Tag.ToString() == "X")
                {
                    GameStataus.winner = enWinner.player1;
                    player_label.Text = "Game Over";
                    GameStataus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStataus.winner = enWinner.player2;
                    player_label.Text = "Game Over";
                    GameStataus.GameOver = true;
                    EndGame();
                    return true;
                }
                
                
            }
            return false;
        }
        void checkWinner()
        {
            if (cheackValue(button1, button2, button3))
            {
                return;
            }
            if (cheackValue(button4, button5, button6))
            {
                return;
            }
            if (cheackValue(button7, button8, button9))
            {
                return;
            }
            if (cheackValue(button1, button4, button7))
            {
                return;
            }
            if (cheackValue(button2, button5, button8))
            {
                return;
            }
            if (cheackValue(button3, button6, button9))
            {
                return;
            }
            if (cheackValue(button1, button5, button9))
            {
                return;
            }
            if (cheackValue(button3, button5, button7))
            {
                return;
            }
        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }
        void changeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")

            {
                switch (PlayerTurn)
                {
                    
             
                    case enPlayerTurn.Player1:
                        {
                            btn.Image = Properties.Resources.X;
                            btn.Tag = "X";
                            player_label.Text = "Player2";
                            PlayerTurn = enPlayerTurn.Player2;
                            GameStataus.GameOver = true;
                            GameStataus.Playcount++;
                            checkWinner();
                            
                            break;
                        }
                    case enPlayerTurn.Player2:
                        {
                            btn.Image = Properties.Resources.O;
                            btn.Tag = "O";
                            player_label.Text = "Player1";
                            PlayerTurn = enPlayerTurn.Player1;
                            GameStataus.GameOver = true;
                            GameStataus.Playcount++;
                            checkWinner();
                            break;
                        }




                }
            }
            else
            {
                MessageBox.Show("wrong choice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (GameStataus.Playcount == 9)
            {
                GameStataus.GameOver = true;
                GameStataus.winner = enWinner.Draw;
                ResultLabel.Text = "Game Over";
                EndGame();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            changeImage((Button)sender);
        }
       
        void restButton(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            PlayerTurn = enPlayerTurn.Player1;
            btn.BackColor = Color.Transparent;
            GameStataus.GameOver = false;
            ResultLabel.Text = "In Progress";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            restButton(button1);
            restButton(button2);
            restButton(button3);
            restButton(button4);
            restButton(button5);
            restButton(button6);
            restButton(button7);
            restButton(button8);
            restButton(button9);
        }
    }
}
