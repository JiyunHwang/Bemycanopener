using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageManager : MonoBehaviour
{
    public GameObject picture1;
    public GameObject picture2;
    public GameObject picture3;
    public GameObject picture4;
    
    public GameObject beforeArrow;
    public GameObject nextArrow;

    public GameObject Player;

    Sprite[] cat = new Sprite[19];

    int page;
        
    // Start is called before the first frame update
    void Start()
    {
        cat = Resources.LoadAll<Sprite>("catImage");
        beforeArrow.SetActive(false);
        page = 0;

        updateImages();
    }

    public void beforePage()
    {
        picture3.SetActive(true);
        picture4.SetActive(true);
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

        if (page == 4) nextArrow.SetActive(false);
        else Player.GetComponent<nextPageButton>().GvrOn();
    }

    void updateImages()
    {
        picture1.GetComponent<Image>().sprite = cat[page * 4 + 1];
        picture2.GetComponent<Image>().sprite = cat[page * 4 + 2];

        if (page == 4) picture3.SetActive(false);
        else picture3.GetComponent<Image>().sprite = cat[page * 4 + 3];

        if (page == 4) picture4.SetActive(false);
        else picture4.GetComponent<Image>().sprite = cat[page * 4 + 4];
    }
}
