using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackUCIProject
{
    public interface ITriggerable
    {
        bool Triggered { get; }

        void Trigger();
    }
}
