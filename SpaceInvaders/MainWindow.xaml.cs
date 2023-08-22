﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializePlayer();
            InitializeEnemies();
            GameLoop();

            KeyDown += MainWindow_KeyDown;
        }

        public void GameLoop()
        {

        }

        public void InitializePlayer()
        {
            Rectangle? playerRectangle = gameGrid.FindName("Player") as Rectangle;
            if (playerRectangle != null)
            {
                playerInstance = new Player(playerRectangle);
            }
        }

        public void InitializeEnemies()
        {
            enemies = new Enemy[2, numCols];

            for (int row = 0; row < 2; row++) 
            {
                for (int col = 0; col < numCols; col++)
                {
                    Rectangle enemyRect = new Rectangle
                    {
                        Width = enemyWidth,
                        Height = enemyHeight,
                        Fill = Brushes.Red
                    };

                    Grid.SetColumn(enemyRect, col);
                    Grid.SetRow(enemyRect, row);

                    gameGrid.Children.Add(enemyRect);

                    enemies[row, col] = new Enemy(enemyRect);
                }
            }
        }

        public void InitializeLaser()
        {
            Rectangle laserRectangle = new Rectangle
            {
                Width = laserWidth,
                Height = laserHeight,
                Fill = Brushes.Blue 
            };

            Grid.SetColumn(laserRectangle, Grid.GetColumn(playerInstance.playerRectangle)); 
            Grid.SetRow(laserRectangle, Grid.GetRow(playerInstance.playerRectangle) - 1 ); 

            gameGrid.Children.Add(laserRectangle);

            laserInstance = new Laser(laserRectangle, numRows - 1, gameGrid);
        }


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                playerInstance?.MovePlayer(-1);
            }
            else if (e.Key == Key.Right)
            {
                playerInstance?.MovePlayer(1);
            }
            else if (e.Key == Key.Up) 
            {
                InitializeLaser();
            }
        }

        private Player? playerInstance;
        private Enemy[,] enemies;
        private Laser? laserInstance;

        private const int numRows = 10;
        private const int numCols = 14;
        private const int enemyWidth = 25; 
        private const int enemyHeight = 25;
        private const int laserWidth = 5;
        private const int laserHeight = 15;
        

    }
}
