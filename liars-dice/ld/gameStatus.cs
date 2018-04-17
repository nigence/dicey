using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    enum gameStatus
    {
        playersJoining,
        administratorShufflingPlayers,
        paused,
        awaitingPlayerDecisionAcceptOrCallLiar,
        awaitingPlayerToChooseDiceToReRollOrNone,
        awaitingPlayerToClaimHandRank,
        endedWithNoWinner,
        endedWithWinner
    }
}
