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
            bool allOkay = false;
            for ( int i = 0; i < 1; i++ )
            {
                if (!PokerDiceHandEqualityOperatorTestPassed()) break;
                if (!permutationsCalculatorTestPassed()) break;
                allOkay = true;
            }
            if(!allOkay)
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

        private bool permutationsCalculatorTestPassed()
        {
            string expectedPermutationsTable
                =
            "|[99999, 1]|[A9999, 5]|[AA999, 10]|[AAA99, 10]|[AAAA9, 5]|[AAAAA, 1]|[AAAAJ, 5]|[AAAAK, 5]|[AAAAQ, 5]|[AAAAT, 5]|[AAAJ9, 20]|[AAAJJ, 10]|[AAAJT, 20]|[AAAK9, 20]|[AAAKJ, 20]|[AAAKK, 10]|[AAAKQ, 20]|[AAAKT, 20]|[AAAQ9, 20]|[AAAQJ, 20]|[AAAQQ, 10]|[AAAQT, 20]|[AAAT9, 20]|[AAATT, 10]|[AAJ99, 30]|[AAJJ9, 30]|[AAJJJ, 10]|[AAJJT, 30]|[AAJT9, 60]|[AAJTT, 30]|[AAK99, 30]|[AAKJ9, 60]|[AAKJJ, 30]|[AAKJT, 60]|[AAKK9, 30]|[AAKKJ, 30]|[AAKKK, 10]|[AAKKQ, 30]|[AAKKT, 30]|[AAKQ9, 60]|[AAKQJ, 60]|[AAKQQ, 30]|[AAKQT, 60]|[AAKT9, 60]|[AAKTT, 30]|[AAQ99, 30]|[AAQJ9, 60]|[AAQJJ, 30]|[AAQJT, 60]|[AAQQ9, 30]|[AAQQJ, 30]|[AAQQQ, 10]|[AAQQT, 30]|[AAQT9, 60]|[AAQTT, 30]|[AAT99, 30]|[AATT9, 30]|[AATTT, 10]|[AJ999, 20]|[AJJ99, 30]|[AJJJ9, 20]|[AJJJJ, 5]|[AJJJT, 20]|[AJJT9, 60]|[AJJTT, 30]|[AJT99, 60]|[AJTT9, 60]|[AJTTT, 20]|[AK999, 20]|[AKJ99, 60]|[AKJJ9, 60]|[AKJJJ, 20]|[AKJJT, 60]|[AKJT9, 120]|[AKJTT, 60]|[AKK99, 30]|[AKKJ9, 60]|[AKKJJ, 30]|[AKKJT, 60]|[AKKK9, 20]|[AKKKJ, 20]|[AKKKK, 5]|[AKKKQ, 20]|[AKKKT, 20]|[AKKQ9, 60]|[AKKQJ, 60]|[AKKQQ, 30]|[AKKQT, 60]|[AKKT9, 60]|[AKKTT, 30]|[AKQ99, 60]|[AKQJ9, 120]|[AKQJJ, 60]|[AKQJT, 120]|[AKQQ9, 60]|[AKQQJ, 60]|[AKQQQ, 20]|[AKQQT, 60]|[AKQT9, 120]|[AKQTT, 60]|[AKT99, 60]|[AKTT9, 60]|[AKTTT, 20]|[AQ999, 20]|[AQJ99, 60]|[AQJJ9, 60]|[AQJJJ, 20]|[AQJJT, 60]|[AQJT9, 120]|[AQJTT, 60]|[AQQ99, 30]|[AQQJ9, 60]|[AQQJJ, 30]|[AQQJT, 60]|[AQQQ9, 20]|[AQQQJ, 20]|[AQQQQ, 5]|[AQQQT, 20]|[AQQT9, 60]|[AQQTT, 30]|[AQT99, 60]|[AQTT9, 60]|[AQTTT, 20]|[AT999, 20]|[ATT99, 30]|[ATTT9, 20]|[ATTTT, 5]|[J9999, 5]|[JJ999, 10]|[JJJ99, 10]|[JJJJ9, 5]|[JJJJJ, 1]|[JJJJT, 5]|[JJJT9, 20]|[JJJTT, 10]|[JJT99, 30]|[JJTT9, 30]|[JJTTT, 10]|[JT999, 20]|[JTT99, 30]|[JTTT9, 20]|[JTTTT, 5]|[K9999, 5]|[KJ999, 20]|[KJJ99, 30]|[KJJJ9, 20]|[KJJJJ, 5]|[KJJJT, 20]|[KJJT9, 60]|[KJJTT, 30]|[KJT99, 60]|[KJTT9, 60]|[KJTTT, 20]|[KK999, 10]|[KKJ99, 30]|[KKJJ9, 30]|[KKJJJ, 10]|[KKJJT, 30]|[KKJT9, 60]|[KKJTT, 30]|[KKK99, 10]|[KKKJ9, 20]|[KKKJJ, 10]|[KKKJT, 20]|[KKKK9, 5]|[KKKKJ, 5]|[KKKKK, 1]|[KKKKQ, 5]|[KKKKT, 5]|[KKKQ9, 20]|[KKKQJ, 20]|[KKKQQ, 10]|[KKKQT, 20]|[KKKT9, 20]|[KKKTT, 10]|[KKQ99, 30]|[KKQJ9, 60]|[KKQJJ, 30]|[KKQJT, 60]|[KKQQ9, 30]|[KKQQJ, 30]|[KKQQQ, 10]|[KKQQT, 30]|[KKQT9, 60]|[KKQTT, 30]|[KKT99, 30]|[KKTT9, 30]|[KKTTT, 10]|[KQ999, 20]|[KQJ99, 60]|[KQJJ9, 60]|[KQJJJ, 20]|[KQJJT, 60]|[KQJT9, 120]|[KQJTT, 60]|[KQQ99, 30]|[KQQJ9, 60]|[KQQJJ, 30]|[KQQJT, 60]|[KQQQ9, 20]|[KQQQJ, 20]|[KQQQQ, 5]|[KQQQT, 20]|[KQQT9, 60]|[KQQTT, 30]|[KQT99, 60]|[KQTT9, 60]|[KQTTT, 20]|[KT999, 20]|[KTT99, 30]|[KTTT9, 20]|[KTTTT, 5]|[Q9999, 5]|[QJ999, 20]|[QJJ99, 30]|[QJJJ9, 20]|[QJJJJ, 5]|[QJJJT, 20]|[QJJT9, 60]|[QJJTT, 30]|[QJT99, 60]|[QJTT9, 60]|[QJTTT, 20]|[QQ999, 10]|[QQJ99, 30]|[QQJJ9, 30]|[QQJJJ, 10]|[QQJJT, 30]|[QQJT9, 60]|[QQJTT, 30]|[QQQ99, 10]|[QQQJ9, 20]|[QQQJJ, 10]|[QQQJT, 20]|[QQQQ9, 5]|[QQQQJ, 5]|[QQQQQ, 1]|[QQQQT, 5]|[QQQT9, 20]|[QQQTT, 10]|[QQT99, 30]|[QQTT9, 30]|[QQTTT, 10]|[QT999, 20]|[QTT99, 30]|[QTTT9, 20]|[QTTTT, 5]|[T9999, 5]|[TT999, 10]|[TTT99, 10]|[TTTT9, 5]|[TTTTT, 1]|";
            permutationsCalculator pc = new permutationsCalculator();
            string pt = pc.getPermutationTable();
            return (pt == expectedPermutationsTable);
        }

        /*
HAND RANK TEST DATA
---- ---- ---- ----
6		[AAAAA, 1]-- FIVE OF A KIND
167		[KKKKK, 1]
237		[QQQQQ, 1]
132		[JJJJJ, 1]
252		[TTTTT, 1]
1		[99999, 1]
8		[AAAAK, 5]-- FOUR OF A KIND
9		[AAAAQ, 5]
7 		[AAAAJ, 5]
10		[AAAAT, 5]
5		[AAAA9, 5]
82		[AKKKK, 5]
168		[KKKKQ, 5]
166		[KKKKJ, 5]
169		[KKKKT, 5]
165		[KKKK9, 5]
117		[AQQQQ, 5]
202		[KQQQQ, 5]
236		[QQQQJ, 5]
238		[QQQQT, 5]
235		[QQQQ9, 5]
62		[AJJJJ, 5]
147		[KJJJJ, 5]
217		[QJJJJ, 5]
133		[JJJJT, 5]
131		[JJJJ9, 5]
127		[ATTTT, 5]
212		[KTTTT, 5]
247		[QTTTT, 5]
142		[JTTTT, 5]
251		[TTTT9, 5]
2		[A9999, 5]
143		[K9999, 5]
213		[Q9999, 5]
128		[J9999, 5]
248		[T9999, 5]
16		[AAAKK, 10] -- FULL HOUSE
21		[AAAQQ, 10]
12		[AAAJJ, 10]
24		[AAATT, 10]
4		[AAA99, 10]
37		[AAKKK, 10]
172		[KKKQQ, 10]
163		[KKKJJ, 10]
175		[KKKTT, 10]
161		[KKK99, 10]
52		[AAQQQ, 10]
182		[KKQQQ, 10]
233		[QQQJJ, 10]
240		[QQQTT, 10]
231		[QQQ99, 10]
27		[AAJJJ, 10]
157		[KKJJJ, 10]
227		[QQJJJ, 10]
135		[JJJTT, 10]
130		[JJJ99, 10]
58		[AATTT, 10]
188		[KKTTT, 10]
243		[QQTTT, 10]
138		[JJTTT, 10]
250		[TTT99, 10]
3		[AA999, 10]
154		[KK999, 10]
224		[QQ999, 10]
129		[JJ999, 10]
249		[TT999, 10]
94		[AKQJT, 120] -- STRAIGHT
194		[KQJT9, 120]
17		[AAAKQ, 20] -- THREE OF A KIND
15		[AAAKJ, 20]
18		[AAAKT, 20]
14		[AAAK9, 20]
20		[AAAQJ, 20]
22		[AAAQT, 20]
19		[AAAQ9, 20]
13		[AAAJT, 20]
11		[AAAJ9, 20]
23		[AAAT9, 20]
83		[AKKKQ, 20]
81		[AKKKJ, 20]
84		[AKKKT, 20]
80		[AKKK9, 20]
171		[KKKQJ, 20]
173		[KKKQT, 20]
170		[KKKQ9, 20]
164		[KKKJT, 20]
162		[KKKJ9, 20]
174		[KKKT9, 20]
xxx		[AKQQQ, 20]
116		[AQQQJ, 20]
118		[AQQQT, 20]
115		[AQQQ9, 20]
201		[KQQQJ, 20]
203		[KQQQT, 20]
200		[KQQQ9, 20]
234		[QQQJT, 20]
232		[QQQJ9, 20]
239		[QQQT9, 20]
72		[AKJJJ, 20]
107		[AQJJJ, 20]
63		[AJJJT, 20]
61		[AJJJ9, 20]
192		[KQJJJ, 20]
148		[KJJJT, 20]
146		[KJJJ9, 20]
218		[QJJJT, 20]
216		[QJJJ9, 20]
134		[JJJT9, 20]
xxx		[AKTTT, 20]
123		[AQTTT, 20]
68		[AJTTT, 20]
126		[ATTT9, 20]
208		[KQTTT, 20]
153		[KJTTT, 20]
211		[KTTT9, 20]
223		[QJTTT, 20]
246		[QTTT9, 20]
141		[JTTT9, 20]
69		[AK999, 20]
xxx		[AQ999, 20]
59		[AJ999, 20]
124		[AT999, 20]
189		[KQ999, 20]
144		[KJ999, 20]
209		[KT999, 20]
214		[QJ999, 20]
244		[QT999, 20]
139		[JT999, 20]
38		[AAKKQ, 30] -- TWO PAIRS
36		[AAKKJ, 30]
39		[AAKKT, 30]
35		[AAKK9, 30]
42		[AAKQQ, 30]
51		[AAQQJ, 30]
53		[AAQQT, 30]
50		[AAQQ9, 30]
33		[AAKJJ, 30]
48		[AAQJJ, 30]
28		[AAJJT, 30]
26		[AAJJ9, 30]
45		[AAKTT, 30]
55		[AAQTT, 30]
30		[AAJTT, 30]
57		[AATT9, 30]
31		[AAK99, 30]
46		[AAQ99, 30]
25		[AAJ99, 30]
56		[AAT99, 30]
87		[AKKQQ, 30]
181		[KKQQJ, 30]
183		[KKQQT, 30]
180		[KKQQ9, 30]
78		[AKKJJ, 30]
178		[KKQJJ, 30]
158		[KKJJT, 30]
156		[KKJJ9, 30]
90		[AKKTT, 30]
185		[KKQTT, 30]
160		[KKJTT, 30]
187		[KKTT9, 30]
76		[AKK99, 30]
176		[KKQ99, 30]
155		[KKJ99, 30]
186		[KKT99, 30]
113		[AQQJJ, 30]
198		[KQQJJ, 30]
228		[QQJJT, 30]
226		[QQJJ9, 30]
120		[AQQTT, 30]
205		[KQQTT, 30]
230		[QQJTT, 30]
242		[QQTT9, 30]
111		[AQQ99, 30]
196		[KQQ99, 30]
225		[QQJ99, 30]
241		[QQT99, 30]
65		[AJJTT, 30]
150		[KJJTT, 30]
220		[QJJTT, 30]
137		[JJTT9, 30]
60		[AJJ99, 30]
145		[KJJ99, 30]
215		[QJJ99, 30]
136		[JJT99, 30]
125		[ATT99, 30]
210		[KTT99, 30]
245		[QTT99, 30]
140		[JTT99, 30]
41		[AAKQJ, 60] -- PAIR
43		[AAKQT, 60]
40		[AAKQ9, 60]
34		[AAKJT, 60]
32		[AAKJ9, 60]
44		[AAKT9, 60]
49		[AAQJT, 60]
47		[AAQJ9, 60]
54		[AAQT9, 60]
29		[AAJT9, 60]
86		[AKKQJ, 60]
88		[AKKQT, 60]
85		[AKKQ9, 60]
79		[AKKJT, 60]
77		[AKKJ9, 60]
89		[AKKT9, 60]
179		[KKQJT, 60]
177		[KKQJ9, 60]
184		[KKQT9, 60]
159		[KKJT9, 60]
96		[AKQQJ, 60]
98		[AKQQT, 60]
95		[AKQQ9, 60]
114		[AQQJT, 60]
112		[AQQJ9, 60]
119		[AQQT9, 60]
199		[KQQJT, 60]
197		[KQQJ9, 60]
204		[KQQT9, 60]
229		[QQJT9, 60]
93		[AKQJJ, 60]
73		[AKJJT, 60]
71		[AKJJ9, 60]
108		[AQJJT, 60]
106		[AQJJ9, 60]
64		[AJJT9, 60]
193		[KQJJT, 60]
191		[KQJJ9, 60]
149		[KJJT9, 60]
219		[QJJT9, 60]
100		[AKQTT, 60]
75		[AKJTT, 60]
102		[AKTT9, 60]
110		[AQJTT, 60]
122		[AQTT9, 60]
67		[AJTT9, 60]
195		[KQJTT, 60]
207		[KQTT9, 60]
152		[KJTT9, 60]
222		[QJTT9, 60]
91		[AKQ99, 60]
70		[AKJ99, 60]
101		[AKT99, 60]
105		[AQJ99, 60]
121		[AQT99, 60]
66		[AJT99, 60]
190		[KQJ99, 60]
206		[KQT99, 60]
151		[KJT99, 60]
221		[QJT99, 60]
92		[AKQJ9, 120] --ACE HIGH
99		[AKQT9, 120]
74		[AKJT9, 120]
109		[AQJT9, 120]
        */
    }
}
