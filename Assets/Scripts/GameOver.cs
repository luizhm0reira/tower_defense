using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text roundsText;
    public SceneFader scenefader;

    public string menuSceneName = "MainMenu";

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        //SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
        scenefader.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        Debug.Log("Go to menu");
        scenefader.FadeTo(menuSceneName);
    }




}
