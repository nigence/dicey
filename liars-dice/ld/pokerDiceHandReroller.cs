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

        public pokerDiceHand Reroll(pokerDiceHand oldHand, string facesToReRoll)
        {
            string oldFaces = oldHand.getFacesOrderedByRank();
            bool remainderFoundOkay = false;
            string retainedFaces = Remainder(oldFaces, facesToReRoll, ref remainderFoundOkay);
            if (!remainderFoundOkay) return new pokerDiceHand("xxxxx");
            string newFaces = retainedFaces;
            string newRoll;
            for(int i = 0; i<facesToReRoll.Length; i++)
            {
                newRoll = mDieRoller.Roll(showAsString.y);
                newFaces += newRoll;
            }
            pokerDiceHand pdh = new pokerDiceHand(newFaces);
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

        public static string Remainder(string facesString, string facesToRemove, ref bool okay )
        {
            if ((!pokerDiceHand.isValidFacesString(facesString)) ||
             (!pokerDiceHand.isValidFacesString(facesToRemove)) ||
             (facesString.Length < facesToRemove.Length))
            {
                okay = false;
                return "";
            }

            string workingstring = facesString;
            foreach(char c in facesToRemove)
            {
                workingstring = Remove(workingstring, c);
            }

            okay = true;
            return workingstring;
        }

        private static string Remove(string facesString, char faceToRemove)
        {
            string LHSsplice = facesString;
            string RHSsplice = "";
            int i = 0;
            foreach(char c in facesString)
            {
                if (c == faceToRemove)
                {
                    LHSsplice = facesString.Substring(0, i);
                    RHSsplice = facesString.Substring(i + 1, facesString.Length - i - 1);
                }
                i++;
            }
            return LHSsplice + RHSsplice;
        }


        private pokerDieRoller mDieRoller;
    }
}
