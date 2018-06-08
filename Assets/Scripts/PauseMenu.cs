using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;
    public SceneFader scenefader;
    public string menuSceneName = "MainMenu";

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;            
        } else
        {
            Time.timeScale = 1f; 
        }
    }
    public void Retry()
    {
        Toggle();
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        //Debug.Log("Go to Menu");
        Toggle();
        scenefader.FadeTo(menuSceneName);
    }
}
