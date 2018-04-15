using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class playerStatusLine
    {
        public playerStatusLine(string name)
        {
            mName = name;
        }

        public string GetName()
        {
            return mName;
        }

        string mName;
    }
}
