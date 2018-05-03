using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    public enum pokerDieFace
    {
        N = 0, // "9" as string NOT "N"
        T = 1, // "T"
        J = 2, // "J"
        Q = 3, // "Q"
        K = 4, // "K"
        A = 5  // "A"
    }
    enum showAsEnum{y,Y}
    enum showAsString{y, Y}

    interface pokerDieRoller
    {
        pokerDieFace Roll(showAsEnum y);
        string Roll(showAsString y );
    }

    public class pokerDieFaceConversion
    {
        public static string ToString(pokerDieFace pdf)
        {
            switch (pdf) {
                case pokerDieFace.N: return "9";
                case pokerDieFace.T: return "T";
                case pokerDieFace.J: return "J";
                case pokerDieFace.Q: return "Q";
                case pokerDieFace.K: return "K";
                case pokerDieFace.A: return "A";
                }
            return "*";
        }
    }
}
