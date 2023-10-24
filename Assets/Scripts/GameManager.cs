using UnityEngine;

public static class Game
{
    public static string currentScene { get; set; }
    public static Vector3? mapPosition { get; set; }
    public static GameObject boss { get; set; }
    public static float HP { get; set; }
    public static int level { get; set; }
    // public static float maxHP { get {return new int[]{100, 220, 480}[Game.level];} } // TODO: Umbedingt erweitern
}

public static class Resources {
    public static int metal { get; set; }
    public static int oil { get; set; }
    public static int gunpowder { get; set; }
    // public static int requiredMetal { get { return new int[]{20, 40, 50}[Game.level]; } } // TODO: Umbedingt erweitern
    // public static int requiredGunpowder { get { return new int[]{10, 30, 60}[Game.level]; } } // TODO: Umbedingt erweitern
    // public static int requiredOil { get { return new int[]{2, 5, 10}[Game.level]; } } // TODO: Umbedingt erweitern
}