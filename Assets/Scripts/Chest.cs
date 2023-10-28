using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FMODUnity;

public class Chest : MonoBehaviour {
    public int givesMetal;
    public int givesOil;
    public int givesGunpowder;
    public Collider2D collider;
    public SpriteRenderer sr;
    public Sprite openedChest;
    public int chestId;

    private FMOD.Studio.EventInstance chestTone;

    void Start(){
        chestTone = FMODUnity.RuntimeManager.CreateInstance("event:/Chest_Tone");
        chestTone.start();
        if(Game.openedChests == null) Game.openedChests = new List<int>[]{new List<int>(){}, new List<int>(){}};
        if(Game.openedChests[Game.shipwreckId].Contains(chestId)){
            chestTone.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            chestTone.release();
            collider.enabled = false;
            sr.sprite = openedChest;
            //gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Resources.metal += givesMetal;
            Resources.oil += givesOil;
            Resources.gunpowder += givesGunpowder;
            
            Game.openedChests[Game.shipwreckId].Add(chestId);
            collider.enabled = false;
            sr.sprite = openedChest;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Open_Chest");
            chestTone.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            chestTone.release();
        }
    }
}
