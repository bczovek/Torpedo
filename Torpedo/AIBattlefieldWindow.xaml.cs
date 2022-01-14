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
    /// Interaction logic for AIBattlefield.xaml
    /// </summary>
    public partial class AIBattlefieldWindow : Window
    {
        private Battlefield _battlefield;
        public AIBattlefieldWindow(Battlefield battlefield)
        {
            InitializeComponent();
            _battlefield = battlefield;
            DrawAiTable();
        }

        private void DrawAiTable()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    if (_battlefield.IsShip(i, j) && _battlefield.IsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Red;
                    }
                    else if (_battlefield.IsShip(i, j))
                    {
                        rectangle.Fill = Brushes.White;
                    }
                    else if (_battlefield.IsShot(i, j))
                    {
                        rectangle.Fill = Brushes.Gray;
                    }
                    else
                    {
                        rectangle.Fill = Brushes.LightBlue;
                    }
                    rectangle.IsHitTestVisible = false;
                    aiGrid.Children.Add(rectangle);
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                }
            }
        }
    }
}
