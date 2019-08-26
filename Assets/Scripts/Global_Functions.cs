using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global_Functions
{
    private static List<GameObject> inventory = new List<GameObject>();

    public static void start_game() {
        resume_game();
    }

    public static void pause_game() {
        Time.timeScale = 0;
    }

    public static void resume_game() {
        Time.timeScale = 1;
    }

    public static void add_inventory(GameObject new_object) {
        inventory.Add(new_object);
    }
}
