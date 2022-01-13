using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Torpedo.Model;

namespace Torpedo
{
    /// <summary>
    /// Interaction logic for ShipPlacingWindow.xaml
    /// </summary>
    public partial class ShipPlacingWindow : Window
    {
        private ITurnManager _turnManager;

        private List<Player> _players;
        private Player _currentPlayer;
        private int shipNumber = 1;
        private const int MaxShipNumber = 5;
        private int playerCount = 1;
        public ShipPlacingWindow(ITurnManager turnManager)
        {
            InitializeComponent();
            _turnManager = turnManager;

            _players = turnManager.players;
            _currentPlayer = _players[0];
            updateLabel();
        }
        
        private void updateLabel()
        {
            playerLabel.Content = $"{_currentPlayer.Name} playing ship {shipNumber}";
        }

        private void playerGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(playerGrid);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var rowDefinition in playerGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in playerGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            if (_currentPlayer.PlaceShip(row, col, shipNumber, !(bool)Horizontal.IsChecked))
            {
                for (int i = 0; i < shipNumber; i++)
                {
                    int nextCol = col;
                    int nextRow = row;
                    if ((bool)Horizontal.IsChecked)
                    {
                        nextCol = col + i;
                    }
                    else
                    {
                        nextRow = row + i;
                    }
                    Rectangle rectangle = new Rectangle();

                    rectangle.Fill = Brushes.Black;
                    rectangle.IsHitTestVisible = false;
                    playerGrid.Children.Add(rectangle);
                    Grid.SetRow(rectangle, nextRow);
                    Grid.SetColumn(rectangle, nextCol);
                }
                shipNumber++;
            }

            if(shipNumber > MaxShipNumber)
            {
                DoneButton.IsEnabled = true;
                playerGrid.IsEnabled = false;
            }
            else
            { 
                updateLabel();
            }
        }

        private void OnReset(object sender, RoutedEventArgs e)
        {
            DoneButton.IsEnabled = false;
            playerGrid.Children.Clear();
            _currentPlayer.ClearShips();
            shipNumber = 1;
            updateLabel();
            playerGrid.IsEnabled = true;
        }

        private void OnDone(object sender, RoutedEventArgs e)
        {
            if (_players.Count > playerCount)
            {
                _currentPlayer = _players[playerCount];
                playerCount++;
                shipNumber = 1;
                playerGrid.Children.Clear();
                updateLabel();
                DoneButton.IsEnabled = false;
                playerGrid.IsEnabled = true;
            }
            else
            {
                GameWindow gameWindow = new GameWindow(_turnManager);
                gameWindow.Show();

                this.Close();
            }
        }
    }
}
