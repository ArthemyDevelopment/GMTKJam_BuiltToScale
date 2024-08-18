using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class GameCanvasController : SingletonManager<GameCanvasController>
{

    [SerializeField] private GameObject G_WinPanel;
    [SerializeField] private GameObject G_LosePanel;

    private void OnEnable()
    {
        G_WinPanel.SetActive(false);
        G_LosePanel.SetActive(false);
    }


    public void StartLevel()
    {
        LevelManager.current.StarLevel();
    }

    public void GameOver()
    {
        G_LosePanel.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToLevelSelection()
    {
        SceneManager.LoadScene((int)Scenes.LevelSelection);
    }

    public void Win()
    {
        G_WinPanel.SetActive(true);
    }
}
