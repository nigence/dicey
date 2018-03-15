using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class unitTester
    {
        public unitTester()
        {
        }

        public void runAll()
        {
            Console.WriteLine("...runAll()");

            if (!PokerDiceHandEqualityOperatorTestPassed())
                Console.WriteLine("......Fail");
            else
                Console.WriteLine("......Pass");

        }

        private bool PokerDiceHandEqualityOperatorTestPassed()
        {
            pokerDiceHand pdha = new pokerDiceHand("AAJJ9");
            pokerDiceHand pdhb = new pokerDiceHand("AJ9AJ");
            if (pdha != pdhb)
                return false;

            pokerDiceHand pdhc = new pokerDiceHand("AJAAJ");
            if (pdha == pdhc)
                return false;

            return true;
        }
    }
}
