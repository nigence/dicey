using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class playerRegistration : gameEngineReturnMessage
    {
        public playerRegistration(bool playerAddedOkay, string playersAccessToken)
        {
            ok = playerAddedOkay;
            token = playersAccessToken;
        }

        public string GetAccessToken()
        {
            if (!ok)
                return null;
            return token;
        }

        private bool ok;
        private string token;
    }
}
