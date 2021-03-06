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
using Torpedo.Repositories;

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
            if(_turnManager.players.Count > 1)
            {
                UpdateEnemyTable();
            }
            else
            {
                _turnManager.NextTurn();
            }
            UpdateOwnTable();
        }
        
        public void UpdateOwnTable()
        {
            int enemyPoints = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    if (_turnManager.players[0].ShipPlacedAtField(i, j) && _turnManager.players[0].FieldIsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Red;
                        enemyPoints++;
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
            CurrentPlayer.Content = _turnManager.players[0].Name;
            NumberOfOwnHits.Content = _turnManager.players[0].Points;
            NumberOfEnemyHits.Content = enemyPoints;
            NumberOfTurns.Content = _turnManager.TurnCount;
        }

        public void UpdateEnemyTable()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    if (_turnManager.players[1].ShipPlacedAtField(i, j) && _turnManager.players[1].FieldIsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Red;
                    }
                    else if (_turnManager.players[1].FieldIsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Gray;
                    }
                    else
                    {
                        rectangle.Fill = Brushes.LightBlue;
                    }
                    rectangle.IsHitTestVisible = false;
                    enemyGrid.Children.Add(rectangle);
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

            if (_turnManager.players.Count > 1)
            {
                if (!_turnManager.Shoot(row, col))
                {
                    NextTurnWindow nextTurnWindow = new NextTurnWindow(_turnManager.players[0].Name);
                    nextTurnWindow.Owner = this;
                    playerGrid.Visibility = Visibility.Hidden;
                    enemyGrid.Visibility = Visibility.Hidden;
                    nextTurnWindow.Show();
                }
                else
                {
                    UpdateEnemyTable();
                    UpdateOwnTable();
                }
            }
            else
            {

                Rectangle rectangle = new Rectangle();

                if (_turnManager.Shoot(row, col))
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
                
                UpdateOwnTable();
            }

            if(!string.IsNullOrWhiteSpace(_turnManager.WinnerName()))
            {
                using ResultContext resultContext = new ResultContext();
                {
                    resultContext.Add(new Result()
                    {
                        NumberOfPlayer1Hits = _turnManager.players[0].Points,
                        NumberOfPlayer2Hits = _turnManager.GetDefendingPlayerPoints(),
                        NumberOfTurns = _turnManager.TurnCount,
                        Player1Name = _turnManager.players[0].Name,
                        Player2Name = _turnManager.players.Count > 1 ? _turnManager.players[1].Name : "AI",
                        WinnerName = _turnManager.WinnerName()
                    }
                    );
                }
                resultContext.SaveChanges();
                GameOverWindow gameOverWindow = new GameOverWindow(_turnManager.WinnerName());
                gameOverWindow.Show();
                Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_turnManager.players.Count == 1)
            {
                if (e.Key == Key.F1)
                {
                    AIBattlefieldWindow aIBattlefieldWindow = new AIBattlefieldWindow(_turnManager.GetDefendingPlayerBattlefield());

                    aIBattlefieldWindow.ShowDialog();
                }
            }
        }
    }
}
