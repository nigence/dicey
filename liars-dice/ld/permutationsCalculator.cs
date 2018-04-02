using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class permutationsCalculator
    {
        public permutationsCalculator()
        {
            const int diceCount = 5;
            diceFaceTicker[]  tickerArray = new diceFaceTicker[diceCount];
            for(int i = 0; i < diceCount; i++)
                tickerArray[i] = new diceFaceTicker();
            for ( int j = diceCount-1; j>=1; j-- )
                tickerArray[j - 1].AddNeighbour(tickerArray[j]);           
            do
            {
                pokerDiceHand pdh = new pokerDiceHand(tickerArray[0].GetString());
                string diceFacesOrderedByRank = pdh.getFacesOrderedByRank();
                if (duplicatesCountTable.ContainsKey(diceFacesOrderedByRank))
                {
                    int oldCount = duplicatesCountTable[diceFacesOrderedByRank];
                    duplicatesCountTable[diceFacesOrderedByRank] = oldCount + 1;
                }
                else
                {
                    duplicatesCountTable.Add(diceFacesOrderedByRank, 1);
                }
                tickerArray[0].Tick();
            }
            while (tickerArray[diceCount-1].hasOverflowed() == false );

            int debugNumberEntriesInDuplicatesCountTable = duplicatesCountTable.Count;
            this.permutationTable = "|";
            foreach (var pair in duplicatesCountTable)
            {
                this.permutationTable += pair.ToString() + "|";
            }
        }

        public string getPermutationTable()
        {
            return this.permutationTable;
        }

        string permutationTable = "";
        SortedDictionary<string, int> duplicatesCountTable =
            new SortedDictionary<string, int>();


        private class diceFaceTicker
        {
            public diceFaceTicker()
            {
                this.overflowed = false;
            }

            public bool hasOverflowed()
            {
                return this.overflowed;
            }

            public void AddNeighbour( diceFaceTicker n )
            {
                this.neighbour = n;
            }

            public string GetString()
            {
                string s = "";
                if(this.neighbour !=  null)
                    s = this.neighbour.GetString();
                s += face;
                return s;
            }

            public void Tick()
            {
                switch(face)
                {
                    case '9': face = 'T'; break;
                    case 'T': face = 'J'; break;
                    case 'J': face = 'Q'; break;
                    case 'Q': face = 'K'; break;
                    case 'K': face = 'A'; break;
                    case 'A':
                        { face = '9';
                            if(this.neighbour != null)
                                this.neighbour.Tick();
                            overflowed = true;
                            break;
                        }
                }
            }

            private char face = '9';
            private diceFaceTicker neighbour;
            private bool overflowed;
        }
    }
}
