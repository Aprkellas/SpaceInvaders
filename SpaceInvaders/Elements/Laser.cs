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
        public Laser(System.Windows.Shapes.Rectangle rectangle, int startingRow, Grid grid, Dictionary<Tuple<int, int>, Enemy> positionMap)
        {
            laserRectangle = rectangle;
            row = startingRow;
            gameGrid = grid;
            enemyPositionMap = positionMap;
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
            int laserColumn = Grid.GetColumn(laserRectangle);
            int laserRow = Grid.GetRow(laserRectangle);
            Tuple<int, int> laserPosition = Tuple.Create(laserRow, laserColumn);

            if (enemyPositionMap.ContainsKey(laserPosition))
            {
                Enemy hitEnemy = enemyPositionMap[laserPosition];
                hitEnemy.GetHit();
                gameGrid.Children.Remove(laserRectangle);
            }
        }

        private DispatcherTimer timer;
        private Grid gameGrid;
        private Dictionary<Tuple<int, int>, Enemy> enemyPositionMap;


        private int laserHeight = 10;
        private int row;
        private int column;
        private System.Windows.Shapes.Rectangle laserRectangle;
    }
}
