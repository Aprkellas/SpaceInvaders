using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

/// <summary>
/// Holds enemy class with methods for all enemies 
/// abilities
/// </summary>


namespace SpaceInvaders
{
    class Enemy
    {
        public Enemy(System.Windows.Shapes.Rectangle rectangle, Grid grid)
        { 
            enemyRectangle = rectangle;
            gameGrid = grid;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EnemyMove();
        }
        // enemy movement logic
        public void EnemyMove()
        {
            int enemyColumn = Grid.GetColumn(enemyRectangle);
            int enemyRow = Grid.GetRow(enemyRectangle);

            int enemyNextColumn = enemyColumn + 1;
            int enemyNextRow = enemyRow + 1;

            int enemyNextColumnLeft = enemyColumn - 1;

            if (!movingLeft) { 
                if (enemyNextColumn !< 12)
                {
                    Grid.SetColumn(enemyRectangle, enemyNextColumn);
                } 
                else if (enemyNextColumn >= 12)
                {
                    Grid.SetRow(enemyRectangle, enemyNextRow);
                    movingLeft = true;
                }
            } else
            {
                if (enemyNextColumnLeft >= 0)
                {
                    Grid.SetColumn(enemyRectangle, enemyNextColumnLeft);
                }
                else if (enemyColumn == 0)
                {
                    Grid.SetRow(enemyRectangle, enemyNextRow);
                    movingLeft = false;
                }
            }
        }
        // logic for enemy getting hit by a laser
        private void GetHit()
        {
            if (enemyHealth <= 0)
            {
                gameGrid.Children.Remove(enemyRectangle);
            }
            else 
            { 
                enemyHealth -= 2;
            }
        }

        private Grid gameGrid;
        private DispatcherTimer timer;
        private System.Windows.Shapes.Rectangle enemyRectangle;

        private bool movingLeft = false;
        private int enemyHealth = 10;
    }
}
