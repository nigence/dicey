using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class playerStatusLine
    {
        public playerStatusLine
            (string name,
            int livesRemaining,
            bool handClaimMade = false, 
            pokerDiceHand handClaim = null, 
            int? rerolledDiceCount = null)
        {
            mName = name;
            mClaim = null;
            if (handClaimMade)
                mClaim = handClaim;
            rerollDiceCount = rerolledDiceCount;
            mLivesRemaining = livesRemaining;
        }

        public string GetName()
        {
            return mName;
        }

        public pokerDiceHand getClaim()
        {
            return mClaim;
        }

        public int? GetRerollDiceCount()
        {
            return rerollDiceCount;
        }

        public int GetLivesRemaining()
        {
            return mLivesRemaining;
        }

        private string mName;
        private pokerDiceHand mClaim;
        private int? rerollDiceCount;
        private int mLivesRemaining;
    }
}
