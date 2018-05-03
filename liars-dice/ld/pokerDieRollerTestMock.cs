using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld
{
    class pokerDieRollerTestMock : pokerDieRoller
    {
        public pokerDieRollerTestMock()
        {
            queuedFutureDieRolls = new System.Collections.Queue();
        }

        public pokerDieFace Roll(showAsEnum y)
        {
            pokerDieFace pdf = (pokerDieFace)queuedFutureDieRolls.Dequeue();
            return pdf;
        }

        public string Roll(showAsString y)
        {
            pokerDieFace pdf = Roll(showAsEnum.y);
            string roll = pokerDieFaceConversion.ToString(pdf);
            return roll;
        }

        public void EnqueueRoll(pokerDieFace rollLoad)
        {
            queuedFutureDieRolls.Enqueue(rollLoad);
        }

        private System.Collections.Queue queuedFutureDieRolls;
    }
}
