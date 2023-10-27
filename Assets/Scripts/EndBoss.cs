using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBoss : MonoBehaviour
{
    public Boss boss;
    public float damage;
    public Vector3 back = new Vector3(10,0,0);
    public float minDistance = 7;
    public float minDistanceOff = 2;
    bool tookDmg = false;
    void Update(){
        if(Vector3.Distance(transform.position,BattleManager.player.transform.position)<minDistance){
            boss.offsetToPlayer = back;
            Debug.Log(tookDmg);
            if(!tookDmg) 
            {
                Game.HP -= damage;
                FMODUnity.RuntimeManager.PlayOneShot("event:/ML_Attack_Sound");
                FMODUnity.RuntimeManager.PlayOneShot("event:/ML_Roar_Sound");
            }
            tookDmg = true;            
        }
        if(Vector3.Distance(transform.position,BattleManager.player.transform.position+back)<minDistance-minDistanceOff) {
            tookDmg = false;
            boss.offsetToPlayer = new Vector3(0,0,0);
        }
    }
}
