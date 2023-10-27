using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Game {
    public static int currentScene { get; set; }
    public static Vector3? mapPosition { get; set; }
    public static GameObject boss { get; set; }
    public static float HP { get; set; }
    public static int level { get; set; }
    public static bool[] isBossDead { get; set; }
    public static int bossId { get; set; }
    public static int shipwreckId { get; set; }
    public static List<int>[] openedChests { get; set; }
}

public static class Resources {
    public static int metal { get; set; }
    public static int oil { get; set; }
    public static int gunpowder { get; set; }
}