using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleTrigger : MonoBehaviour
{
    public Transform exitPoint;
    public GameObject boss;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Game.currentScene = "Battle";
            Game.mapPosition = exitPoint.position;
            Game.boss = boss;
            SceneManager.LoadScene("Battle");
        }
    }
}
