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
using System.Xaml;
using System.Timers;
using System.Windows.Threading;

namespace Player_Movement_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int playerX;
        private int playerSpeedX = 5;
        private int playerY;
        private int playerSpeedY = 5;

        public MainWindow()
        {
            InitializeComponent();
            playerX = (int)Canvas.GetLeft(player);//gets player starting x position which I have set to 0;
            playerY = (int)Canvas.GetTop(player);//gets player starting y position which I have set to 180;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            ///<summary>
            ///event handler for player pressing the left and right keys or the A and D keys
            ///also handles vertical movement with up/down keys or W/S keys
            ///also handles diagonal movement by using Keyboard.IsKeyDown() instead of using e.Key == Key.keyPressed
            ///will only move the player to until he or she hits game level boundaries
            ///it is laggy but it works
            ///</summary>
            if ((Keyboard.IsKeyDown(Key.Left) && playerX > 0) ||
                (Keyboard.IsKeyDown(Key.A) && playerX > 0))
            {
                playerX -= playerSpeedX;
            }
            else if ((Keyboard.IsKeyDown(Key.Right) && playerX < gameCanvas.Width - player.Width) ||
                (Keyboard.IsKeyDown(Key.D) && playerX < gameCanvas.Width - player.Width))
            {
                playerX += playerSpeedX;
            }
            if ((Keyboard.IsKeyDown(Key.Up) && playerY > 0) ||
               (Keyboard.IsKeyDown(Key.W) && playerY > 0))
            {
                playerY -= playerSpeedY;
            }
            else if ((Keyboard.IsKeyDown(Key.Down) && playerY < gameCanvas.Height - player.Height) ||
                (Keyboard.IsKeyDown(Key.S) && playerY < gameCanvas.Height - player.Height))
            {
                playerY += playerSpeedY;
            }
            //next two lines set player's x and y coords based on player input
            Canvas.SetLeft(player, playerX);
            Canvas.SetTop(player, playerY);
        }    
    }
}
