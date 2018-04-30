using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class pollResponse : gameEngineReturnMessage
    {
        public string gameName { get;  set; }

        public gameStatus status { get; set; }

        public string awaitingActionFromPlayerName { get; set; }

        public pokerDiceHand namedPlayersHand { get; set; }

        public List<playerStatusLine> playerStatusLines = new List<playerStatusLine>();
    }
}
