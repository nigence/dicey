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
            gamesList = new List<game>();
        }

        public gameEngineReturnMessage StartNewGame(string adminsName)
        {
            player administrator = new player(adminsName);
            game newGame = new game(administrator);
            gamesList.Add(newGame);


            newGameDetails returnMsg = new newGameDetails(true, administrator.GetId(), newGame.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage JoinGame(string gameName, string playerName)
        {
            player p = new player(playerName);

            foreach( var g in gamesList )
            {
                if( g.GetId() == gameName)
                {
                    g.Join(p);
                    break;
                }
            }

            playerRegistration returnMsg = new playerRegistration(true, p.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage Poll(string accessToken)
        {
            pollResponse returnMessage = new pollResponse();

            //Find the player
            foreach(var g in gamesList)
            {
                if(g.hasPlayerId(accessToken))
                {
                    returnMessage.gameName = g.GetId();
                    break;
                }
            }
            return returnMessage;
        }

        List<game> gamesList;

    }
}
