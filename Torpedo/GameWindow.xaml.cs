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

        private ITurnManager _turnManager;

        public GameWindow(ITurnManager turnManager)
        {
            InitializeComponent();
            _turnManager = turnManager;
            UpdateOwnTable();

        }
        
        public void UpdateOwnTable()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    if (_turnManager.players[0].ShipPlacedAtField(i, j) && _turnManager.players[0].FieldIsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Red;
                    }
                    else if (_turnManager.players[0].ShipPlacedAtField(i, j))
                    {
                        rectangle.Fill = Brushes.White;
                    }
                    else if (_turnManager.players[0].FieldIsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Gray;
                    }
                    else
                    {
                        rectangle.Fill = Brushes.LightBlue;
                    }
                    rectangle.IsHitTestVisible = false;
                    playerGrid.Children.Add(rectangle);
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                }
            }
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

            if(_turnManager.Shoot(row, col))
            {
                rectangle.Fill = Brushes.Red;
            }
            else
            {
                rectangle.Fill = Brushes.Gray;
            }
            rectangle.IsHitTestVisible = false;
            enemyGrid.Children.Add(rectangle);
            Grid.SetRow(rectangle, row);
            Grid.SetColumn(rectangle, col);

            if (_turnManager.players.Count > 1)
            {
                NextTurnWindow nextTurnWindow = new NextTurnWindow(_turnManager.players[0].Name);
                nextTurnWindow.Owner = this;
                playerGrid.Visibility = Visibility.Hidden;
                nextTurnWindow.Show();
            }
            else
            {
                UpdateOwnTable();
            }
        }
    }
}
