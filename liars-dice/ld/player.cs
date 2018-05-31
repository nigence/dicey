using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class player :  IComparable<player>
    {
        public player(string playerName, int initialLives)
        {
            name = playerName;
            string accessToken = "access-token-" + nextAccessTokenNumber.ToString();
            identifier = accessToken;
            nextAccessTokenNumber++;
            claim = null;
            lifeCount = initialLives;
        }

        public string GetId()
        {
            return identifier;
        }

        public string GetName()
        {
            return name;
        }

        public void SetRunningOrder(int order)
        {
            runningOrder = order;
        }

        public int CompareTo(player that)
        {
            if (this.runningOrder > that.runningOrder) return 1;
            if (this.runningOrder < that.runningOrder) return -1;
            return 0;
        }

        public void SetHandClaim(pokerDiceHand hand)
        {
            claim = hand;
        }

        public pokerDiceHand GetHandClaim()
        {
            return claim;
        }

        public void SetRerollCount(int? count)
        {
            rerollCount = count;
        }

        public int? GetRerollCount()
        {
            return rerollCount;
        }

        public void DeductLife()
        {
            lifeCount--;
        }

        public int GetLivesRemaining()
        {
            return lifeCount;
        }

        private static int nextAccessTokenNumber = 1;
        private string identifier;
        private string name;
        private int runningOrder;
        private pokerDiceHand claim;
        private int? rerollCount;
        private int lifeCount;
    }
}
