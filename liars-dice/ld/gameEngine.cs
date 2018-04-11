using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class gameEngine
    {
        public  gameEngine()
        {

        }

        public gameEngineReturnMessage StartNewGame()
        {
            string accessToken = "access-token-" + nextAccessTokenNumber.ToString();
            nextAccessTokenNumber++;
            string id = "game-identifier-" + nextIdentifierNumber.ToString();
            nextIdentifierNumber++;

            newGameDetails returnMsg = new newGameDetails(true, accessToken, id);
            return returnMsg;
        }

        public gameEngineReturnMessage JoinGame(string gameName, string playerName)
        {
            string accessToken = "access-token-" + nextAccessTokenNumber.ToString();
            nextAccessTokenNumber++;

            playerRegistration returnMsg = new playerRegistration(true, accessToken);
            return returnMsg;
        }

        public gameEngineReturnMessage Poll(string accessToken)
        {
            pollResponse returnMessage = new pollResponse();
            return returnMessage;
        }

        private static int nextAccessTokenNumber = 1;
        private static int nextIdentifierNumber = 1;

    }
}
