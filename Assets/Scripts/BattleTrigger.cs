using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleTrigger : MonoBehaviour
{
    public string sceneName = "Battle";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") SceneManager.LoadScene(sceneName);
    }
}
