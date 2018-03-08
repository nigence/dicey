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

        private String faces = "";
    }
}
