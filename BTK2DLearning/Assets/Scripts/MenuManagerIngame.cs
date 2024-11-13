using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerIngame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen, winScreen, loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        GameManager.instance.isPaused = true;
        Time.timeScale = 0;
        FindObjectOfType<ButtonSoundAssigner>().AddButtonSound();
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ResumeButton()
    {
        GameManager.instance.isPaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
        GameManager.instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.instance.SaveData();
        SceneManager.LoadScene(0);
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ShowWinScreen()
    {
        FindObjectOfType<ButtonSoundAssigner>().AddButtonSound();
        winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        FindObjectOfType<ButtonSoundAssigner>().AddButtonSound();
        loseScreen.SetActive(true);
    }
}
