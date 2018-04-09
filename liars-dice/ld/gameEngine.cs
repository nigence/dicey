using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class gameEngine
    {
        public  gameEngine()
        {

        }

        public gameEngineReturnMessage StartNewGame()
        {
            newGameDetails returnMsg = new newGameDetails();
            return returnMsg;

        }
    }
}
