using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SpaceInvaders
{
    class Enemy
    {

        public Enemy(System.Windows.Shapes.Rectangle rectangle) 
        { 
            enemyRectangle = rectangle;
        }

        public void EnemyMove()
        {
            double currentLeft = Canvas.GetLeft(enemyRectangle);
            double newLeft = currentLeft + (moveDistance * moveDirection);

            if (newLeft < 0 || newLeft + enemyRectangle.Width > 800) 
            {
                MoveDown();
                moveDirection *= -1;
            }
        }
        private void MoveDown()
        {
            currentRow++;
            double currentTop = Canvas.GetTop(enemyRectangle);
            Canvas.SetTop(enemyRectangle, currentTop + rowHeight);
        }

        private const int moveDistance = 10;
        private const int rowHeight = 45;

        private System.Windows.Shapes.Rectangle enemyRectangle;
        private int currentRow = 0;
        private int moveDirection = 1;
    }
}
