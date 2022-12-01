using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int musicplayer = FindObjectsOfType(GetType()).Length;
        if (musicplayer > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RestGame()
    {
        Destroy(gameObject);
    }
}
