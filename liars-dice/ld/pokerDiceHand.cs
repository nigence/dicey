using System;
using System.Collections.Generic;

namespace ld
{
    public class pokerDiceHand
    {

        public pokerDiceHand(String fiveFacesString)
        {
            indexToFace.Add(0, "9");
            indexToFace.Add(1, "T");
            indexToFace.Add(2, "J");
            indexToFace.Add(3, "Q");
            indexToFace.Add(4, "K");
            indexToFace.Add(5, "A");
            faceToIndex.Add("9", 0);
            faceToIndex.Add("T", 1);
            faceToIndex.Add("J", 2);
            faceToIndex.Add("Q", 3);
            faceToIndex.Add("K", 4);
            faceToIndex.Add("A", 5);

            int[] facesCounts = new int[indexToFace.Count];

            for (int j=indexToFace.Count-1; j>-1; j--)
            {
                countFaces(fiveFacesString, indexToFace[j], ref facesCounts[j]);

                for (int i = 0; i < facesCounts[j]; i++)
                    faces += indexToFace[j];
            }

            SetHashCode(facesCounts);
            SetHandKind(facesCounts);
        }

        public HandKind getHandKind()
        {
            return handKind;
        }


        public string getFacesOrderedByRank()
        {
            return faces;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            pokerDiceHand p = obj as pokerDiceHand;
            if ((System.Object)p == null)
                return false;

            return (faces == p.faces);
        }

        public bool Equals ( pokerDiceHand obj )
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj.faces == faces)
                return true;
            return false;
        }

        public static bool operator == (pokerDiceHand lhs, pokerDiceHand rhs)
        {
            if (ReferenceEquals(lhs, null))
                return true;
            if (ReferenceEquals(rhs, null))
                return true;
            if (ReferenceEquals(lhs, rhs))
                return true;
            if (lhs.faces == rhs.faces)
                return true;
            return false;
        }

        public static bool operator !=(pokerDiceHand lhs, pokerDiceHand rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator > (pokerDiceHand lhs, pokerDiceHand rhs)
        {
            return false;
        }

        public static bool operator < (pokerDiceHand lhs, pokerDiceHand rhs)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return hashcode;
        }

        private void SetHashCode( int[] facesCounts)
        {
            hashcode = 0;
            int multiplier = 1;

            for (int i=0; i<facesCounts.Length; i++)
            {
                hashcode += multiplier * facesCounts[i];
                multiplier *= 10;
            }
        }

        public enum HandKind { fiveOfKind, fourOfKind, fullHouse, straight, threeOfKind, twoPairs, pair, none };

        private void countFaces(String fiveFacesString, string faceKind, ref int counterToIncrement)
        {
            int faceVal = System.Char.ConvertToUtf32(faceKind, 0);
            counterToIncrement = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == faceVal)
                    counterToIncrement++;
            }
        }

        private void SetHandKind(int[] facesCounts)
        {
            for (int i = 0; i < facesCounts.Length; i++)
            {


            }
            handKind = HandKind.none;
        }

        private HandKind handKind;
        private int hashcode;
        private String faces = "";

        private Dictionary<int, string> indexToFace = new Dictionary<int, string>();
        private Dictionary<string, int> faceToIndex = new Dictionary<string, int>();
    }
}
