using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleTrigger : MonoBehaviour
{
    public Transform exitPoint;
    public GameObject boss;
    public int bossId;
    void Start(){
        if(Game.isBossDead == null) Game.isBossDead = new bool[7]{false,false,false,false,false,false,false};
        if(Game.isBossDead[bossId]) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Game.currentScene = "Battle";
            Game.bossId = bossId;
            Game.mapPosition = exitPoint.position;
            Game.boss = boss;
            SceneManager.LoadScene("Battle");
        }
    }
}
