using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class game
    {
        public game(player administrator, pokerDieRoller dieRoller, int initialLivesCount)
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
            mInitialLivesCount = initialLivesCount;
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
            return (status == gameStatus.playersJoining);
        }

        public void Start()
        {
            status = gameStatus.awaitingPlayerToClaimHandRank;
            playerToActIndex = 0;
        }

        public bool hasPlayerId(string Id)
        {
            foreach (var p in playersList)
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
            foreach (var p in playersList)
                names.Add(p.GetName());
            return names;
        }

        public bool SetRunningOrder(List<string> playersNames)
        {
            if (playersList.Count != playersNames.Count)
                return false;

            foreach (var n in playersNames)
            {
                if (!this.hasPlayerNamed(n))
                    return false;
            }

            int runningOrderNumber = 0;
            foreach (var n in playersNames)
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

        public bool DeclareHand(string playerId, pokerDiceHand hand)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) ||
                (this.status != gameStatus.awaitingPlayerToClaimHandRank)) return false;
            p.SetHandClaim(hand);
            MoveTurnToNextPlayer();
            status = gameStatus.awaitingPlayerDecisionAcceptOrCallLiar;
            return true;
        }

        public bool AcceptHand(string playerId)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) ||
                (this.status != gameStatus.awaitingPlayerDecisionAcceptOrCallLiar)) return false;

            if (StalemateDetected())
                status = gameStatus.awaitingPlayerToClaimHandRank;
            else
                status = gameStatus.awaitingPlayerToChooseDiceToReRollOrNone;

            return true;
        }

        public void ReRoll(string playerId, string facesToReRoll)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(playerId, ref p)) ||
                (this.status != gameStatus.awaitingPlayerToChooseDiceToReRollOrNone)) return;
            status = gameStatus.awaitingPlayerToClaimHandRank;
            p.SetRerollCount(facesToReRoll.Length);

            pokerDiceHand newHand = reroller.Reroll(currentActualHand, facesToReRoll);
            currentActualHand = newHand;
        }

        public void CallLiar(string accessToken)
        {
            player p = null;
            if ((!ConfirmPlayerIsWithActionAwaited(accessToken, ref p)) ||
                (this.status != gameStatus.awaitingPlayerDecisionAcceptOrCallLiar)) return;

            if (GetPreviousPlayerHandClaim() > currentActualHand)
                ActionPreviousPlayerIsLiar();
            else
                ActionIncorrectLiarCall();




        }

        public int GetInitialLivesCount()
        {
            return mInitialLivesCount;
        }

        private pokerDiceHand GetPreviousPlayerHandClaim()
        {
            int previousPlayerIndex = GetIndexOfPlayerPreviousTo(playerToActIndex);
            player previousPlayer = playersList[previousPlayerIndex];
            pokerDiceHand pdh = previousPlayer.GetHandClaim();
            return pdh;
        }

        private bool hasWinner()
        {
            return (this.GetWinnersName() != null);
        }

        private string GetWinnersName()
        {
            int remainingPlayersCount = 0;
            player pwithlife = null; ;
            foreach (var p in playersList)
            {
                if (p.GetLivesRemaining() > 0)
                {
                    remainingPlayersCount++;
                    pwithlife = p;
                }
            }
            if (remainingPlayersCount == 1)
            {
                return pwithlife.GetName();
            }
            return null;
        }

        private void ActionPreviousPlayerIsLiar()
        {
            player previousPlayer = playersList[GetIndexOfPlayerPreviousTo(playerToActIndex)];
            previousPlayer.DeductLife();
            if (hasWinner())
            {
                SetPlayerToActIndex(GetWinnersName());
                status = gameStatus.endedWithWinner;
            }
            else
            {
                RewindTurnToPreviousPlayer();
                currentActualHand = reroller.GetNewHand();
                status = gameStatus.awaitingPlayerToClaimHandRank;
            }
        }

        private void ActionIncorrectLiarCall()
        {
            player currentPlayer = playersList[playerToActIndex];
            currentPlayer.DeductLife();
            if (hasWinner())
            {
                SetPlayerToActIndex(GetWinnersName());
                status = gameStatus.endedWithWinner;
            }
            else
            {
                this.status = gameStatus.awaitingPlayerToClaimHandRank;
                currentActualHand = reroller.GetNewHand();
                status = gameStatus.awaitingPlayerToClaimHandRank;
            }


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
            playerToActIndex = GetIndexOfSubsequentPlayer(playerToActIndex);
        }

        private int GetIndexOfSubsequentPlayer(int playerIndex, bool ignoreLivesCounts = false)
        {
            if (ignoreLivesCounts)
            {
                int nextIndex = playerIndex + 1;
                if (nextIndex == playersList.Count()) return 0;
                return nextIndex;
            }
            else
            {
                int i = playerIndex;
                for (; ; )
                {
                    i = GetIndexOfSubsequentPlayer(i, true);
                    player p = playersList[i];
                    int livesCount = p.GetLivesRemaining();
                    if (livesCount > 0) return i;
                }
            }
        }


        private int GetIndexOfPlayerPreviousTo(int playerIndex, bool ignoreLivesCounts = false)
        {
            if (ignoreLivesCounts)
            {
                if (playerIndex > 0) return playerIndex - 1;
                return playersList.Count() - 1;
            }
            else
            {
                int i = playerIndex;
                for (; ; )
                {
                    i = GetIndexOfPlayerPreviousTo(i, true);
                    player p = playersList[i];
                    int livesCount = p.GetLivesRemaining();
                    if (livesCount > 0) return i;
                }
            }
        }

        private void RewindTurnToPreviousPlayer()
        {
            playerToActIndex = GetIndexOfPlayerPreviousTo(playerToActIndex);
        }

        private void SetPlayerToActIndex(string playerName)
        {
            player p = null;
            for (int i = 0; i < playersList.Count; i++)
            {
                p = playersList[i];
                if (p.GetName() == playerName)
                {
                    playerToActIndex = i;
                    return;
                }
            }
        }

        private bool StalemateDetected() //Use only within accept hand function
        {
            pokerDiceHand AAAAA = new pokerDiceHand("AAAAA");
            if (AAAAA == GetPreviousPlayerHandClaim())
                return true;

            return false;
        }

        private static int nextIdentifierNumber = 1;
        private string identifier;
        private gameStatus status;
        private List<player> playersList; //includes administrator
        private player mAdministrator;
        private int playerToActIndex;
        private pokerDiceHand currentActualHand;
        private pokerDiceHandReroller reroller;
        private int mInitialLivesCount;
    }
}
