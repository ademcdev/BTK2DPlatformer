using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioClip GameBeginSound;
    public AudioClip UIClickSound;
    public AudioClip jumpSound;
    public AudioClip EnemyKillSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundGameBegin()
    {
        audioSource.PlayOneShot(GameBeginSound);
    }

    public void PlaySoundWin()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlaySoundLose()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void PlaySoundUIClick()
    {
        audioSource.PlayOneShot(UIClickSound);
    }

    public void PlaySoundJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlaySoundEnemyKill()
    {
        audioSource.PlayOneShot(EnemyKillSound);
    }
}
