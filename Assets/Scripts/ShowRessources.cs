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

    public static int[] requiredMetal = {5, 11, 13, 100};
    public static int[] requiredOil = {6, 12, 15, 100};
    public static int[] requiredGunpowder = {7, 13, 17, 100};

    void Start(){
        //Game.level = 2;
    }

    void Update()
    {
        level.text = (Game.level+1).ToString();
        if(Game.level < 2){
            metal.text = Resources.metal.ToString() + " / " + requiredMetal[Game.level].ToString();
            oil.text = Resources.oil.ToString() + " / " + requiredOil[Game.level].ToString();
            gunpowder.text = Resources.gunpowder.ToString() + " / " + requiredGunpowder[Game.level].ToString();
            if(Resources.metal>=requiredMetal[Game.level] && Resources.oil>=requiredOil[Game.level] && Resources.gunpowder>=requiredGunpowder[Game.level]) {
                Game.level += 1;
                Resources.metal = 0;
                Resources.oil = 0;
                Resources.gunpowder = 0;
            }
        } else {
            metal.text = Resources.metal.ToString();
            oil.text = Resources.oil.ToString();
            gunpowder.text = Resources.gunpowder.ToString();
        }
    }
}
