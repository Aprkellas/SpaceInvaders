﻿using System;
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

        public Player(System.Windows.Shapes.Rectangle rectangle,
            Dictionary<Tuple<int, int>, Player> positionMap)
        {
            playerRectangle = rectangle;
            playerPositionMap = positionMap;
        }

        public void MovePlayer(int direction)
        {
            playerColumn = Grid.GetColumn(playerRectangle);

            switch (direction)
            {
               
                case -1:
                    if ((playerColumn - 1) >= 0)
                    {
                        Grid.SetColumn(playerRectangle, (playerColumn - 1));
                        playerNextColumn = playerColumn - 1;
                    }
                    break;

                case 1:
                    if ((playerColumn + 1) <= 12)
                    {
                        Grid.SetColumn(playerRectangle, (playerColumn + 1));
                        playerNextColumn = playerColumn + 1;

                    }
                    break;
            }
            UpdatePosition(playerNextColumn);
        }
        private void UpdatePosition(int newCol)
        {
            playerPositionMap.Remove(Tuple.Create(9, playerColumn));
            playerPositionMap.Add(Tuple.Create(9, newCol), this);
        }

        public void TakeHit()
        {
            if (playerHealth <= 0)
            {
                Application.Current.Shutdown();
            } 
            else
            {
                playerHealth -= 2;
            }
        }


        public System.Windows.Shapes.Rectangle playerRectangle;
        private Dictionary<Tuple<int, int>, Player> playerPositionMap;

        public int playerHealth = 10;
        public int playerColumn;
        public int playerNextColumn;



    }

}
