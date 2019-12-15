using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IngemeScene : MonoBehaviour
{
    public GameObject PauseScreen;

    public PlayerMove playerMoveScript;

    public Image imgCircle;

    float speed = 1;

    public void Start()
    {
        PauseScreen.SetActive(false);
    }

    public void StartPause()
    {
        speed = playerMoveScript.playerSpeed;
        playerMoveScript.playerSpeed = 0;

        PauseScreen.SetActive(true);
    }

    public void StopPause()
    {
        playerMoveScript.playerSpeed = speed;

        PauseScreen.SetActive(false);
    }
}