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

namespace WpfApplicationPingPong
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double vx = 210.0;
        double vy = 220.0;
        int spieler1;
        int spieler2;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += ticker;
            timer.IsEnabled = true;
        }

        private void ticker(object sender, EventArgs e)
        {
            Double x = Canvas.GetLeft(ball);
            Double y = Canvas.GetTop(ball);
            
            
            x += vx * timer.Interval.TotalSeconds;
            y += vy * timer.Interval.TotalSeconds;

            Canvas.SetLeft(ball, x);
            Canvas.SetRight(ball, y);
            if(x <=0.0)
            {
                spieler2++;
                MessageBox.Show("" + spieler1 + ":" + "" + spieler2);
                vx = -vx;
            }
            if(x >= myCanvas.ActualWidth - ball.Width)
            {
                spieler1++;
                MessageBox.Show("" + spieler1 + ":" + "" + spieler2);
                vx = -vx;
            }
            if(x <= 0.0+ leftPaddle.Width || x >= myCanvas.ActualWidth - ball.Width - leftPaddle.Width)
            {
                if(y < Canvas.GetTop(leftPaddle)+leftPaddle.Height && y >= Canvas.GetTop(leftPaddle))
                {
                    vx = -vx * 1;
                   
                }
                else
                {
                   
                }
            }
           
            
            if (y <= 0.0 || y >= myCanvas.ActualHeight - ball.Height)
            {
                vy = -vy;
            }
            Canvas.SetTop(ball, y);
           
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            Canvas.SetTop(leftPaddle, p.Y);
            Canvas.SetTop(rightPaddle, p.Y);
            
        }
    }
}
