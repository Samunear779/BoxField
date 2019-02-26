using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        //create a list to hold a column of boxes        
        List<box> boxesLeft = new List<box>();
        List<box> boxesRight = new List<box>();
        int boxSpeed = 5;
        int boxCounter = 0;

        box player;
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //TODO - set game start values

            box b1 = new box(50, 50, 20);
            boxesLeft.Add(b1);
            box b2 = new box(900, 50, 20);
            boxesRight.Add(b2);
            player = new box(400, this.Height - 50, 20);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;           
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            boxCounter++;
            //TODO - update location of all boxes (drop down screen)
            foreach (box b in boxesLeft)
            {
                b.Move(boxSpeed);
            }

            foreach (box b in boxesRight)
            {
                b.Move(boxSpeed);
            }

            if(leftArrowDown)
            {
                player.Move(5, "left");
            }

            if(rightArrowDown)
            {
                player.Move(5, "right");
            }

            //check for collsioon between player and boxes
            foreach(box b in boxesLeft.Union(boxesRight))
            {
                if (player.Collision(b))
                {
                    gameLoop.Stop();
                }
            }

            //TODO - remove box if it has gone of screen
            if (boxesLeft[0].y > this.Height)
            {
                boxesLeft.RemoveAt(0);
            }

            if (boxesRight[0].y > this.Height)
            {
                boxesRight.RemoveAt(0);
            }
            //TODO - add new box if it is time
            if (boxCounter == 8)
            {
                box b1 = new box(50, 50, 20);
                boxesLeft.Add(b1);
            
                box b2 = new box(700, 50, 20);
                boxesRight.Add(b2);
                boxCounter = 0;
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
           //draw boxes to screen
           foreach(box b1 in boxesLeft)
            {
                e.Graphics.FillRectangle(boxBrush, b1.x, b1.y, b1.size, b1.size);              
            }

           foreach(box b2 in boxesRight)
            {
                e.Graphics.FillRectangle(boxBrush, b2.x, b2.y, b2.size, b2.size);
            }
            e.Graphics.FillEllipse(boxBrush, player.x, player.y, player.size, player.size);
        }
    }
}
