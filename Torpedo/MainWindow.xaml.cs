using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Torpedo.Model;

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

            /*TwoPlayerGame Game = new TwoPlayerGame("asd", "asdasd");

            Game.PlaceShip("asd", 1, 1, 1, false);
            Game.PlaceShip("asd", 1, 2, 2, false);
            Game.PlaceShip("asd", 1, 3, 3, false);
            Game.PlaceShip("asd", 1, 4, 4, false);
            Game.PlaceShip("asd", 1, 5, 5, false);

            Game.PlaceShip("asdasd", 1, 1, 1, false);
            Game.PlaceShip("asdasd", 1, 2, 2, false);
            Game.PlaceShip("asdasd", 1, 3, 3, false);
            Game.PlaceShip("asdasd", 1, 4, 4, false);
            Game.PlaceShip("asdasd", 1, 5, 5, false);

            Console.WriteLine(Game.GetCurrentPlayer().Name);
            Game.Shoot(1, 1);

            Game.Shoot(8, 8);*/

            OnePlayerGame Game = new OnePlayerGame("asd");

            Game.PlaceShip(1, 1, 1, false);
            Game.PlaceShip(1, 2, 2, false);
            Game.PlaceShip(1, 3, 3, false);
            Game.PlaceShip(1, 4, 4, false);
            Game.PlaceShip(1, 5, 5, false);

            Game.Proceed();
            Game.Shoot(3, 4);


            Trace.WriteLine("hello");
        }
    }
}
