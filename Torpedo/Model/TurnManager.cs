using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class TurnManager : ITurnManager
    {
        public TurnManager(Player player1, Player player2) { 
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            AttackingPlayer = randomNumber == 1 ? player1 : player2;
            DefendingPlayer = randomNumber == 1 ? player2 : player1;
            TurnCount = 1;
        }

        public Player AttackingPlayer { get; private set; }
        public Player DefendingPlayer { get; private set; }

        public List<Player> players => new List<Player> { AttackingPlayer, DefendingPlayer};

        public int TurnCount { get; set; }

        public void NextTurn()
        {
            Player temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
            TurnCount++;
        }

        public string WinnerName()
        {
            if(players[0].IsGameOver())
            {
                return players[1].Name;
            }
            else if (players[1].IsGameOver())
            {
                return players[0].Name;
            }

            return "";
        }
        public bool PlaceShip(string playerName, int x, int y, int size, bool isHorizontal)
        {
            if(playerName == AttackingPlayer.Name)
            {
                return AttackingPlayer.PlaceShip(x, y, size, isHorizontal);
            }
            else if (playerName == DefendingPlayer.Name)
            {
                return DefendingPlayer.PlaceShip(x, y, size, isHorizontal);
            }

            return false;
        }

        public bool Shoot(int x, int y)
        {
            bool isHit = AttackingPlayer.Shoot(x, y, DefendingPlayer.ShipPlacedAtField(x, y));
            DefendingPlayer.TakeShot(x, y);
            if (!isHit)
            {
                NextTurn();
            }

            return isHit;
        }

    }
}
