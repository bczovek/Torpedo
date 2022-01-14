using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class Result
    {
        public long Id { get; set; }

        public string Player1Name { get; set; }

        public string Player2Name { get; set; }

        public int NumberOfTurns { get; set; }

        public int NumberOfPlayer1Hits { get; set; }

        public int NumberOfPlayer2Hits { get; set; }

        public string WinnerName { get; set; }
    }
}
