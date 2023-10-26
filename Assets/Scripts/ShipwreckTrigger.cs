using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipwreckTrigger : MonoBehaviour
{
    public Transform exitPoint;
    public GameObject shipwreck;
    public int shipwreckId;
    void Start() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Game.currentScene = "Shipwreck";
            Game.shipwreckId = shipwreckId;
            Game.mapPosition = exitPoint.position;
            Game.shipwreck = shipwreck;
            SceneManager.LoadScene("Shipwreck");
        }
    }
}
