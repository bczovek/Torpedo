using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Torpedo.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        public GameWindow()
        {
            InitializeComponent();
            InitTables();
        }

        private void InitTables()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var shape = new Rectangle();
                    shape.Fill = Brushes.Black;
                    var unitY = 50;
                    var unitX = 50;
                    shape.Width = unitY;
                    shape.Height = unitX;
                    Canvas.SetTop(shape, unitY * i + (i + 1) * 5);
                    Canvas.SetLeft(shape, unitX * j + (j + 1) * 5);
                    canvas.Children.Add(shape);
                }
                for (int j = 0; j < 10; j++)
                {
                    var shape = new Rectangle();
                    shape.Fill = Brushes.Black;
                    var unitY = 50;
                    var unitX = 50;
                    shape.Width = unitY;
                    shape.Height = unitX;
                    Canvas.SetTop(shape, unitY * i + (i + 1) * 5);
                    Canvas.SetLeft(shape, unitX * j + (j + 1) * 5);
                    canvas2.Children.Add(shape);
                }
            }
        }

    }
}
