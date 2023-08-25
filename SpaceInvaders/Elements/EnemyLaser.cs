﻿using System;
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
        public EnemyLaser(System.Windows.Shapes.Rectangle rectangle, int startingRow, Grid grid, Dictionary<Tuple<int, int>, Enemy> positionMap)
        {
            enemyLaserRectangle = rectangle;
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
            MoveDown();
    }

    public void MoveDown()
    {
        row++;
        if ((row + 1) < 9)
        {
            timer.Stop();
            gameGrid.Children.Remove(enemyLaserRectangle);
        }
        else
        {
            Grid.SetRow(enemyLaserRectangle, (Grid.GetRow(enemyLaserRectangle) - 1));
            DetectCollision();
        }
    }

    public void DetectCollision()
    {
        int LaserColumn = Grid.GetColumn(enemyLaserRectangle);
        int laserRow = Grid.GetRow(enemyLaserRectangle);
        Tuple<int, int> laserPosition = Tuple.Create(laserRow, LaserColumn);

        if (enemyPositionMap.ContainsKey(laserPosition))
        {
            Enemy hitEnemy = enemyPositionMap[laserPosition];
            hitEnemy.GetHit();
            gameGrid.Children.Remove(enemyLaserRectangle);
        }
    }

    private DispatcherTimer timer;
    private Grid gameGrid;
    private Dictionary<Tuple<int, int>, Enemy> enemyPositionMap;


    private int row;
    private System.Windows.Shapes.Rectangle enemyLaserRectangle;
}
}
