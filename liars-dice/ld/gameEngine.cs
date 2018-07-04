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

        public gameEngineReturnMessage CreateNewGame(string adminsName, int initialLives)
        {
            player administrator = new player(adminsName, initialLives);
            game newGame = new game(administrator, mRoller, initialLives);
            gamesList.Add(newGame);

            newGameDetails returnMsg = new newGameDetails(administrator.GetId(), newGame.GetId());
            return returnMsg;
        }

        public gameEngineReturnMessage JoinGame(string gameName, string playerName)
        {
            game g = FindGameByName(gameName);

            if (g == null || !g.isOpenToNewPlayers())
                return new playerRegistration(false, "");

            player p = new player(playerName, g.GetInitialLivesCount());
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
                int livesLeft = associatedGame.GetPlayerByName(n).GetLivesRemaining();
                returnMessage.playerStatusLines.Add(new playerStatusLine(n, livesLeft, handClaimMade ,handClaim, rerollCount));
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

        public gameEngineReturnMessage DeclareHand(string accessToken, pokerDiceHand hand)
        {
            game associatedGame = FindGameByPlayer(accessToken);
            boolResponse returnMsg = new boolResponse();

            if (associatedGame == null)
            {
                returnMsg.okay = false;
                return returnMsg;
            }

            bool declareAccepted = associatedGame.DeclareHand(accessToken, hand);
            if (declareAccepted)
                returnMsg.okay = true;
            else
                returnMsg.okay = false;

            return returnMsg;
        }

        public gameEngineReturnMessage AcceptHand(string accessToken)
        {
            boolResponse returnMsg = new boolResponse();
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
            {
                returnMsg.okay = false;
                return returnMsg;
            }

            bool acceptedOk = associatedGame.AcceptHand(accessToken);
            returnMsg.okay = acceptedOk;
            return returnMsg;
        }

        public gameEngineReturnMessage ReRoll(string accessToken, string facesToReRoll)
        {
            boolResponse returnMsg = new boolResponse();
            game associatedGame = FindGameByPlayer(accessToken);
            if (associatedGame == null)
            {
                returnMsg.okay = false;
                return returnMsg;
            }
            returnMsg.okay = associatedGame.ReRoll(accessToken, facesToReRoll);
            return returnMsg;
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
