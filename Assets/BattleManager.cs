using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    float i = 0;
    void Start()
    {
        i = 0;
        Instantiate(Game.boss, transform.position, transform.rotation);
    }

    void Update()
    {
        i += Time.deltaTime;
        if (i>5) {
            Game.currentScene = "Map";
            SceneManager.LoadScene("Map");
        }
    }
}
