using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackUCIProject
{
    public class Door : BaseReciever
    {
        public override void Trigger()
        {
            base.Trigger();
        }

        public override void Draw()
        {
            if (!_triggered)
            {
                base.Draw();
            }
        }
    }
}
