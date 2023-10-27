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
    public GameObject gameOver;

    private bool isCritical = false;
    
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
            Game.isBossDead[Game.bossId] = true;
            Game.currentScene = 0;
            SceneManager.LoadScene("Map");
        }
        if (Game.HP <= 0) {
            BattleMovement.paused = true;
            gameOver.SetActive(true);
        }
        if(Game.HP <= mHP/100*30)
            {
                if(!isCritical)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/UB_CritcalLife_Sound");
                    isCritical = true;
                }
            }
        else
        {
            isCritical = true;
        }
    }

    public void Restart(){
        Game.openedChests = null;
        Game.level = 0;
        Game.mapPosition = null;
        Game.boss = null;
        Game.isBossDead = null;
        Resources.metal = 0;
        Resources.oil = 0;
        Resources.gunpowder = 0;
        BattleMovement.paused = false;
        Game.currentScene = 0;
        SceneManager.LoadScene("Map");
    }
}