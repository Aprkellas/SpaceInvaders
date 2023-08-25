using SpaceInvaders.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Serialization;

/// <summary>
/// Holds enemy class with methods for all enemies 
/// abilities
/// </summary>


namespace SpaceInvaders
{
    class Enemy
    {
        public Enemy(System.Windows.Shapes.Rectangle rectangle, Grid grid, Dictionary<Tuple<int, int>, Enemy> positionMap)

        { 
            enemyRectangle = rectangle;
            enemyPositionMap = positionMap;
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
            
            enemyColumn = Grid.GetColumn(enemyRectangle);
            enemyRow = Grid.GetRow(enemyRectangle);

            int enemyNextColumn = enemyColumn + 1;
            int enemyNextRow = enemyRow + 1;

            int enemyNextColumnLeft = enemyColumn - 1;

            if (!movingLeft)
            {
                if (enemyNextColumn! < 12)
                {
                    Grid.SetColumn(enemyRectangle, enemyNextColumn);

                }
                else if (enemyNextColumn >= 12)
                {
                    Grid.SetRow(enemyRectangle, enemyNextRow);
                    movingLeft = true;

                }

            }
            else
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
            UpdatePositionInMap(enemyRow, enemyColumn);
        }
        private void UpdatePositionInMap(int newRow, int newCol)
        {
            enemyPositionMap.Remove(Tuple.Create(enemyRow, enemyColumn)); 
            enemyPositionMap.Add(Tuple.Create(newRow, newCol), this);    
        }

        // logic for enemy getting hit by a laser
        public void GetHit()
        {
            if (enemyHealth <= 0)
            {
                gameGrid.Children.Remove(enemyRectangle);
            }
            else 
            { 
                enemyHealth -= 2;

                colorOffset = colorOffset -10;
                System.Windows.Media.Color oldColor = ((SolidColorBrush)enemyRectangle.Fill).Color;

                byte newR = (byte)Math.Max(0, oldColor.R + colorOffset);
                byte newG = (byte)Math.Max(0, oldColor.G + colorOffset);
                byte newB = (byte)Math.Max(0, oldColor.B + colorOffset);

                System.Windows.Media.Color newColor = System.Windows.Media.Color.FromRgb(newR, newG, newB);
                enemyRectangle.Fill = new SolidColorBrush(newColor);
            }
        }

        private void Fire()
        {
            
            if (random.NextDouble() < fireProbability)
            {
                InitilizeEnemyLaser();
            }
        }

        private void InitilizeEnemyLaser()
        {
            System.Windows.Shapes.Rectangle enemyLaserRectangle = new System.Windows.Shapes.Rectangle
            {
                Width = 5,
                Height = 15,
                Fill = Brushes.Green
            };

            Grid.SetColumn(enemyLaserRectangle, Grid.GetColumn(enemyRectangle));
            Grid.SetRow(enemyLaserRectangle, Grid.GetRow(enemyRectangle));
        }

        private Enemy[,] enemies;
        private Grid gameGrid;
        private DispatcherTimer timer;
        private Dictionary<Tuple<int, int>, Enemy> enemyPositionMap;
        public System.Windows.Shapes.Rectangle enemyRectangle;

        private int colorOffset = 0;
        private bool movingLeft = false;
        private int enemyHealth = 10;
        public int enemyRow;
        public int enemyColumn;
        private Random random = new Random();
        private double fireProbability = 0.2;
    }
}
