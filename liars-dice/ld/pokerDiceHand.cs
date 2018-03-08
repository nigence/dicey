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
        }

        private String faces = "";
    }
}
