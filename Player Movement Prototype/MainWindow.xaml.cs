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
        private DispatcherTimer update = new DispatcherTimer();//constantly updates the game to reflect noticeable changes like movement
        private int framesPerSecond = 90;
        private int playerX;
        private int playerSpeedX = 5;
        private int playerY;
        private int playerSpeedY = 5;

        public MainWindow()
        {
            InitializeComponent();
            playerX = (int)Canvas.GetLeft(player);//gets player starting x position which I have set to 0;
            playerY = (int)Canvas.GetTop(player);//gets player starting y position which I have set to 180;
            update.Tick += Update_Tick;
            update.Interval = TimeSpan.FromMilliseconds(1000 / framesPerSecond);
            //update.Start();
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            //drawAll();
            MoveAll();
        }

        private void MoveAll()
        {
            ///<summary>
            ///timer constantly calls this method to enable motion of player's square object
            ///</summary>
            playerX += playerSpeedX;//adds speed to player's x coord
            //next two if statements check if player's x coord (left property) passes the game level boundaries
            if (playerX > gameCanvas.Width - player.Width)
            {
                //if player's left prop passes the width of the canvas minus the player's width then send it to the left
                playerSpeedX = -playerSpeedX;
            }
            if (playerX < 0)
            {
                //if player's left prop passes the origin of the canvas (0) then send it to the right
                playerSpeedX = -playerSpeedX;
            }
            //next line sets the player's x coord to updated x coord
            Canvas.SetLeft(player, playerX);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            ///<summary>
            ///event handler for player pressing the left and right keys or the A and D keys
            ///Also handles vertical movement with up/down keys or W/S keys
            ///Doesn't handle diagonal movement yet
            ///will only move the player to until he or she hits game level boundaries
            ///</summary>
            if ((e.Key == Key.Left && playerX > 0) ||
                (e.Key == Key.A && playerX > 0))
            {
                playerX -= playerSpeedX;
            }
            if ((e.Key == Key.Right && playerX < gameCanvas.Width - player.Width) ||
                (e.Key == Key.D && playerX < gameCanvas.Width - player.Width))
            {
                playerX += playerSpeedX;
            }
            if ((e.Key == Key.Up && playerY > 0) ||
               (e.Key == Key.W && playerY > 0))
            {
                playerY -= playerSpeedY;
            }
            if ((e.Key == Key.Down && playerY < gameCanvas.Height - player.Height) ||
                (e.Key == Key.S && playerY < gameCanvas.Height - player.Height))
            {
                playerY += playerSpeedY;
            }
            

            Canvas.SetLeft(player, playerX);
            Canvas.SetTop(player, playerY);
        }

        private void drawAll()
        {
            //Rectangle rectangle = new Rectangle();//creates rectangle
            //rectangle.Stroke = new SolidColorBrush(Colors.Blue);//draws outline of rectangle 
            //rectangle.StrokeThickness = 5;//sets thickness of the rectangle's outline
            //rectangle.Fill = new SolidColorBrush(Colors.Black);//fills the inside of the rectangle
            ////next two lines set width and height of rectangle which at this point is a square
            //rectangle.Width = 50;
            //rectangle.Height = 50;
            ////next two lines set x and y coords. Remember that these refer to the top left corner of the square
            //Canvas.SetLeft(rectangle, 300);
            //Canvas.SetTop(rectangle, 50);
            ////next line adds the square as a child of the canvas which I have set in XAML
            //gameCanvas.Children.Add(rectangle);

            //Ellipse circle = new Ellipse();//creates an ellipse
            //circle.Stroke = new SolidColorBrush(Colors.Red);//draws outline of ellipse
            //circle.StrokeThickness = 5;//sets thickness of ellipse's outline
            //circle.Fill = new SolidColorBrush(Colors.Black);//fills inside of ellipse
            ////next two lines set width and height of ellipse which make it a circle more or less
            //circle.Width = 25;
            //circle.Height = 25;
            ////next two lines set x and y coords. They don't refer to the circle's center point instead they refer to the left and top points of it
            //Canvas.SetLeft(circle, 550);
            //Canvas.SetTop(circle, -200);
            //gameCanvas.Children.Add(circle);
        }     
    }
}
