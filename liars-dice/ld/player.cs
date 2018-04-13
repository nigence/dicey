using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class player
    {
        public player(string playerName)
        {
            name = playerName;
            string accessToken = "access-token-" + nextAccessTokenNumber.ToString();
            identifier = accessToken;
            nextAccessTokenNumber++;
        }

        public string GetId()
        {
            return identifier;
        }

        private static int nextAccessTokenNumber = 1;
        private string identifier;
        private string name;

    }
}
