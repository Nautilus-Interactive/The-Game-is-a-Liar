using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game_Variables
{
    public static bool paused = false;
    
    public static void start_game() {
        resume_game();
    }

    public static void pause_game() {
        Time.timeScale = 0;
        paused = true;
    }

    public static void resume_game() {
        Time.timeScale = 1;
        paused = false;
    }
}
