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
    /// Interaction logic for PlayerNameWindow.xaml
    /// </summary>
    public partial class PlayerNameWindow : Window
    {
        public PlayerNameWindow()
        {
            InitializeComponent();
        }

        private void EnableSeconPlayer (object sender, EventArgs e)
        {
            player2TextBox.IsEnabled = (bool)TwoPlayerGame.IsChecked;
            player2Label.IsEnabled = (bool)TwoPlayerGame.IsChecked;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(player1TextBox.Text) && (!string.IsNullOrWhiteSpace(player2TextBox.Text) || !(bool)TwoPlayerGame.IsChecked))
            {
                if ((bool)TwoPlayerGame.IsChecked)
                {
                    ShipPlacingWindow shipPlacingWindow = new ShipPlacingWindow(new TurnManager(new Player(player1TextBox.Text), new Player(player2TextBox.Text)));

                    shipPlacingWindow.Show();

                    this.Close();
                }
                else
                {
                    ShipPlacingWindow shipPlacingWindow = new ShipPlacingWindow(new AITurnManager(new Player(player1TextBox.Text)));

                    shipPlacingWindow.Show();

                    this.Close();
                }

            }
        }
    }
}
