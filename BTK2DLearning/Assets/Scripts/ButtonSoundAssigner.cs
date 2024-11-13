using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundAssigner : MonoBehaviour
{
    private bool buttonsAssigned = false;

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() =>
            {
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlaySoundUIClick();
                }
            });
        }
    }


    public void AddButtonSound()
    {
        if (buttonsAssigned) return;

        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() =>
            {
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlaySoundUIClick();
                }
            });
        }

        buttonsAssigned = true;
    }
}
