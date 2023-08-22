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
                  
        }
        private void MoveDown()
        {
            
        }
        private void MoveLeft()
        {

        }
        private void MoveRight()
        {

        }

        private DispatcherTimer timer;
        
        private const int moveDistance = 10;
        private const int rowHeight = 45;

        private System.Windows.Shapes.Rectangle enemyRectangle;
        private int currentRow = 0;
        private int moveDirection = 1;
    }
}
