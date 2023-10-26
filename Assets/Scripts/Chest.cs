using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chest : MonoBehaviour {
    public int givesMetal;
    public int givesOil;
    public int givesGunpowder;
    public int chestId;

    void Start(){
        if(Game.openedChests == null) Game.openedChests = Enumerable.Repeat(new List<int>(){}, 4).ToArray();
        if(Game.openedChests[Game.shipwreckId].Contains(chestId)) gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Resources.metal += givesMetal;
            Resources.oil += givesOil;
            Resources.gunpowder += givesGunpowder;
            Game.openedChests[Game.shipwreckId].Add(chestId);
            gameObject.SetActive(false);
        }
    }
}
