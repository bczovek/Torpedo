using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Torpedo.Model
{
    public class AITurnManager : ITurnManager
    {
        private bool _isAITurn;
        public AITurnManager(Player player)
        {
            Player = player;
            Ai = new AIPlayer();
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            _isAITurn = randomNumber == 1;
            Ai.PlaceShips();
        }
        public int TurnCount { get; private set; }
        public Player Player { get; private set; }
        public AIPlayer Ai { get; private set; }

        public List<Player> players => new List<Player> {Player};

        public void NextTurn() 
        { 
            if(_isAITurn)
            {
                Field shot = Ai.Shoot();          
                Ai.Update(shot, Player.ShipPlacedAtField(shot.X, shot.Y));
                Player.TakeShot(shot.X, shot.Y);
                Trace.WriteLine($"{shot.Y}, {shot.X}");
                _isAITurn = false;
            }
        }

        public bool PlaceShip(string playerName, int x, int y, int size, bool isHorizontal)
        {
            if(playerName == Player.Name)
            {
                return Player.PlaceShip(x, y, size, isHorizontal);
            }

            return false;
        }

        public bool Shoot(int x, int y)
        {
            bool isHit = false;
            if (!_isAITurn)
            {
                isHit = Player.Shoot(x, y, Ai.ShipPlacedAtField(x, y));
                Ai.TakeShot(x, y);
                _isAITurn = true;
            }
            NextTurn();

            return isHit;
        }
    }
}
