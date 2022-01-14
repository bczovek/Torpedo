using System;
using System.Collections.Generic;

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
            TurnCount = 1;
        }

        public int GetDefendingPlayerPoints()
        {
            return Ai.Points;
        }

        public Player Player { get; private set; }
        public AIPlayer Ai { get; private set; }

        public List<Player> players => new List<Player> {Player};

        public int TurnCount { get; set; }

        public void NextTurn()
        {
            while (_isAITurn)
            {
                Field shot = Ai.Shoot();
                Ai.Update(shot, Player.ShipPlacedAtField(shot.X, shot.Y));
                Player.TakeShot(shot.X, shot.Y);
                if (!Player.ShipPlacedAtField(shot.X, shot.Y))
                {
                    _isAITurn = false;
                }
            }
            TurnCount++;
        }

        public string WinnerName()
        {
            if(Player.IsGameOver())
            {
                return "AI";
            }
            else if(Ai.IsGameOver())
            {
                return Player.Name;
            }

            return "";
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
            }
            if (!isHit)
            {
                _isAITurn = true;
                NextTurn();
            }

            return isHit && Ai.ShipPlacedAtField(x, y);
        }

        public Battlefield GetDefendingPlayerBattlefield()
        {
            return Ai.Battlefield;
        }
    }
}
