using System;
using System.Collections.Generic;
using System.Linq;

namespace ld
{
    public class pokerDiceHand
    {
        public static bool isValidFacesString(string facesString)
        {
            string s = string.Empty;
            foreach(char c in facesString)
            {
                s = string.Empty;
                s += c;
                int i = Index(s);
                if (i < 0)
                    return false;
            }
            return true;
        }

        public pokerDiceHand(String fiveFacesString)
        {
            int[] facesCounts = new int[FacesCount()];

            for (int j= FacesCount() - 1; j>-1; j--)
            {
                countFaces(fiveFacesString, Face(j), ref facesCounts[j]);

                for (int i = 0; i < facesCounts[j]; i++)
                    faces += Face(j);
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
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
                return true;
            if (ReferenceEquals(lhs, null))
                return false;
            if (ReferenceEquals(rhs, null))
                return false;
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

        private static void countFaces(String fiveFacesString, string faceKind, ref int counterToIncrement)
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
                    if (unsortedFaceCounts[ Index("T")] == 0 || 
                        unsortedFaceCounts[ Index("J")] == 0 ||
                        unsortedFaceCounts[ Index("Q")] == 0 ||
                        unsortedFaceCounts[ Index("K")] == 0
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

        private static int FindRepeatedFace(int[] facesCounts,  int frequency, int? excludeA=null, int? excludeB=null )
        {
            for (int j = FacesCount() - 1; j > -1; j--)
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

        private static string Face(int facenum)
        {
            string retval = "";
            switch(facenum)
            {
                case 0: retval += "9"; break;
                case 1: retval += "T"; break;
                case 2: retval += "J"; break;
                case 3: retval += "Q"; break;
                case 4: retval += "K"; break;
                case 5: retval += "A"; break;
            }
            return retval;
        }

        private static int Index(string face)
        {
            int i = 0;
            string s = "";
            do
            {
                s = Face(i);
                if (s == face)
                    return i;
                i++;
            }
            while (s.Length > 0);

            return -1;
        }

        private static int FacesCount()
        {
            return (Index("A")+1);
        }

    }
}
