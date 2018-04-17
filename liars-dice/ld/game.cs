using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class game
    {
        public game(player administrator)
        {
            string id = "game-identifier-" + nextIdentifierNumber.ToString();
            identifier = id;
            nextIdentifierNumber++;
            playersList = new List<player>(); 
            playersList.Add(administrator);
            mAdministrator = administrator;
            status = gameStatus.playersJoining;
        }

        public string GetId()
        {
            return identifier;
        }

        public gameStatus GetStatus()
        {
            return status;
        }

        public void Join(player newJoiner)
        {
            playersList.Add(newJoiner);
        }

        public void CloseToNewJoiners()
        {
            status = gameStatus.administratorShufflingPlayers;
        }

        public bool hasPlayerId(string Id)
        {
            return true;
        }

        public bool hasAdministrator(string playerAccessToken)
        {
            return (mAdministrator.GetId() == playerAccessToken);
        }

        public List<string> GetPlayersNames()
        {
            List<string> names = new List<string>();
            foreach( var p in playersList )
                names.Add(p.GetName());
            return names;
        }

        private static int nextIdentifierNumber = 1;
        private string identifier;
        private gameStatus status;
        private List<player> playersList; //includes administrator
        private player mAdministrator;
    }
}
