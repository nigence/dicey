using System;
using System.Collections.Generic;
using System.Linq;

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
            RefineHandKind(facesCounts);
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

        private static bool gt(pokerDiceHand lhs, pokerDiceHand rhs)
        {
            if (lhs.handKind != rhs.handKind)
                return lhs.handKind < rhs.handKind;

            if (lhs.primaryFace != rhs.primaryFace)
                return lhs.primaryFace > rhs.primaryFace;
            if (lhs.secondaryFace != rhs.secondaryFace)
                return lhs.secondaryFace > rhs.secondaryFace;
            return lhs.hashcode > rhs.hashcode;
        }

        public static bool operator > (pokerDiceHand lhs, pokerDiceHand rhs)
        {
            return gt(lhs, rhs);
        }

        public static bool operator < (pokerDiceHand lhs, pokerDiceHand rhs)
        {
            if (lhs==rhs)
                return false;
            return (!gt(lhs, rhs));
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
            List<int> fc = new List<int>();
            for (int i = 0; i < facesCounts.Length; i++)
                fc.Add(facesCounts[i]);
            List<int> unsortedFaceCounts = new List<int>();
            unsortedFaceCounts = fc.ToList();

            fc.Sort();
            fc.Reverse();

            switch (fc[0])
            {
                case 5:
                    handKind = HandKind.fiveOfKind; break;
                case 4:
                    handKind = HandKind.fourOfKind; break;
                case 3:
                    handKind = (fc[1] == 2 ? HandKind.fullHouse : HandKind.threeOfKind); break;
                case 2:
                    handKind = (fc[1] == 2 ? HandKind.twoPairs : HandKind.pair); break;
                case 1:
                    if (unsortedFaceCounts[faceToIndex["T"]] == 0 || 
                        unsortedFaceCounts[faceToIndex["J"]] == 0 ||
                        unsortedFaceCounts[faceToIndex["Q"]] == 0 ||
                        unsortedFaceCounts[faceToIndex["K"]] == 0
                        )
                        handKind = HandKind.none;
                    else
                        handKind = HandKind.straight;
                    break;
            }
        }

        private void RefineHandKind(int[] facesCounts)
        {
            switch(handKind)
            {
                case HandKind.fiveOfKind:
                    primaryFace = FindRepeatedFace(facesCounts, 5);
                    break;

                case HandKind.fourOfKind:
                    primaryFace = FindRepeatedFace(facesCounts, 4);
                    secondaryFace = FindRepeatedFace(facesCounts, 1);
                    break;

                case HandKind.fullHouse:
                    primaryFace = FindRepeatedFace(facesCounts, 3);
                    secondaryFace = FindRepeatedFace(facesCounts, 2);
                    break;

                case HandKind.straight:

                case HandKind.threeOfKind:
                    primaryFace = FindRepeatedFace(facesCounts, 3);
                    secondaryFace = FindRepeatedFace(facesCounts, 1);
                    break;

                case HandKind.twoPairs:
                    primaryFace = FindRepeatedFace(facesCounts, 2);
                    secondaryFace = FindRepeatedFace(facesCounts, 2, primaryFace);
                    break;

                case HandKind.pair:
                    primaryFace = FindRepeatedFace(facesCounts, 2);
                    secondaryFace = FindRepeatedFace(facesCounts, 1, primaryFace);
                    break;

                case HandKind.none:
                    primaryFace = FindRepeatedFace(facesCounts, 1);
                    secondaryFace = FindRepeatedFace(facesCounts, 1, primaryFace);
                    break;
            }
        }

        private int FindRepeatedFace(int[] facesCounts,  int frequency, int? excludeA=null, int? excludeB=null )
        {
            for (int j = indexToFace.Count - 1; j > -1; j--)
            {
                if(facesCounts[j]==frequency)
                {
                    if ((excludeA == null && excludeB == null)
                        || ((excludeA == null) && (excludeB != j))
                        || ((excludeB == null) && (excludeA != j))
                        || ((excludeA != j) && (excludeB != j))
                        )
                        return j;
                }
            }
            return -1;
        }

        private HandKind handKind;
        private int hashcode;
        private String faces = "";
        private int? primaryFace;
        private int? secondaryFace;

        private Dictionary<int, string> indexToFace = new Dictionary<int, string>();
        private Dictionary<string, int> faceToIndex = new Dictionary<string, int>();
    }
}
