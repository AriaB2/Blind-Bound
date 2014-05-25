using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackUCIProject
{
    public static class Global
    {
        public static ScreenState CurrentScreen;

        public static Color[] MainColors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };

        public static List<SpriteFont> Fonts;
    }
}
