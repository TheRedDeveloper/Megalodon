using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipwreckTrigger : MonoBehaviour
{
    public Transform exitPoint;
    public int shipwreckId;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Game.currentScene = 1;
            Game.shipwreckId = shipwreckId;
            Game.mapPosition = exitPoint.position;
            SceneManager.LoadScene("Shipwreck"+shipwreckId);
        }
    }
}
