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
            Resources.metal += Game.boss.GetComponentInChildren<Boss>().givesMetal;
            Resources.oil += Game.boss.GetComponentInChildren<Boss>().givesOil;
            Resources.gunpowder += Game.boss.GetComponentInChildren<Boss>().givesGunpowder;
            Debug.Log("YOU WIN!!!");
            Game.isBossDead[Game.bossId] = true;
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