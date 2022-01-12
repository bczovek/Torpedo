using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class TurnManager
    {
        public TurnManager(Player player1, Player player2) { 
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            AttackingPlayer = randomNumber == 1 ? player1 : player2;
            DefendingPlayer = randomNumber == 1 ? player2 : player1;
            TurnCount = 1;
        }

        public int TurnCount { get; private set; }
        public Player AttackingPlayer { get; private set; }
        public Player DefendingPlayer { get; private set; }

        private void NextTurn()
        {
            Player temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
            TurnCount++;
        }

        public void Shoot(int x, int y)
        {
            AttackingPlayer.Shoot(x, y, DefendingPlayer.ShipPlacedAtField(x, y));
            DefendingPlayer.TakeShot(x, y);
            NextTurn();
        }
    }
}
