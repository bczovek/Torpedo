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
    /// Interaction logic for NextTurnWindow.xaml
    /// </summary>
    public partial class NextTurnWindow : Window
    {
        public NextTurnWindow(string NextPlayerName)
        {
            InitializeComponent();
            NextPlayer.Content = NextPlayerName + "'s Turn";
        }

        private void OkButtonClicked (object sender, RoutedEventArgs e)
        {
            ((GameWindow)this.Owner).UpdateOwnTable();
            ((GameWindow)this.Owner).playerGrid.Visibility = Visibility.Visible;
            ((GameWindow)this.Owner).UpdateEnemyTable();
            ((GameWindow)this.Owner).enemyGrid.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
