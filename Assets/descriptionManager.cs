using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class descriptionManager : MonoBehaviour
{
    public GameObject picture1;
    public GameObject picture2;

    public Sprite[] imageArray = new Sprite[18];

    public GameObject beforeArrow;
    public GameObject nextArrow;

    public GameObject Player;

    Sprite[] description = new Sprite[18];

    int page;
   

    // Start is called before the first frame update
    void Start()
    {
        description = Resources.LoadAll<Sprite>("description");
        beforeArrow.SetActive(false);
        page = 0;

        updateImages();
    }

    public void beforePage()
    {
        
        nextArrow.SetActive(true);
        Player.GetComponent<beforePageButton>().GvrOff();

        page--;

        updateImages();

        if (page == 0) beforeArrow.SetActive(false);
        else Player.GetComponent<beforePageButton>().GvrOn();
    }

    public void nextPage()
    {
        beforeArrow.SetActive(true);
        Player.GetComponent<nextPageButton>().GvrOff();

        page++;

        updateImages();

        if (page == 9) nextArrow.SetActive(false);
        else Player.GetComponent<nextPageButton>().GvrOn();
    }


    void updateImages()
    {
        picture1.GetComponent<Image>().sprite = imageArray[page * 2];
        picture2.GetComponent<Image>().sprite = imageArray[page * 2+1];

    }
}
