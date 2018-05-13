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
            bool handClaimMade = false, 
            pokerDiceHand handClaim = null, 
            int? rerolledDiceCount = null)
        {
            mName = name;
            mClaim = null;
            if (handClaimMade)
                mClaim = handClaim;
            rerollDiceCount = rerolledDiceCount;
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

        private string mName;
        private pokerDiceHand mClaim;
        private int? rerollDiceCount; 
    }
}
