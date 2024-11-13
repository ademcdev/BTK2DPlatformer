using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        DataManager.instance.SaveResetGameData();
        Time.timeScale = 1;
        GameManager.instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Toplam Fýrlatýlan Testere: " + DataManager.instance.totalThrowedProjectileCount.ToString();
        dataBoard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Toplam Öldürülen Düþman: " + DataManager.instance.totalEnemyKilledCount.ToString();
        dataBoard.SetActive(true);
    }

    public void CloseButton()
    {
        dataBoard.SetActive(false);
    }

}
