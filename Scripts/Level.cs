using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float WaitSecTime = 5;

    public void LoadGameScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadStartScene()
    {
        FindObjectOfType<MusicPlayer>().RestGame();
        FindObjectOfType<Gameseesion>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLoseScene()
    {
        StartCoroutine(WaitSecForNextScene());
    }

    IEnumerator WaitSecForNextScene()
    {
        yield return new WaitForSeconds(WaitSecTime);
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


