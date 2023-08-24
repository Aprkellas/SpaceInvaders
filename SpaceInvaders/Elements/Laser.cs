using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

 // <summary >
 // Holds all logic for the laser 
 // </summary>


namespace SpaceInvaders
{
    class Laser
    {
        public Laser(System.Windows.Shapes.Rectangle rectangle, int startingRow, Grid grid, Enemy[,] enemyArray)
        {
            laserRectangle = rectangle;
            row = startingRow;
            gameGrid = grid;
            enemies = enemyArray;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveUp();
        }

        public void MoveUp()
        {
            row--;
            if ((row - 1) < 0)
            {
                timer.Stop();
                gameGrid.Children.Remove(laserRectangle);
            }
            else
            {
                Grid.SetRow(laserRectangle, (Grid.GetRow(laserRectangle) -1 ));
                DetectCollision();
            }
        }

        public void DetectCollision()
        {
            int column = Grid.GetColumn(laserRectangle);

            // Calculate the laser's current position
            Point laserPosition = new Point(row, column);

            // Check if there's an enemy at the laser's position
            try { 
            if (enemies[row, column] != null)
            {
                Enemy enemy = enemies[row, column];
                enemy.GetHit(); // Call the GetHit() method on the enemy
                gameGrid.Children.Remove(laserRectangle); // Remove the laser
                timer.Stop(); // Stop the laser's timer
                }
            } catch (Exception ex) { Console.WriteLine(ex); }
        }

        private DispatcherTimer timer;
        private Grid gameGrid;
        private Enemy[,] enemies;

        private int laserHeight = 10;
        private int row;
        private int column;
        private System.Windows.Shapes.Rectangle laserRectangle;
    }
}
