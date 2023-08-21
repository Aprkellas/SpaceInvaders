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

        public void MovePlayer(Key key)
        {
            const int moveDistance = 10;

            switch (key)
            {
                case Key.Left:
                    Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) - moveDistance); 
                    break;

                case Key.Right:
                    Canvas.SetRight(playerRectangle, Canvas.GetRight(playerRectangle) + moveDistance);
                    break;
            }

        }

        private System.Windows.Shapes.Rectangle playerRectangle;
        public int xdirection = 0;

    }

}
