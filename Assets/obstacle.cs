using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class obstacle : MonoBehaviour
{
    public CanvasGroup myCG;
    private bool flash = false;
    private bool active = false;
    public Image imgCircle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        {
            myCG.alpha = myCG.alpha - Time.deltaTime;
            if (myCG.alpha <= 0)
            {
                myCG.alpha = 0;
                flash = false;
                active = true;
            }
        }
        if (active)
        {
            gameObject.SetActive(false);
        }
    }

    // Obstacle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();

            flash = true;
            myCG.alpha = 1;
            
        }
    }

    public void setEnable()
    {
        gameObject.SetActive(false);
        imgCircle.fillAmount = 0;
    }
}
