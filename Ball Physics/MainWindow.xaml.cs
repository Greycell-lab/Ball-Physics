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
using System.Windows.Threading;

namespace Ball_Physics
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double physicSpeed = 0;
        bool ballDown = true, up, down;
        int ballHits = 0;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer gameTime = new DispatcherTimer();
            gameTime.Interval = TimeSpan.FromMilliseconds(20);
            gameTime.Tick += gameEngine;
            gameTime.Start();
            myCanvas.Focus();
        }
        void gameEngine(object sender, EventArgs e)
        {
            hits.Content = "Hits: " + ballHits;
            Rect bottomHitbox = new Rect(Canvas.GetLeft(bottom), Canvas.GetTop(bottom), bottom.Width, bottom.Height);
            Rect ballHitbox = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
            if(ballDown)
            {
                if(physicSpeed < 0) physicSpeed = 0;
                physicSpeed += 0.40;
                Canvas.SetTop(ball, Canvas.GetTop(ball) + physicSpeed);
                if(ballHitbox.IntersectsWith(bottomHitbox))
                {
                    Canvas.SetTop(ball, Canvas.GetTop(bottom) - ball.Height - 10);
                    ballHits++;
                    ballDown = false;
                }
            }
            if(!ballDown)
            {
                physicSpeed -= 0.40;
                Canvas.SetTop(ball, Canvas.GetTop(ball) - physicSpeed);
                if (physicSpeed <= 0) ballDown = true;
            }
            if(up)
            {
                Canvas.SetTop(bottom, Canvas.GetTop(bottom) - 10);
            }
            if(down)
            {
                Canvas.SetTop(bottom, Canvas.GetTop(bottom) + 10);
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) up = false;
            else if (e.Key == Key.Down) down = false;  
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) up = true;
            else if (e.Key == Key.Down) down = true;
        }
    }
}
