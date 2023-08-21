using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializePlayer();
            InitializeEnemies();
            GameLoop();

        }

        public void GameLoop()
        {
            // Move player 2's paddle based on keys
            if (keysPressed.ContainsKey(Key.Up) && keysPressed[Key.Up])
            {
                playerInstance?.MovePlayer(1);
            }
            else if (keysPressed.ContainsKey(Key.Down) && keysPressed[Key.Down])
            {
                playerInstance?.MovePlayer(-1);

            }
        }

        public void InitializePlayer()
        {
            Rectangle? playerRectangle = gameGrid.FindName("Player") as Rectangle;
            if (playerRectangle != null)
            {
                playerInstance = new Player(playerRectangle);
            }
        }

        public void InitializeEnemies()
        {
            enemies = new Enemy[numRows, numCols];

            for (int row = 0; row < 2; row++) 
            {
                for (int col = 0; col < numCols; col++)
                {
                    Rectangle enemyRect = new Rectangle
                    {
                        Width = enemyWidth,
                        Height = enemyHeight,
                        Fill = Brushes.Red
                    };

                    Grid.SetColumn(enemyRect, col);
                    Grid.SetRow(enemyRect, row);

                    gameGrid.Children.Add(enemyRect);

                    enemies[row, col] = new Enemy(enemyRect);
                }
            }
        }

        //private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        //{
        //    playerInstance?.MovePlayer();
        //}

        
        private Player? playerInstance;
        private const int numRows = 5; 
        private const int numCols = 10; 
        private const int enemyWidth = 40; 
        private const int enemyHeight = 30;

        private Enemy[,] enemies;
        private Dictionary<Key, bool> keysPressed = new Dictionary<Key, bool>();

    }
}
