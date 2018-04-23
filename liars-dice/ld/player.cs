﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class player :  IComparable<player>
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

        public string GetName()
        {
            return name;
        } 

        public void SetRunningOrder(int order)
        {
            runningOrder = order;
        }

        public int GetRunningOrder()
        {
            return runningOrder;
        }

        public static bool operator >(player lhs, player rhs)
        {
            return (lhs.GetRunningOrder() < rhs.GetRunningOrder());
        }

        public static bool operator <(player lhs, player rhs)
        {
            return (lhs.GetRunningOrder() > rhs.GetRunningOrder());
        }

        public int CompareTo(player that)
        {
            if (this.runningOrder > that.runningOrder) return 1;
            if (this.runningOrder < that.runningOrder) return -1;
            return 0;
        }

        private static int nextAccessTokenNumber = 1;
        private string identifier;
        private string name;
        private int runningOrder;
    }
}
