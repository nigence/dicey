using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class game
    {
        public game(player administrator, pokerDieRoller dieRoller)
        {
            string id = "game-identifier-" + nextIdentifierNumber.ToString();
            identifier = id;
            nextIdentifierNumber++;
            playersList = new List<player>(); 
            playersList.Add(administrator);
            mAdministrator = administrator;
            status = gameStatus.playersJoining;
            reroller = new pokerDiceHandReroller(dieRoller);
            currentActualHand = reroller.GetNewHand();
        }

        public string GetId()
        {
            return identifier;
        }

        public gameStatus GetStatus()
        {
            return status;
        }

        public void Join(player newJoiner)
        {
            if (status == gameStatus.playersJoining)
                playersList.Add(newJoiner);
        }

        public void CloseToNewJoiners()
        {
            status = gameStatus.administratorShufflingPlayers;
        }

        public bool isOpenToNewPlayers()
        {
            return (status == gameStatus.playersJoining) ;
        }

        public void Start()
        {
            status = gameStatus.awaitingPlayerToClaimHandRank;
            playerToActIndex = 0;
        }

        public bool hasPlayerId(string Id)
        {
            foreach(var p in playersList)
            {
                if (p.GetId() == Id)
                    return true;
            }
            return false;
        }

        public bool hasPlayerNamed(string playerName)
        {
            foreach (var p in playersList)
            {
                if (p.GetName() == playerName)
                    return true;
            }
            return false;
        }

        public player GetPlayerByName(string name)
        {
            foreach (var p in playersList)
            {
                if (p.GetName() == name)
                    return p;
            }
            return null;
        }

        public player GetPlayerById(string playerAccessToken)
        {
            foreach (var p in playersList)
            {
                if (p.GetId() == playerAccessToken)
                    return p;
            }
            return null;
        }

        public string GetPlayerNameWithActionAwaited()
        {
            player p = playersList[playerToActIndex];
            return p.GetName();
        }


        public bool hasAdministrator(string playerAccessToken)
        {
            return (mAdministrator.GetId() == playerAccessToken);
        }

        public List<string> GetPlayersNames()
        {
            List<string> names = new List<string>();
            foreach( var p in playersList )
                names.Add(p.GetName());
            return names;
        }

        public bool SetRunningOrder( List<string> playersNames )
        {
            if (playersList.Count != playersNames.Count)
                return false;

            foreach(var n in playersNames)
            {
                if (!this.hasPlayerNamed(n))
                    return false;
            }

            int runningOrderNumber = 0;
            foreach(var n in playersNames)
            {
                var p = this.GetPlayerByName(n);
                p.SetRunningOrder(runningOrderNumber);
                runningOrderNumber++;
            }
            playersList.Sort();
            return true;
        }

        public pokerDiceHand GetActualHand()
        {
            return currentActualHand;
        }

        public void DeclareHand(string playerId, pokerDiceHand hand)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) ||
                (this.status != gameStatus.awaitingPlayerToClaimHandRank)) return;
            p.SetHandClaim(hand);
            MoveTurnToNextPlayer();
            status = gameStatus.awaitingPlayerDecisionAcceptOrCallLiar;
        }

        public void AcceptHand(string playerId)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) ||
                (this.status != gameStatus.awaitingPlayerDecisionAcceptOrCallLiar)) return;
            status = gameStatus.awaitingPlayerToChooseDiceToReRollOrNone;
        }

        public void ReRoll(string playerId, string facesToReRoll)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) || 
                (this.status != gameStatus.awaitingPlayerToChooseDiceToReRollOrNone)) return;
            status = gameStatus.awaitingPlayerToClaimHandRank;
            p.SetRerollCount(facesToReRoll.Length);
        }

        private bool ConfirmPlayerIsWithActionAwaited(string playerId, ref player p)
        {
            p = GetPlayerById(playerId);
            string pName = p.GetName();
            string xName = this.GetPlayerNameWithActionAwaited();
            return (pName == xName);
        }

        private void MoveTurnToNextPlayer()
        {
            playerToActIndex++;
            if (playerToActIndex == playersList.Count())
                playerToActIndex = 0;
        }

        private static int nextIdentifierNumber = 1;
        private string identifier;
        private gameStatus status;
        private List<player> playersList; //includes administrator
        private player mAdministrator;
        private int playerToActIndex;
        private pokerDiceHand currentActualHand;
        private pokerDiceHandReroller reroller;
    }
}
