using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Square_Chaser
{
    public partial class squareChaser : Form
    {
        Random randGen = new Random();
        
        Rectangle player1 = new Rectangle(10, 170, 30, 30);
        Rectangle player2 = new Rectangle(550, 170, 30, 30);
        Rectangle whiteSquare = new Rectangle(150, 200, 10, 10);
        Rectangle powerBall = new Rectangle(250, 300, 9, 9);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;

        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        public squareChaser()
        {
            InitializeComponent();

            int x = randGen.Next(20, 595);
            int y = randGen.Next(20, 495);
            int x2 = randGen.Next(20, 595);
            int y2 = randGen.Next(20, 495);

            whiteSquare.X = x;
            whiteSquare.Y = y;
            powerBall.X = x2;
            powerBall.Y = y2;
        }

        private void squareChaser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void squareChaser_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X < 600)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //check for collison with white square and player
            //randomize white square location
            //and give player point
            if (player1.IntersectsWith(whiteSquare))
            {
                whiteSquare.X = randGen.Next(20, 595);
                whiteSquare.Y = randGen.Next(20, 495);

                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
            }
            else if (player2.IntersectsWith(whiteSquare))
            {
                whiteSquare.X = randGen.Next(20, 595);
                whiteSquare.Y = randGen.Next(20, 495);

                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
            }

            //check for collision with power ball and player
            //randomize power ball location
            //and speed up player
            if (player1.IntersectsWith(powerBall))
            {
                powerBall.X = randGen.Next(20, 595);
                powerBall.Y = randGen.Next(20, 495);

                playerSpeed *= 2;
            }
            else if (player2.IntersectsWith(powerBall))
            {
                powerBall.X = randGen.Next(20, 595);
                powerBall.Y = randGen.Next(20, 495);

                playerSpeed *= 2;
            }

            Refresh();
        }

        private void squareChaser_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(greenBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, whiteSquare);
            e.Graphics.FillEllipse(yellowBrush, powerBall);
        }
    }
}
