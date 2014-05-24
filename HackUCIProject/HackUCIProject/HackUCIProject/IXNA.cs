using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public interface IXNA
    {
        void Update(GameTime gameTime);
        void Draw();
    }
}
