﻿using System;
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
            game g = FindGameByName(gameName);

            if (g == null)
                return null;

            player p = new player(playerName);

            g.Join(p);

            playerRegistration returnMsg = new playerRegistration(true, p.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage Poll(string accessToken)
        {
            pollResponse returnMessage = new pollResponse();

            game associatedGame = FindGameByPlayer(accessToken);

            if (associatedGame == null) return null;

            returnMessage.gameName = associatedGame.GetId();

            List<string> names = associatedGame.GetPlayersNames();

            foreach(var n in names)
                returnMessage.playerStatusLines.Add(new playerStatusLine(n));

            return returnMessage;
        }

        private game FindGameByName( string gameName)
        {
            foreach (var g in gamesList)
            {
                if (g.GetId() == gameName)
                {
                   return g;
                }
            }
            return null;
        }

        private game FindGameByPlayer(string playerAccessToken)
        {
            foreach (var g in gamesList)
            {
                if (g.hasPlayerId(playerAccessToken))
                    return g;
            }
            return null;
        }


        private List<game> gamesList;

    }
}
