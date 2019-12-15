using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject BookScreen;
    public GameObject DescriptionScreen;

    int page = 0; // 0 = main, 1 = book, 2 = setting

    void Start()
    {
        updateScreen();
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToMain()
    {
        page = 0;
        updateScreen();
    }

    public void GoToBook()
    {
        page = 1;
        updateScreen();
    }

    public void GoToDescription()
    {
        page = 2;
        updateScreen();
    }

    void updateScreen()
    {
        MainScreen.SetActive(false);
        BookScreen.SetActive(false);
        DescriptionScreen.SetActive(false);

        if (page == 0) MainScreen.SetActive(true);
        if (page == 1) BookScreen.SetActive(true);
        if (page == 2) DescriptionScreen.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}