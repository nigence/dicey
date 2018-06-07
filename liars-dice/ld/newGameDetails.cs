using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class newGameDetails : gameEngineReturnMessage
    {
        public newGameDetails(string accessToken, string gameName)
        {
            token = accessToken;
            id = gameName;
        }

        public string GetAccessToken()
        {
            return token;
        }

        public string GetGameIdentifier()
        {
            return id;
        }

        private string id;
        private string token;

    }
}
