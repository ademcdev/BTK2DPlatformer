using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static DataManager instance;
    public static GameManager instance;
    private MenuManagerIngame menuManagerIngame;
    public bool isGameOver = false;
    public bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGameScene")
        {
            menuManagerIngame = FindObjectOfType<MenuManagerIngame>();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void WinProcess()
    {
        if (DataManager.instance.EnemyKilled >= 5)
        {
            DataManager.instance.SaveResetGameData();
            isGameOver = true;
            menuManagerIngame.ShowWinScreen();
            SoundManager.instance.PlaySoundWin();
            print("KAZANDINIZ!");
        }
    }

    public void LoseProcess()
    {
        DataManager.instance.SaveResetGameData();
        isGameOver = true;
        menuManagerIngame.ShowLoseScreen();
        SoundManager.instance.PlaySoundLose();
        print("KAYBETT�N�Z!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
