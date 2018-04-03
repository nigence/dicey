using System;

namespace ld
{
    public class pokerDiceHand
    {
        private void countFaces(String fiveFacesString, string faceKind, ref int counterToIncrement )
        {
            int faceVal = System.Char.ConvertToUtf32( faceKind, 0 );
            counterToIncrement = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == faceVal)
                    counterToIncrement++;
            }
        }

        public pokerDiceHand( String fiveFacesString )
        {
            countFaces(fiveFacesString, "A", ref acesCount);
            countFaces(fiveFacesString, "K", ref kingsCount);
            countFaces(fiveFacesString, "Q", ref queensCount);
            countFaces(fiveFacesString, "J", ref jacksCount);
            countFaces(fiveFacesString, "T", ref tensCount);
            countFaces(fiveFacesString, "9", ref ninesCount);

            for (int i = 0; i < acesCount; i++)
                faces += "A";
            for (int i = 0; i < kingsCount; i++)
                faces += "K";
            for (int i = 0; i < queensCount; i++)
                faces += "Q";
            for (int i = 0; i < jacksCount; i++)
                faces += "J";
            for (int i = 0; i < tensCount; i++)
                faces += "T";
            for (int i = 0; i < ninesCount; i++)
                faces += "9";
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
            int hashcode = 0;
            hashcode += 100000 * acesCount;
            hashcode += 10000 * kingsCount;
            hashcode += 1000 * queensCount;
            hashcode += 100 * jacksCount;
            hashcode += 10 * tensCount;
            hashcode += 1 * ninesCount;
            return hashcode;
        }

        private String faces = "";
        private int acesCount = 0;
        private int kingsCount = 0;
        private int queensCount = 0;
        private int jacksCount = 0;
        private int tensCount = 0;
        private int ninesCount = 0;

    }
}
