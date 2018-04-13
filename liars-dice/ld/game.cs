﻿using System;
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
        }

        public string GetId()
        {
            return identifier;
        }

        public void Join(player newJoiner)
        {
            playersList.Add(newJoiner);
        }

        public bool hasPlayerId(string Id)
        {
            return true;
        }

        private static int nextIdentifierNumber = 1;
        private string identifier;
        private List<player> playersList;

    }
}