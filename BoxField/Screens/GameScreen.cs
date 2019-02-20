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
        int boxCounter = 0;
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
                b.y = b.y + 5;
            }

            //TODO - remove box if it has gone of screen
           if(boxesLeft[0].y > 300)
            {
                boxesLeft.RemoveAt(0);
            }
            //TODO - add new box if it is time
            if (boxCounter == 8)
            {
                box b1 = new box(50, 50, 20);
                boxesLeft.Add(b1);
                boxCounter = 0;
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
           //draw boxes to screen
           foreach(box b in boxesLeft)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

        }
    }
}
