using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipwreckExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("EXIT");
        if(other.tag == "Player") {
            SceneManager.LoadScene("Map");
            Game.currentScene = 0;
        }
    }
}
