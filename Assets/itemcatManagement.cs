using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcatManagement : MonoBehaviour
{
    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;
    public GameObject cat5;
    public GameObject cat6;
    // Start is called before the first frame update
    void Start()
    {
        cat1.SetActive(false);
        cat2.SetActive(false);
        cat3.SetActive(false);
        cat4.SetActive(false);
        cat5.SetActive(false);
        cat6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showCats()
    {
        cat1.SetActive(true);
        cat2.SetActive(true);
        cat3.SetActive(true);
        cat4.SetActive(true);
        cat5.SetActive(true);
        cat6.SetActive(true);
    }
}
