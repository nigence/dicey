using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class newGameDetails : gameEngineReturnMessage
    {
        public newGameDetails( bool gameCreatedOkay, string accessToken, string gameName)
        {
            ok = gameCreatedOkay;
            token = accessToken;
            id = gameName;
        }

        public string GetAccessToken()
        {
            if (!ok)
                return null;
            return token;
        }

        public string GetGameIdentifier()
        {
            if (!ok)
                return null;
            return id;
        }

        private bool ok;
        private string id;
        private string token;

    }
}
