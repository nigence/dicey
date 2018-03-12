using System;

namespace ld
{
    public class pokerDiceHand
    {
        public pokerDiceHand( String fiveFacesString )
        {
            int ace = System.Char.ConvertToUtf32( "A", 0 );
            int acesCount = 0;
            for ( int i = 0; i < 5; i++ )
            {
                if (fiveFacesString[i] == ace)
                    acesCount++;
            }

            int king = System.Char.ConvertToUtf32("K", 0);
            int kingsCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == king)
                    kingsCount++;
            }

            int queen = System.Char.ConvertToUtf32("Q", 0);
            int queensCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == queen)
                    queensCount++;
            }

            int jack = System.Char.ConvertToUtf32("J", 0);
            int jacksCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == jack)
                    jacksCount++;
            }

            int ten = System.Char.ConvertToUtf32("T", 0);
            int tensCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == ten)
                    tensCount++;
            }

            int nine = System.Char.ConvertToUtf32("9", 0);
            int ninesCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (fiveFacesString[i] == nine)
                    ninesCount++;
            }


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
            {
                return false;
            }
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
