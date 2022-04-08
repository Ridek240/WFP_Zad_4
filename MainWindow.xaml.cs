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

namespace WFP_Zad_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        Rectangle child;
        double[] LastChildPosition =  new double[2];
        double startX;
        double startY;
        bool isDrawing = false;
        private void StartDrawing(object sender, MouseButtonEventArgs e)
        {
            startX = e.GetPosition(Drawing).X;
            startY = e.GetPosition(Drawing).Y;
            isDrawing = true;
            e.MouseDevice.Capture(Drawing);
            child = new Rectangle();
            Drawing.Children.Add(child);
        }

        private void FinishDrawing(object sender, MouseButtonEventArgs e)
        {
            
            //LastChild = child;
            isDrawing = false;
            e.MouseDevice.Capture(null);
        }

        private void DrawingRect(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                double FinishX = e.GetPosition(Drawing).X;
                double FinishY = e.GetPosition(Drawing).Y;

                double height = FinishY - startY;
                double width = FinishX - startX;


                child.Width = width > 0 ? width : width * -1;
                child.Height = height > 0 ? height : height * -1;
                child.StrokeThickness = 3;
                child.Stroke = Brushes.Red;
 
                LastChildPosition[0] =  width > 0 ? startX : FinishX;
                LastChildPosition[1] = height > 0 ? startY : FinishY;
                Canvas.SetLeft(child, LastChildPosition[0]);
                Canvas.SetTop(child, LastChildPosition[1]);
                
                

            }
        }

        private void Guziczki(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                if (e.Key == Key.Right) child.Width++;
                if (e.Key == Key.Left) { double widht = child.Width; widht--; if (widht > 2) child.Width = widht; else child.Width = 2; };
                if (e.Key == Key.Up) child.Height++;
                if (e.Key == Key.Down) { double height = child.Height; height--; if (height > 2) child.Height = height; else child.Height = 2; }
                
            }
        
            else
            {
                
                if(e.Key==Key.Right)
                {
                    LastChildPosition[0]++;
                    Canvas.SetLeft(child, LastChildPosition[0]);
                }
                if (e.Key == Key.Left)
                {
                    LastChildPosition[0]--;
                    Canvas.SetLeft(child, LastChildPosition[0]);
                }
                if (e.Key == Key.Up)
                {
                    LastChildPosition[1]--;
                    Canvas.SetTop(child, LastChildPosition[1]);
                }
                if (e.Key == Key.Down)
                {
                    LastChildPosition[1]++;
                    Canvas.SetTop(child, LastChildPosition[1]);
                }
            }
        }
    }
}
