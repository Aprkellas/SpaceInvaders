using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders
{
    class Enemy
    {

        public Enemy(System.Windows.Shapes.Rectangle rectangle) 
        { 
            enemyRectangle = rectangle;
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

        private DispatcherTimer timer;
        
        private const int moveDistance = 10;
        private const int rowHeight = 45;

        private System.Windows.Shapes.Rectangle enemyRectangle;
        private int currentRow = 0;
        private int moveDirection = 1;

        private bool movingLeft = false;
    }
}
