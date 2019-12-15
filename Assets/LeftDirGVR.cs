using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LeftDirGVR : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    public float totalTime = 1.5f;
    bool gvrStatus;
    public float gvrTimer;

    public GameObject Player;

    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }
        if (gvrTimer > totalTime)
        {
            gvrTimer = 0;
            imgCircle.fillAmount = 0;
            gvrStatus = false;

            GetComponent<AudioSource>().Play();
            Player.GetComponent<PlayerMove>().nextDir = 0;
            Player.GetComponent<PlayerMove>().dirChanged = true;
        }
    }
    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgCircle.fillAmount = 0;
    }
}
