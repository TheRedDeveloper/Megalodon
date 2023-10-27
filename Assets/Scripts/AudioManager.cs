using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour{
    
    private FMOD.Studio.EventInstance ambience;
    private FMOD.Studio.EventInstance music;

    private bool audioPlaying = false;

    private int parameterValue;
    private int playerLevel;

    private static bool isLoaded = false;
    
    void Awake()
    {
        if(!isLoaded) {
            DontDestroyOnLoad(gameObject);
            isLoaded = true;
        } else {
            Destroy(gameObject);
        }  
    }

    void Start(){
        StartCoroutine(StartAsync());
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    IEnumerator StartAsync(){
        while(!FMODUnity.RuntimeManager.HaveAllBanksLoaded) yield return null;
        ambience = FMODUnity.RuntimeManager.CreateInstance("event:/BG_Loop");
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        if(!audioPlaying){
            ambience.start();
            music.start();
            audioPlaying = true;
        }
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode){
        parameterValue = Game.currentScene;
        if(parameterValue == 2 && Game.bossId == 6) parameterValue = 3;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("LevelState", parameterValue);
        playerLevel = Game.level;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("PlayerLevel", playerLevel);
        SceneManager.sceneLoaded += OnSceneLoad;
    }
}
