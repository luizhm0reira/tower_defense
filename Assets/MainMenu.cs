﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "MainLevel";
    public SceneFader scenefader;

    public void Play()
    {
        //SceneManager.LoadScene(levelToLoad);
        //FindObjectsOfType<SceneFader>().FadeTo(levelToLoad);
        scenefader.FadeTo(levelToLoad);

    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }
}
