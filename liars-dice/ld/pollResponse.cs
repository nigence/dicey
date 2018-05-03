using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class pollResponse : gameEngineReturnMessage
    {
        public pollResponse()
        {
            handIsViewableSet = false;
        }

        public string gameName { get;  set; }

        public gameStatus status { get; set; }

        public string awaitingActionFromPlayerName { get; set; }

        public pokerDiceHand GetNamedPlayersHand()
        {
            return hand;
        }

        public void SetHandToView(pokerDiceHand h)
        {
            hand = h;
            handIsViewableSet = true;
        }

        public List<playerStatusLine> playerStatusLines = new List<playerStatusLine>();

        public bool HasHandToView()
        {
            return handIsViewableSet;
        }

        private bool handIsViewableSet;
        private pokerDiceHand hand;
    }
}
