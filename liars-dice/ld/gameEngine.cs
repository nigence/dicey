using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class gameEngine
    {
        public  gameEngine(pokerDieRoller roller)
        {
            gamesList = new List<game>();
            mRoller = roller;
        }

        public gameEngineReturnMessage CreateNewGame(string adminsName)
        {
            player administrator = new player(adminsName);
            game newGame = new game(administrator, mRoller);
            gamesList.Add(newGame);

            newGameDetails returnMsg = new newGameDetails(true, administrator.GetId(), newGame.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage JoinGame(string gameName, string playerName)
        {
            game g = FindGameByName(gameName);

            if (g == null || !g.isOpenToNewPlayers())
                return new playerRegistration(false, "");

            player p = new player(playerName);
            g.Join(p);

            playerRegistration returnMsg = new playerRegistration(true, p.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage CloseForNewJoiners(string accessToken)
        {
            boolResponse returnMsg = new boolResponse();
            returnMsg.okay = false;

            var g = FindGameByPlayer(accessToken);
            if (g == null) return returnMsg;
            if (!g.hasAdministrator(accessToken)) return returnMsg;
            g.CloseToNewJoiners();
            returnMsg.okay = true;
            return returnMsg;
        }

        public gameEngineReturnMessage SetPlayersRunningOrder(string accessToken, List<string> playersNames)
        {
            boolResponse returnMsg = new boolResponse();
            returnMsg.okay = false;
            var g = FindAdministratorsGame(accessToken);
            if (g == null) return returnMsg;
            returnMsg.okay = g.SetRunningOrder(playersNames);
            return returnMsg;
        }

        public gameEngineReturnMessage StartGame(string accessToken)
        {
            boolResponse returnMsg = new boolResponse();
            var g = FindAdministratorsGame(accessToken);
            returnMsg.okay = (g != null);
            if (g != null)
                g.Start();
            return returnMsg;
        }

        public gameEngineReturnMessage Poll(string accessToken)
        {
            pollResponse returnMessage = new pollResponse();

            game associatedGame = FindGameByPlayer(accessToken);

            if (associatedGame == null) return null;

            returnMessage.gameName = associatedGame.GetId();
            returnMessage.status = associatedGame.GetStatus();

            List<string> names = associatedGame.GetPlayersNames();

            foreach (var n in names)
            {
                int? rerollCount = associatedGame.GetPlayerByName(n).GetRerollCount();
                pokerDiceHand handClaim = associatedGame.GetPlayerByName(n).GetHandClaim();
                bool handClaimMade = handClaim != null;
                returnMessage.playerStatusLines.Add(new playerStatusLine(n, handClaimMade, handClaim, rerollCount));
            }


            returnMessage.awaitingActionFromPlayerName = associatedGame.GetPlayerNameWithActionAwaited();

            //Decide whether or not to reveal actual hand to the calling player
            if ((associatedGame.GetPlayerById(accessToken).GetName() == associatedGame.GetPlayerNameWithActionAwaited())
                && 
                ((associatedGame.GetStatus() == gameStatus.awaitingPlayerToClaimHandRank)
                ||  (associatedGame.GetStatus() == gameStatus.awaitingPlayerToChooseDiceToReRollOrNone))
                )
            {
                returnMessage.SetHandToView(associatedGame.GetActualHand());
            }
            return returnMessage;
        }

        public void DeclareHand(string accessToken, pokerDiceHand hand)
        {
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
                return;
            associatedGame.DeclareHand(accessToken, hand);
        }

        public void AcceptHand(string accessToken)
        {
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
                return;
            associatedGame.AcceptHand(accessToken);
        }

        public void ReRoll(string accessToken, string facesToReRoll)
        {
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
                return;
            associatedGame.ReRoll(accessToken, facesToReRoll);
        }

        public void CallLiar(string accessToken)
        {
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
                return;
            associatedGame.CallLiar(accessToken);
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

        private game FindAdministratorsGame(string accessToken)
        {
            var g = FindGameByPlayer(accessToken);
            if (g == null) return null;
            if (!g.hasAdministrator(accessToken)) return null;
            return g;
        }

        private List<game> gamesList;
        private pokerDieRoller mRoller;

    }
}
