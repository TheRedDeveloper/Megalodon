using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public int[] _maxHP = {10, 22, 48};
    public static int[] maxHP = {10, 22, 48};
    public GameObject _player;
    public static GameObject player;
    
    int mHP;
    void Awake() {
        maxHP = _maxHP;
        player = _player;
        Game.boss = Instantiate(Game.boss, transform.position, transform.rotation);
        mHP = maxHP[Game.level];
        Game.HP = mHP;
    }

    void Update()
    {
        if (Game.boss.GetComponentInChildren<Boss>().HP <= 0) {
            Resources.metal += 2;
            Resources.oil += 3;
            Resources.gunpowder += 10;
            Debug.Log("YOU WIN!!!");
            Game.currentScene = "Map";
            SceneManager.LoadScene("Map");
        }
        if (Game.HP <= 0) {
            Debug.Log("YOU LOOSE!!!");
            Game.currentScene = "Map";
            SceneManager.LoadScene("Map");
        }
    }
}
