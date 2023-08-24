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
            int playerColumn = Grid.GetColumn(playerRectangle);

            switch (direction)
            {
               
                case -1:
                    if ((playerColumn - 1) >= 0)
                    {
                        Grid.SetColumn(playerRectangle, (playerColumn - 1));
                    }
                    break;

                case 1:
                    if ((playerColumn + 1) <= 12)
                    {
                        Grid.SetColumn(playerRectangle, (playerColumn + 1));
                    }
                    break;
            }
        }


        public System.Windows.Shapes.Rectangle playerRectangle;
        public int playerHealth = 10;
    }

}
