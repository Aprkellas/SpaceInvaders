using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders
{
    class Laser
    {
        public Laser(System.Windows.Shapes.Rectangle rectangle, int startingRow, Grid grid)
        {
            laserRectangle = rectangle;
            row = startingRow;
            gameGrid = grid;
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
            }
            else
            {
                Grid.SetRow(laserRectangle, (Grid.GetRow(laserRectangle) -1 ));
            }
        }

        private DispatcherTimer timer;
        private Grid gameGrid;

        private int laserHeight = 10;
        private int row;
        private System.Windows.Shapes.Rectangle laserRectangle;
    }
}
