using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject Player;
    public GameObject pauseScreen;

    float speed;

    private void Start()
    {
        pauseScreen.SetActive(false);
    }

    public void GoToPause()
    {
        speed = Player.GetComponent<PlayerMove>().playerSpeed;

        Player.GetComponent<PlayerMove>().playerSpeed = 0;
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Player.GetComponent<PlayerMove>().playerSpeed = speed;

        pauseScreen.SetActive(false);
    }

    public void Restart(string restartName)
    {
        SceneManager.LoadScene(restartName);
    }

    public void GoToMain(string mainName)
    {
        SceneManager.LoadScene(mainName);
    }
}
