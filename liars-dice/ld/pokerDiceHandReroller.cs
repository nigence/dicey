using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class pokerDiceHandReroller
    {
        public pokerDiceHandReroller(pokerDieRoller dieRoller)
        {
            mDieRoller = dieRoller;
        }

        public pokerDiceHand Reroll(pokerDiceHand oldHand, string facesToKeep)
        {
            pokerDiceHand pdh = new pokerDiceHand("99999");
            return pdh;
        }

        public pokerDiceHand GetNewHand()
        {
            string fiveFacesString = "";
            for(int i = 0; i < 5; i++)
                fiveFacesString += mDieRoller.Roll(showAsString.y);

            pokerDiceHand pdh = new pokerDiceHand(fiveFacesString);
            return pdh;
        }

        private pokerDieRoller mDieRoller;
    }
}
