using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowRessources : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text metal;
    public TMP_Text oil;
    public TMP_Text gunpowder;

    public static int[] requiredMetal = {20, 40, 50};
    public static int[] requiredOil = {2, 5, 10};
    public static int[] requiredGunpowder = {10, 30, 60};

    void Update()
    {
        level.text = (Game.level+1).ToString();
        metal.text = Resources.metal.ToString() + " / " + requiredMetal[Game.level].ToString();
        oil.text = Resources.oil.ToString() + " / " + requiredOil[Game.level].ToString();
        gunpowder.text = Resources.gunpowder.ToString() + " / " + requiredGunpowder[Game.level].ToString();
    }
}
