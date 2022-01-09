using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class Players
    {
        public Players(IPlayer player1, IPlayer player2) { 
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            AttackingPlayer = randomNumber == 1 ? player1 : player2;
            DefendingPlayer = randomNumber == 1 ? player2 : player1;
            TurnCount = 1;
        }

        public int TurnCount { get; private set; }
        public IPlayer AttackingPlayer { get; private set; }
        public IPlayer DefendingPlayer { get; private set; }

        public void NextTurn()
        {
            IPlayer temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
            TurnCount++;
        }

        public void Shoot(int x, int y)
        {
            AttackingPlayer.Shoot(x, y, DefendingPlayer.ShipPlacedAtField(x, y));
            DefendingPlayer.TakeShot(x, y);
        }
    }
}
