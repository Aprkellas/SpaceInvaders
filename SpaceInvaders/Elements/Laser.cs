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
        public Laser(System.Windows.Shapes.Rectangle rectangle, int startingRow)
        {
            laserRectangle = rectangle;
            row = startingRow;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500); // Move every 0.5 seconds
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
            if (row < 0)
            {
                timer.Stop();
                // Remove laser from the grid or perform other actions
            }
            else
            {
                // Update the laser's position
                Canvas.SetTop(laserRectangle, row * laserHeight);
            }
        }

        private DispatcherTimer timer;
        private int laserHeight = 10;
        private int row;
        private System.Windows.Shapes.Rectangle laserRectangle;
    }
}
