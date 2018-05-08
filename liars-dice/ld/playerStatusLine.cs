using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class playerStatusLine
    {
        public playerStatusLine(string name, bool handClaimMade = false, pokerDiceHand handClaim = null)
        {
            mName = name;
            mClaim = null;
            if (handClaimMade)
                mClaim = handClaim;
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
            return null;
        }

        string mName;
        pokerDiceHand mClaim;
    }
}
