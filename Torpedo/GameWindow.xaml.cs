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
using Torpedo.Model;

namespace Torpedo
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow(ITurnManager turnManager)
        {
            InitializeComponent();
        }

        private void ShootOnGridClick(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(enemyGrid);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var rowDefinition in enemyGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in enemyGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            Rectangle rectangle = new Rectangle();

            rectangle.Fill = Brushes.Gray;
            rectangle.IsHitTestVisible = false;
            enemyGrid.Children.Add(rectangle);
            Grid.SetRow(rectangle, row);
            Grid.SetColumn(rectangle, col);

        }
    }
}
