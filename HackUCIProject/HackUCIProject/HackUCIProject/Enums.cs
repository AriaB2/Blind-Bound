using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackUCIProject
{
    public enum ScreenState
    {
        none,
        startMenu,
        levelSelection,
        game,
        levelComplete,
        option
        //add defeat screen
    }

    public enum GameState
    {
        none,
        start,
        playing,
        pause,
        levelComplete,
        //add defeat and timer later (the quicker you finish the game, the 
    }
}
