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

namespace Torpedo
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

        private void Play(object sender, RoutedEventArgs e)
        {
            PlayerNameWindow playerNameWindow = new PlayerNameWindow();

            playerNameWindow.Show();

            this.Close();
        }

        private void Scoreboard(object sender, RoutedEventArgs e)
        {
            ScoreboardWindow scoreboardWindow = new ScoreboardWindow();

            scoreboardWindow.Show();

            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
