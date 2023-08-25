using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

/// <summary>
/// Holds enemy laser abilities/ 
/// </summary>

namespace SpaceInvaders.Elements
{
    class EnemyLaser
    {
        public EnemyLaser(System.Windows.Shapes.Rectangle rectangle, int startingRow, Grid grid, Dictionary<Tuple<int, int>, Player> positionMap)
        {
            enemyLaserRectangle = rectangle;
            row = startingRow;
            gameGrid = grid;
            playerPositionMap = positionMap;
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
            MoveDown();
        }

        public void MoveDown()
        {
            row++;
            if (row > 9)
            {
                timer.Stop();
                gameGrid.Children.Remove(enemyLaserRectangle);
            }
            else
            {
                Grid.SetRow(enemyLaserRectangle, (Grid.GetRow(enemyLaserRectangle) + 1));
                DetectCollision();
            }
        }

        public void DetectCollision()
        {
            int LaserColumn = Grid.GetColumn(enemyLaserRectangle);
            int laserRow = Grid.GetRow(enemyLaserRectangle);
            Tuple<int, int> laserPosition = Tuple.Create(laserRow, LaserColumn);
            Console.WriteLine(laserPosition);
            if (playerPositionMap.ContainsKey(laserPosition))
            {
                Player hitPlayer = playerPositionMap[laserPosition];
                hitPlayer.TakeHit();
                gameGrid.Children.Remove(enemyLaserRectangle);
            }
        }

        private DispatcherTimer timer;
        private Grid gameGrid;
        private Dictionary<Tuple<int, int>, Player> playerPositionMap;



        private int row;


        private System.Windows.Shapes.Rectangle enemyLaserRectangle;
    }
}

