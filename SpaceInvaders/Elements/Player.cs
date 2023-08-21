using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.Windows.Input;

namespace SpaceInvaders
{
    class Player
    {

        public Player(System.Windows.Shapes.Rectangle rectangle)
        {
            playerRectangle = rectangle;
        }

        public void MovePlayer(int direction)
        {
            const int moveDistance = 10;

            switch (direction)
            {
                case -1:
                    Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) - moveDistance);
                    break;

                case 1:
                    Canvas.SetRight(playerRectangle, Canvas.GetRight(playerRectangle) + moveDistance);
                    break;
            }
        }


        private System.Windows.Shapes.Rectangle playerRectangle;
        public int xdirection = 0;

    }

}
