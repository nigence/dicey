using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class unitTester
    {
        private pokerDieRollerTestMock pdrtm;

        public unitTester()
        {
            pdrtm = new pokerDieRollerTestMock();
        }

        public void runAll()
        {
            Console.WriteLine("...runAll()");
            bool allOkay = false;
            for (int i = 0; i < 1; i++)
            {
                if (!PokerDiceHandEqualityOperatorTestPassed()) break;
                if (!permutationsCalculatorTestPassed()) break;
                if (!handKindsIdentifyTestPassed()) break;
                if (!PokerDiceHandGreaterLessThanOperatorsTestPassed()) break;
                if (!GameEngineNewGameTestPassed()) break;
                if (!GameEngineSampleGameTestPassed()) break;
                allOkay = true;
            }
            if (!allOkay)
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


        private bool handKindsIdentifyTestPassed()
        {
            bool allOkay = false;
            pokerDiceHand pdh = new pokerDiceHand("AAAAA");
            for (int i = 0; i < 1; i++)
            {
                if (pdh.getHandKind() != pokerDiceHand.HandKind.fiveOfKind) break;

                pdh = new pokerDiceHand("A9AAA");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.fourOfKind) break;

                pdh = new pokerDiceHand("Q9QQA");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.threeOfKind) break;

                pdh = new pokerDiceHand("Q9QQ9");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.fullHouse) break;

                pdh = new pokerDiceHand("T9TQ9");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.twoPairs) break;

                pdh = new pokerDiceHand("T9TQJ");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.pair) break;

                pdh = new pokerDiceHand("9TKQJ");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.straight) break;

                pdh = new pokerDiceHand("AKQJT");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.straight) break;

                pdh = new pokerDiceHand("TA9KQ");
                if (pdh.getHandKind() != pokerDiceHand.HandKind.none) break;

                allOkay = true;
            }
            return allOkay;
        }

        private bool PokerDiceHandGreaterLessThanOperatorsTestPassed()
        {
            int size = handRankArray.Length;
            // Console.WriteLine("......handRankArray.Length() is {0}", size); //This MUST be 252
            bool testFailSeen = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    pokerDiceHand a = handRankArray[i];
                    pokerDiceHand b = handRankArray[j];
                    if (i == j && !(a == b))
                        testFailSeen = true;
                    if (i > j && !(a < b))
                        testFailSeen = true;
                    if (i < j && !(a > b))
                        testFailSeen = true;
                    if (i > j && (a > b))
                        testFailSeen = true;
                    if (i < j && (a < b))
                        testFailSeen = true;
                    if (testFailSeen)
                    {
                        string debugStr = "PokerDiceHandGreaterLessThanOperatorsTestPassed() FAIL with ";
                        debugStr += a.getFacesOrderedByRank();
                        debugStr += " and ";
                        debugStr += b.getFacesOrderedByRank();
                        Console.WriteLine(debugStr);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool permutationsCalculatorTestPassed()
        {
            string expectedPermutationsTable
                =
            "|[99999, 1]|[A9999, 5]|[AA999, 10]|[AAA99, 10]|[AAAA9, 5]|[AAAAA, 1]|[AAAAJ, 5]|[AAAAK, 5]|[AAAAQ, 5]|[AAAAT, 5]|[AAAJ9, 20]|[AAAJJ, 10]|[AAAJT, 20]|[AAAK9, 20]|[AAAKJ, 20]|[AAAKK, 10]|[AAAKQ, 20]|[AAAKT, 20]|[AAAQ9, 20]|[AAAQJ, 20]|[AAAQQ, 10]|[AAAQT, 20]|[AAAT9, 20]|[AAATT, 10]|[AAJ99, 30]|[AAJJ9, 30]|[AAJJJ, 10]|[AAJJT, 30]|[AAJT9, 60]|[AAJTT, 30]|[AAK99, 30]|[AAKJ9, 60]|[AAKJJ, 30]|[AAKJT, 60]|[AAKK9, 30]|[AAKKJ, 30]|[AAKKK, 10]|[AAKKQ, 30]|[AAKKT, 30]|[AAKQ9, 60]|[AAKQJ, 60]|[AAKQQ, 30]|[AAKQT, 60]|[AAKT9, 60]|[AAKTT, 30]|[AAQ99, 30]|[AAQJ9, 60]|[AAQJJ, 30]|[AAQJT, 60]|[AAQQ9, 30]|[AAQQJ, 30]|[AAQQQ, 10]|[AAQQT, 30]|[AAQT9, 60]|[AAQTT, 30]|[AAT99, 30]|[AATT9, 30]|[AATTT, 10]|[AJ999, 20]|[AJJ99, 30]|[AJJJ9, 20]|[AJJJJ, 5]|[AJJJT, 20]|[AJJT9, 60]|[AJJTT, 30]|[AJT99, 60]|[AJTT9, 60]|[AJTTT, 20]|[AK999, 20]|[AKJ99, 60]|[AKJJ9, 60]|[AKJJJ, 20]|[AKJJT, 60]|[AKJT9, 120]|[AKJTT, 60]|[AKK99, 30]|[AKKJ9, 60]|[AKKJJ, 30]|[AKKJT, 60]|[AKKK9, 20]|[AKKKJ, 20]|[AKKKK, 5]|[AKKKQ, 20]|[AKKKT, 20]|[AKKQ9, 60]|[AKKQJ, 60]|[AKKQQ, 30]|[AKKQT, 60]|[AKKT9, 60]|[AKKTT, 30]|[AKQ99, 60]|[AKQJ9, 120]|[AKQJJ, 60]|[AKQJT, 120]|[AKQQ9, 60]|[AKQQJ, 60]|[AKQQQ, 20]|[AKQQT, 60]|[AKQT9, 120]|[AKQTT, 60]|[AKT99, 60]|[AKTT9, 60]|[AKTTT, 20]|[AQ999, 20]|[AQJ99, 60]|[AQJJ9, 60]|[AQJJJ, 20]|[AQJJT, 60]|[AQJT9, 120]|[AQJTT, 60]|[AQQ99, 30]|[AQQJ9, 60]|[AQQJJ, 30]|[AQQJT, 60]|[AQQQ9, 20]|[AQQQJ, 20]|[AQQQQ, 5]|[AQQQT, 20]|[AQQT9, 60]|[AQQTT, 30]|[AQT99, 60]|[AQTT9, 60]|[AQTTT, 20]|[AT999, 20]|[ATT99, 30]|[ATTT9, 20]|[ATTTT, 5]|[J9999, 5]|[JJ999, 10]|[JJJ99, 10]|[JJJJ9, 5]|[JJJJJ, 1]|[JJJJT, 5]|[JJJT9, 20]|[JJJTT, 10]|[JJT99, 30]|[JJTT9, 30]|[JJTTT, 10]|[JT999, 20]|[JTT99, 30]|[JTTT9, 20]|[JTTTT, 5]|[K9999, 5]|[KJ999, 20]|[KJJ99, 30]|[KJJJ9, 20]|[KJJJJ, 5]|[KJJJT, 20]|[KJJT9, 60]|[KJJTT, 30]|[KJT99, 60]|[KJTT9, 60]|[KJTTT, 20]|[KK999, 10]|[KKJ99, 30]|[KKJJ9, 30]|[KKJJJ, 10]|[KKJJT, 30]|[KKJT9, 60]|[KKJTT, 30]|[KKK99, 10]|[KKKJ9, 20]|[KKKJJ, 10]|[KKKJT, 20]|[KKKK9, 5]|[KKKKJ, 5]|[KKKKK, 1]|[KKKKQ, 5]|[KKKKT, 5]|[KKKQ9, 20]|[KKKQJ, 20]|[KKKQQ, 10]|[KKKQT, 20]|[KKKT9, 20]|[KKKTT, 10]|[KKQ99, 30]|[KKQJ9, 60]|[KKQJJ, 30]|[KKQJT, 60]|[KKQQ9, 30]|[KKQQJ, 30]|[KKQQQ, 10]|[KKQQT, 30]|[KKQT9, 60]|[KKQTT, 30]|[KKT99, 30]|[KKTT9, 30]|[KKTTT, 10]|[KQ999, 20]|[KQJ99, 60]|[KQJJ9, 60]|[KQJJJ, 20]|[KQJJT, 60]|[KQJT9, 120]|[KQJTT, 60]|[KQQ99, 30]|[KQQJ9, 60]|[KQQJJ, 30]|[KQQJT, 60]|[KQQQ9, 20]|[KQQQJ, 20]|[KQQQQ, 5]|[KQQQT, 20]|[KQQT9, 60]|[KQQTT, 30]|[KQT99, 60]|[KQTT9, 60]|[KQTTT, 20]|[KT999, 20]|[KTT99, 30]|[KTTT9, 20]|[KTTTT, 5]|[Q9999, 5]|[QJ999, 20]|[QJJ99, 30]|[QJJJ9, 20]|[QJJJJ, 5]|[QJJJT, 20]|[QJJT9, 60]|[QJJTT, 30]|[QJT99, 60]|[QJTT9, 60]|[QJTTT, 20]|[QQ999, 10]|[QQJ99, 30]|[QQJJ9, 30]|[QQJJJ, 10]|[QQJJT, 30]|[QQJT9, 60]|[QQJTT, 30]|[QQQ99, 10]|[QQQJ9, 20]|[QQQJJ, 10]|[QQQJT, 20]|[QQQQ9, 5]|[QQQQJ, 5]|[QQQQQ, 1]|[QQQQT, 5]|[QQQT9, 20]|[QQQTT, 10]|[QQT99, 30]|[QQTT9, 30]|[QQTTT, 10]|[QT999, 20]|[QTT99, 30]|[QTTT9, 20]|[QTTTT, 5]|[T9999, 5]|[TT999, 10]|[TTT99, 10]|[TTTT9, 5]|[TTTTT, 1]|";
            permutationsCalculator pc = new permutationsCalculator();
            string pt = pc.getPermutationTable();
            return (pt == expectedPermutationsTable);
        }

        private pokerDiceHand[] handRankArray = {

        new pokerDiceHand("AAAAA"), // 1 permutations -- FIVE OF A KIND
		new pokerDiceHand("KKKKK"), // 1 permutations 
		new pokerDiceHand("QQQQQ"), // 1 permutations 
		new pokerDiceHand("JJJJJ"), // 1 permutations
		new pokerDiceHand("TTTTT"), // 1 permutations
		new pokerDiceHand("99999"), // 1 permutations
		new pokerDiceHand("AAAAK"), // 5 permutations -- FOUR OF A KIND
		new pokerDiceHand("AAAAQ"), // 5 permutations 
		new pokerDiceHand("AAAAJ"), // 5 permutations 
		new pokerDiceHand("AAAAT"), // 5 permutations 
		new pokerDiceHand("AAAA9"), // 5 permutations 
		new pokerDiceHand("AKKKK"), // 5 permutations 
		new pokerDiceHand("KKKKQ"), // 5 permutations 
		new pokerDiceHand("KKKKJ"), // 5 permutations 
		new pokerDiceHand("KKKKT"), // 5 permutations 
		new pokerDiceHand("KKKK9"), // 5 permutations 
		new pokerDiceHand("AQQQQ"), // 5 permutations 
		new pokerDiceHand("KQQQQ"), // 5 permutations 
		new pokerDiceHand("QQQQJ"), // 5 permutations 
		new pokerDiceHand("QQQQT"), // 5 permutations 
		new pokerDiceHand("QQQQ9"), // 5 permutations 
		new pokerDiceHand("AJJJJ"), // 5 permutations 
		new pokerDiceHand("KJJJJ"), // 5 permutations 
		new pokerDiceHand("QJJJJ"), // 5 permutations 
		new pokerDiceHand("JJJJT"), // 5 permutations 
		new pokerDiceHand("JJJJ9"), // 5 permutations 
		new pokerDiceHand("ATTTT"), // 5 permutations 
		new pokerDiceHand("KTTTT"), // 5 permutations 
		new pokerDiceHand("QTTTT"), // 5 permutations 
		new pokerDiceHand("JTTTT"), // 5 permutations 
		new pokerDiceHand("TTTT9"), // 5 permutations 
		new pokerDiceHand("A9999"), // 5 permutations 
		new pokerDiceHand("K9999"), // 5 permutations 
		new pokerDiceHand("Q9999"), // 5 permutations 
		new pokerDiceHand("J9999"), // 5 permutations 
		new pokerDiceHand("T9999"), // 5 permutations 
		new pokerDiceHand("AAAKK"), // 10 permutations  -- FULL HOUSE
		new pokerDiceHand("AAAQQ"), // 10 permutations 
		new pokerDiceHand("AAAJJ"), // 10 permutations 
		new pokerDiceHand("AAATT"), // 10 permutations 
		new pokerDiceHand("AAA99"), // 10 permutations 
		new pokerDiceHand("AAKKK"), // 10 permutations 
		new pokerDiceHand("KKKQQ"), // 10 permutations 
		new pokerDiceHand("KKKJJ"), // 10 permutations 
		new pokerDiceHand("KKKTT"), // 10 permutations 
		new pokerDiceHand("KKK99"), // 10 permutations 
		new pokerDiceHand("AAQQQ"), // 10 permutations 
		new pokerDiceHand("KKQQQ"), // 10 permutations 
		new pokerDiceHand("QQQJJ"), // 10 permutations 
		new pokerDiceHand("QQQTT"), // 10 permutations 
		new pokerDiceHand("QQQ99"), // 10 permutations 
		new pokerDiceHand("AAJJJ"), // 10 permutations 
		new pokerDiceHand("KKJJJ"), // 10 permutations 
		new pokerDiceHand("QQJJJ"), // 10 permutations 
		new pokerDiceHand("JJJTT"), // 10 permutations 
		new pokerDiceHand("JJJ99"), // 10 permutations 
		new pokerDiceHand("AATTT"), // 10 permutations 
		new pokerDiceHand("KKTTT"), // 10 permutations 
		new pokerDiceHand("QQTTT"), // 10 permutations 
		new pokerDiceHand("JJTTT"), // 10 permutations 
		new pokerDiceHand("TTT99"), // 10 permutations 
		new pokerDiceHand("AA999"), // 10 permutations 
		new pokerDiceHand("KK999"), // 10 permutations 
		new pokerDiceHand("QQ999"), // 10 permutations 
		new pokerDiceHand("JJ999"), // 10 permutations 
		new pokerDiceHand("TT999"), // 10 permutations 
		new pokerDiceHand("AKQJT"), // 120 permutations  -- STRAIGHT
		new pokerDiceHand("KQJT9"), // 120 permutations 
		new pokerDiceHand("AAAKQ"), // 20 permutations  -- THREE OF A KIND
		new pokerDiceHand("AAAKJ"), // 20 permutations 
		new pokerDiceHand("AAAKT"), // 20 permutations 
		new pokerDiceHand("AAAK9"), // 20 permutations 
		new pokerDiceHand("AAAQJ"), // 20 permutations 
		new pokerDiceHand("AAAQT"), // 20 permutations 
		new pokerDiceHand("AAAQ9"), // 20 permutations 
		new pokerDiceHand("AAAJT"), // 20 permutations 
		new pokerDiceHand("AAAJ9"), // 20 permutations 
		new pokerDiceHand("AAAT9"), // 20 permutations 
		new pokerDiceHand("AKKKQ"), // 20 permutations 
		new pokerDiceHand("AKKKJ"), // 20 permutations 
		new pokerDiceHand("AKKKT"), // 20 permutations 
		new pokerDiceHand("AKKK9"), // 20 permutations 
		new pokerDiceHand("KKKQJ"), // 20 permutations 
		new pokerDiceHand("KKKQT"), // 20 permutations 
		new pokerDiceHand("KKKQ9"), // 20 permutations 
		new pokerDiceHand("KKKJT"), // 20 permutations 
		new pokerDiceHand("KKKJ9"), // 20 permutations 
		new pokerDiceHand("KKKT9"), // 20 permutations 
		new pokerDiceHand("AKQQQ"), // 20 permutations 
		new pokerDiceHand("AQQQJ"), // 20 permutations 
		new pokerDiceHand("AQQQT"), // 20 permutations 
		new pokerDiceHand("AQQQ9"), // 20 permutations 
		new pokerDiceHand("KQQQJ"), // 20 permutations 
		new pokerDiceHand("KQQQT"), // 20 permutations 
		new pokerDiceHand("KQQQ9"), // 20 permutations 
		new pokerDiceHand("QQQJT"), // 20 permutations 
		new pokerDiceHand("QQQJ9"), // 20 permutations 
		new pokerDiceHand("QQQT9"), // 20 permutations 
		new pokerDiceHand("AKJJJ"), // 20 permutations 
		new pokerDiceHand("AQJJJ"), // 20 permutations 
		new pokerDiceHand("AJJJT"), // 20 permutations 
		new pokerDiceHand("AJJJ9"), // 20 permutations 
		new pokerDiceHand("KQJJJ"), // 20 permutations 
		new pokerDiceHand("KJJJT"), // 20 permutations 
		new pokerDiceHand("KJJJ9"), // 20 permutations 
		new pokerDiceHand("QJJJT"), // 20 permutations 
		new pokerDiceHand("QJJJ9"), // 20 permutations 
		new pokerDiceHand("JJJT9"), // 20 permutations 
		new pokerDiceHand("AKTTT"), // 20 permutations 
		new pokerDiceHand("AQTTT"), // 20 permutations 
		new pokerDiceHand("AJTTT"), // 20 permutations 
		new pokerDiceHand("ATTT9"), // 20 permutations 
		new pokerDiceHand("KQTTT"), // 20 permutations 
		new pokerDiceHand("KJTTT"), // 20 permutations 
		new pokerDiceHand("KTTT9"), // 20 permutations 
		new pokerDiceHand("QJTTT"), // 20 permutations 
		new pokerDiceHand("QTTT9"), // 20 permutations 
		new pokerDiceHand("JTTT9"), // 20 permutations 
		new pokerDiceHand("AK999"), // 20 permutations 
		new pokerDiceHand("AQ999"), // 20 permutations 
		new pokerDiceHand("AJ999"), // 20 permutations 
		new pokerDiceHand("AT999"), // 20 permutations 
		new pokerDiceHand("KQ999"), // 20 permutations 
		new pokerDiceHand("KJ999"), // 20 permutations 
		new pokerDiceHand("KT999"), // 20 permutations 
		new pokerDiceHand("QJ999"), // 20 permutations 
		new pokerDiceHand("QT999"), // 20 permutations 
		new pokerDiceHand("JT999"), // 20 permutations 
		new pokerDiceHand("AAKKQ"), // 30 permutations  -- TWO PAIRS
		new pokerDiceHand("AAKKJ"), // 30 permutations 
		new pokerDiceHand("AAKKT"), // 30 permutations 
		new pokerDiceHand("AAKK9"), // 30 permutations 
		new pokerDiceHand("AAKQQ"), // 30 permutations 
		new pokerDiceHand("AAQQJ"), // 30 permutations 
		new pokerDiceHand("AAQQT"), // 30 permutations 
		new pokerDiceHand("AAQQ9"), // 30 permutations 
		new pokerDiceHand("AAKJJ"), // 30 permutations 
		new pokerDiceHand("AAQJJ"), // 30 permutations 
		new pokerDiceHand("AAJJT"), // 30 permutations 
		new pokerDiceHand("AAJJ9"), // 30 permutations 
		new pokerDiceHand("AAKTT"), // 30 permutations 
		new pokerDiceHand("AAQTT"), // 30 permutations 
		new pokerDiceHand("AAJTT"), // 30 permutations 
		new pokerDiceHand("AATT9"), // 30 permutations 
		new pokerDiceHand("AAK99"), // 30 permutations 
		new pokerDiceHand("AAQ99"), // 30 permutations 
		new pokerDiceHand("AAJ99"), // 30 permutations 
		new pokerDiceHand("AAT99"), // 30 permutations 
		new pokerDiceHand("AKKQQ"), // 30 permutations 
		new pokerDiceHand("KKQQJ"), // 30 permutations 
		new pokerDiceHand("KKQQT"), // 30 permutations 
		new pokerDiceHand("KKQQ9"), // 30 permutations 
		new pokerDiceHand("AKKJJ"), // 30 permutations 
		new pokerDiceHand("KKQJJ"), // 30 permutations 
		new pokerDiceHand("KKJJT"), // 30 permutations 
		new pokerDiceHand("KKJJ9"), // 30 permutations 
		new pokerDiceHand("AKKTT"), // 30 permutations 
		new pokerDiceHand("KKQTT"), // 30 permutations 
		new pokerDiceHand("KKJTT"), // 30 permutations 
		new pokerDiceHand("KKTT9"), // 30 permutations 
		new pokerDiceHand("AKK99"), // 30 permutations 
		new pokerDiceHand("KKQ99"), // 30 permutations 
		new pokerDiceHand("KKJ99"), // 30 permutations 
		new pokerDiceHand("KKT99"), // 30 permutations 
		new pokerDiceHand("AQQJJ"), // 30 permutations 
		new pokerDiceHand("KQQJJ"), // 30 permutations 
		new pokerDiceHand("QQJJT"), // 30 permutations 
		new pokerDiceHand("QQJJ9"), // 30 permutations 
		new pokerDiceHand("AQQTT"), // 30 permutations 
		new pokerDiceHand("KQQTT"), // 30 permutations 
		new pokerDiceHand("QQJTT"), // 30 permutations 
		new pokerDiceHand("QQTT9"), // 30 permutations 
		new pokerDiceHand("AQQ99"), // 30 permutations 
		new pokerDiceHand("KQQ99"), // 30 permutations 
		new pokerDiceHand("QQJ99"), // 30 permutations 
		new pokerDiceHand("QQT99"), // 30 permutations 
		new pokerDiceHand("AJJTT"), // 30 permutations 
		new pokerDiceHand("KJJTT"), // 30 permutations 
		new pokerDiceHand("QJJTT"), // 30 permutations 
		new pokerDiceHand("JJTT9"), // 30 permutations 
		new pokerDiceHand("AJJ99"), // 30 permutations 
		new pokerDiceHand("KJJ99"), // 30 permutations 
		new pokerDiceHand("QJJ99"), // 30 permutations 
		new pokerDiceHand("JJT99"), // 30 permutations 
		new pokerDiceHand("ATT99"), // 30 permutations 
		new pokerDiceHand("KTT99"), // 30 permutations 
		new pokerDiceHand("QTT99"), // 30 permutations 
		new pokerDiceHand("JTT99"), // 30 permutations 
		new pokerDiceHand("AAKQJ"), // 60 permutations  -- PAIR
		new pokerDiceHand("AAKQT"), // 60 permutations 
		new pokerDiceHand("AAKQ9"), // 60 permutations 
		new pokerDiceHand("AAKJT"), // 60 permutations 
		new pokerDiceHand("AAKJ9"), // 60 permutations 
		new pokerDiceHand("AAKT9"), // 60 permutations 
		new pokerDiceHand("AAQJT"), // 60 permutations 
		new pokerDiceHand("AAQJ9"), // 60 permutations 
		new pokerDiceHand("AAQT9"), // 60 permutations 
		new pokerDiceHand("AAJT9"), // 60 permutations 
		new pokerDiceHand("AKKQJ"), // 60 permutations 
		new pokerDiceHand("AKKQT"), // 60 permutations 
		new pokerDiceHand("AKKQ9"), // 60 permutations 
		new pokerDiceHand("AKKJT"), // 60 permutations 
		new pokerDiceHand("AKKJ9"), // 60 permutations 
		new pokerDiceHand("AKKT9"), // 60 permutations 
		new pokerDiceHand("KKQJT"), // 60 permutations 
		new pokerDiceHand("KKQJ9"), // 60 permutations 
		new pokerDiceHand("KKQT9"), // 60 permutations 
		new pokerDiceHand("KKJT9"), // 60 permutations 
		new pokerDiceHand("AKQQJ"), // 60 permutations 
		new pokerDiceHand("AKQQT"), // 60 permutations 
		new pokerDiceHand("AKQQ9"), // 60 permutations 
		new pokerDiceHand("AQQJT"), // 60 permutations 
		new pokerDiceHand("AQQJ9"), // 60 permutations 
		new pokerDiceHand("AQQT9"), // 60 permutations 
		new pokerDiceHand("KQQJT"), // 60 permutations 
		new pokerDiceHand("KQQJ9"), // 60 permutations 
		new pokerDiceHand("KQQT9"), // 60 permutations 
		new pokerDiceHand("QQJT9"), // 60 permutations 
		new pokerDiceHand("AKQJJ"), // 60 permutations 
		new pokerDiceHand("AKJJT"), // 60 permutations 
		new pokerDiceHand("AKJJ9"), // 60 permutations 
		new pokerDiceHand("AQJJT"), // 60 permutations 
		new pokerDiceHand("AQJJ9"), // 60 permutations 
		new pokerDiceHand("AJJT9"), // 60 permutations 
		new pokerDiceHand("KQJJT"), // 60 permutations 
		new pokerDiceHand("KQJJ9"), // 60 permutations 
		new pokerDiceHand("KJJT9"), // 60 permutations 
		new pokerDiceHand("QJJT9"), // 60 permutations 
		new pokerDiceHand("AKQTT"), // 60 permutations 
		new pokerDiceHand("AKJTT"), // 60 permutations 
		new pokerDiceHand("AKTT9"), // 60 permutations 
		new pokerDiceHand("AQJTT"), // 60 permutations 
		new pokerDiceHand("AQTT9"), // 60 permutations 
		new pokerDiceHand("AJTT9"), // 60 permutations 
		new pokerDiceHand("KQJTT"), // 60 permutations 
		new pokerDiceHand("KQTT9"), // 60 permutations 
		new pokerDiceHand("KJTT9"), // 60 permutations 
		new pokerDiceHand("QJTT9"), // 60 permutations 
		new pokerDiceHand("AKQ99"), // 60 permutations 
		new pokerDiceHand("AKJ99"), // 60 permutations 
		new pokerDiceHand("AKT99"), // 60 permutations 
		new pokerDiceHand("AQJ99"), // 60 permutations 
		new pokerDiceHand("AQT99"), // 60 permutations 
		new pokerDiceHand("AJT99"), // 60 permutations 
		new pokerDiceHand("KQJ99"), // 60 permutations 
		new pokerDiceHand("KQT99"), // 60 permutations 
		new pokerDiceHand("KJT99"), // 60 permutations 
		new pokerDiceHand("QJT99"), // 60 permutations 
		new pokerDiceHand("AKQJ9"), // 120 permutations  --ACE HIGH
		new pokerDiceHand("AKQT9"), // 120 permutations 
		new pokerDiceHand("AKJT9"), // 120 permutations 
		new pokerDiceHand("AQJT9"), // 120 permutations 
        };

        private bool GameEngineNewGameTestPassed()
        {
            gameEngine ge = new gameEngine(pdrtm);
            pdrtm.EnqueueRoll(pokerDieFace.T);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.J);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.A);

            gameEngineReturnMessage response = ge.CreateNewGame("Egbert");

            var ngd = response as newGameDetails;
            if (ngd == null)
                return false;

            string game1AccessToken = ngd.GetAccessToken();
            string game1Identifier = ngd.GetGameIdentifier();

            pdrtm.EnqueueRoll(pokerDieFace.T);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.J);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.A);
            response = ge.CreateNewGame("Nobacon");
            ngd = response as newGameDetails;
            if (ngd == null)
                return false;

            string game2AccessToken = ngd.GetAccessToken();
            string game2Identifier = ngd.GetGameIdentifier();

            if (game1AccessToken != null && game2AccessToken != null && game1Identifier != null && game2Identifier != null)
            {
                if (game1AccessToken != game2AccessToken && game1Identifier != game2Identifier)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private bool playerHasHand(string playerName, pokerDiceHand hand, gameEngine ge, Dictionary<string, string> playersAccessTokens)
        {
            gameEngineReturnMessage response = ge.Poll(playersAccessTokens[playerName]);
            pollResponse pollresponse = response as pollResponse;
            if (pollresponse == null) return false;

            if (hand == null)
            {
                if (pollresponse.HasHandToView()) return false;
            }
            return (pollresponse.GetNamedPlayersHand() == hand);
        }

        private bool playerHasHandOthersCantSee(string playerName, pokerDiceHand hand, gameEngine ge, Dictionary<string, string> playersAccessTokens)
        {
            foreach (var playerDetails in playersAccessTokens)
            {
                if (playerDetails.Key == playerName)
                {
                    if (!playerHasHand(playerName, hand, ge, playersAccessTokens))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!playerHasHand(playerDetails.Key, null, ge, playersAccessTokens))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private bool playerSeesGameStatus(string playerName, gameStatus expectedStatus, string playerNameWithActionAwaited, gameEngine ge, Dictionary<string, string> playersAccessTokens)
        {
            var response = ge.Poll(playersAccessTokens[playerName]);
            pollResponse pollresponse = response as pollResponse;
            if (pollresponse.status != expectedStatus) return false;
            if (pollresponse.awaitingActionFromPlayerName != playerNameWithActionAwaited) return false;
            return true;
        }

        private bool GameEngineSampleGameTestPassed()
        {
            gameEngine ge = new gameEngine(pdrtm);
            pdrtm.EnqueueRoll(pokerDieFace.T);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.J);
            pdrtm.EnqueueRoll(pokerDieFace.N);
            pdrtm.EnqueueRoll(pokerDieFace.A);
            gameEngineReturnMessage response = ge.CreateNewGame("Alice");
            var ngd = response as newGameDetails;
            string gameIdentifier = ngd.GetGameIdentifier();

            Dictionary<string, string> playersAccessTokens = new Dictionary<string, string>();
            playersAccessTokens.Add("Alice", ngd.GetAccessToken());

            // TWO MORE PLAYERS JOIN
            response = ge.JoinGame(gameIdentifier, "Bob");
            var pr = response as playerRegistration;
            if (pr.GetAccessToken() == null) return false;
            playersAccessTokens.Add("Bob", pr.GetAccessToken());

            response = ge.JoinGame(gameIdentifier, "Connie");
            pr = response as playerRegistration;
            if (pr.GetAccessToken() == null) return false;
            playersAccessTokens.Add("Connie", pr.GetAccessToken());


            // BOB SEES THREE PLAYERS TOTAL
            response = ge.Poll(playersAccessTokens["Bob"]);
            var pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.gameName != gameIdentifier) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;

            //BOB SEES THAT THE PLAYERS ARE ALICE, BOB, AND CONNIE
            if (pollresponse.playerStatusLines[0].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Connie") return false;

            //BOB SEES THE GAME NAME AND THAT PLAYERS ARE STILL ABLE TO JOIN
            if (pollresponse.gameName != gameIdentifier) return false;
            if (pollresponse.status != gameStatus.playersJoining) return false;

            //DAVE IS TOO LATE TO JOIN THE GAME
            response = ge.CloseForNewJoiners(playersAccessTokens["Alice"]);
            var br = response as boolResponse;
            if (br == null) return false;
            if (!br.okay) return false;
            response = ge.JoinGame(gameIdentifier, "Dave");
            pr = response as playerRegistration;
            if (pr == null) return false;
            if (pr.GetAccessToken() != null) return false;

            //ALICE(ADMIN) SHUFFLES THE PLAYERS INTO THE RUNNING ORDER
            List<string> runningOrder = new List<string> { "Bob", "Alice", "Connie" };
            response = ge.SetPlayersRunningOrder(playersAccessTokens["Alice"], runningOrder);

            //CONNIE SEES THE NEW RUNNING ORDER
            response = ge.Poll(playersAccessTokens["Connie"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Connie") return false;

            //BOB SEES THE NEW RUNNING ORDER
            response = ge.Poll(playersAccessTokens["Bob"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Connie") return false;

            //ALICE (ADMIN) SEES THE NEW RUNNING ORDER HERSELF
            response = ge.Poll(playersAccessTokens["Alice"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Connie") return false;

            //ALICE(ADMIN) CHANGES MIND AND RE-SHUFFLES THE PLAYERS INTO ANOTHER RUNNING ORDER
            List<string> amendedrunningOrder = new List<string> { "Bob", "Connie", "Alice" };
            response = ge.SetPlayersRunningOrder(playersAccessTokens["Alice"], amendedrunningOrder);

            //CONNIE SEES THE LATEST RUNNING ORDER
            response = ge.Poll(playersAccessTokens["Connie"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Connie") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Alice") return false;

            //BOB SEES THE LATEST RUNNING ORDER
            response = ge.Poll(playersAccessTokens["Bob"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.playerStatusLines.Count != 3) return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Connie") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Alice") return false;

            //ALICE (ADMIN) SETS THE GAME GOING
            //BOB SEES THAT THE GAME IS RUNNING
            response = ge.StartGame(playersAccessTokens["Alice"]);
            br = response as boolResponse;
            if (br == null) return false;
            if (!br.okay) return false;
            response = ge.Poll(playersAccessTokens["Bob"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.status != gameStatus.awaitingPlayerToClaimHandRank) return false;

            //AND HE SEES THAT THE GAME IS WAITING FOR HIM TO DECLARE A HAND
            if (pollresponse.awaitingActionFromPlayerName != "Bob") return false;

            //HIS HAND IS AJT99
            if (!playerHasHand("Bob", new pokerDiceHand("AJT99"), ge, playersAccessTokens)) return false;

            //HE DECLARES A LOWER HAND (QJT99  - I.E. NOT LIEING)
            //bca
            //CONNIE AND ALICE CAN SEE THAT IT IS CONNIES TURN
            //SHE MUST DECIDE WHETHER OR NOT TO ACCEPT THE HAND
            //EVERYONE CAN SEE BOB'S CLAIM FOR THE HAND
            ge.DeclareHand(playersAccessTokens["Bob"], new pokerDiceHand("QJT99"));
            response = ge.Poll(playersAccessTokens["Connie"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.status != gameStatus.awaitingPlayerDecisionAcceptOrCallLiar) return false;
            if (pollresponse.awaitingActionFromPlayerName != "Connie") return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Connie") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[0].getClaim() != new pokerDiceHand("99TJQ")) return false;
            if (pollresponse.playerStatusLines[1].getClaim() != null) return false;
            if (pollresponse.playerStatusLines[2].getClaim() != null) return false;
            response = ge.Poll(playersAccessTokens["Alice"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.status != gameStatus.awaitingPlayerDecisionAcceptOrCallLiar) return false;
            if (pollresponse.awaitingActionFromPlayerName != "Connie") return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Connie") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[0].getClaim() != new pokerDiceHand("99TJQ")) return false;
            if (pollresponse.playerStatusLines[1].getClaim() != null) return false;
            if (pollresponse.playerStatusLines[2].getClaim() != null) return false;

            //CONNIE DECIDES TO ACCEPT THE HAND
            //SHE SEES SHE GOT AJT99
            //SHE MUST DECIDE HOW MANY TO ROLL AGAIN
            ge.AcceptHand(playersAccessTokens["Connie"]);
            if (!playerHasHand("Connie", new pokerDiceHand("AJT99"), ge, playersAccessTokens)) return false;
            if (!playerSeesGameStatus("Connie", gameStatus.awaitingPlayerToChooseDiceToReRollOrNone, "Connie", ge, playersAccessTokens))
                return false;

            //BOB CANT SEE THE HAND ANYMORE
            response = ge.Poll(playersAccessTokens["Bob"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.HasHandToView()) return false;
            if (pollresponse.GetNamedPlayersHand() != null) return false;
            if (!playerHasHandOthersCantSee("Connie", new pokerDiceHand("AJT99"), ge, playersAccessTokens)) return false;


            //CONNIE DECIDES TO REROLL THE JACK AND THE TEN
            ge.ReRoll(playersAccessTokens["Connie"], "JT");

            //SHE GETS A JACK AGAIN AND A NINE
            pdrtm.EnqueueRoll(pokerDieFace.J);
            pdrtm.EnqueueRoll(pokerDieFace.N);

            //ALICE CAN SEE THAT CONNIE REROLLS 2 DICE
            //AND THAT CONNIE MUST NOW DECIDE A HAND RANK TO CLAIM
            response = ge.Poll(playersAccessTokens["Alice"]);
            pollresponse = response as pollResponse;
            if (pollresponse == null) return false;
            if (pollresponse.GetNamedPlayersHand() != null) return false;
            if (pollresponse.status != gameStatus.awaitingPlayerToClaimHandRank) return false;
            if (pollresponse.awaitingActionFromPlayerName != "Connie") return false;
            if (pollresponse.playerStatusLines[0].GetName() != "Bob") return false;
            if (pollresponse.playerStatusLines[1].GetName() != "Connie") return false;
            if (pollresponse.playerStatusLines[2].GetName() != "Alice") return false;
            if (pollresponse.playerStatusLines[0].GetRerollDiceCount() != null) return false;
            if (pollresponse.playerStatusLines[1].GetRerollDiceCount() != 2) return false;
            if (pollresponse.playerStatusLines[2].GetRerollDiceCount() != null) return false;

            //NEW HAND SEEN BY CONNIE IS AJ999
            if (!playerHasHandOthersCantSee("Connie", new pokerDiceHand("AJ999"), ge, playersAccessTokens)) return false;


            return true;

        }

    }
}
