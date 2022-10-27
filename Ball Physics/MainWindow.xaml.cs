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
        bool ballDown = true;
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
            Rect bottomHitbox = new Rect(Canvas.GetLeft(bottom), Canvas.GetTop(bottom), bottom.Width, bottom.Height);
            Rect ballHitbox = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
            if(ballDown)
            {
                if(physicSpeed < 0) physicSpeed = 0;
                physicSpeed += 0.25;
                Canvas.SetTop(ball, Canvas.GetTop(ball) + physicSpeed);
                if(ballHitbox.IntersectsWith(bottomHitbox))
                {
                    ballDown = false;
                }
            }
            if(!ballDown)
            {
                physicSpeed -= 0.25;
                Canvas.SetTop(ball, Canvas.GetTop(ball) - physicSpeed);
                if (physicSpeed <= 0) ballDown = true;
                
                
            }
        }
    }
}
