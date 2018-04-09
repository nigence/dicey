using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class newGameDetails : gameEngineReturnMessage
    {
        public newGameDetails()
        {

        }

        public string GetAccessToken()
        {
            string accessToken = "access-token-" + nextAccessTokenNumber.ToString();
            nextAccessTokenNumber++;
            return accessToken;
        }

        public string GetGameIdentifier()
        {
            string id = "game-identifier-" + nextIdentifierNumber.ToString();
            nextIdentifierNumber++;
            return id;
        }

        private static int nextAccessTokenNumber = 1;
        private static int nextIdentifierNumber = 1;

    }
}
