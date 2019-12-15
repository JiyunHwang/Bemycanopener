using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class showScore : MonoBehaviour
{

    public Sprite[] digit = new Sprite[10];

    private Text status;
    private int score;

    public GameObject place1;
    public GameObject place2;
    public GameObject place3;
    public GameObject place4;


    // Start is called before the first frame update
    void Start()
    {
        digit = Resources.LoadAll<Sprite>("numbers");
    }

    public void makeScoreBoard()
    {
        string phrase = status.text.ToString();
        string[] words = phrase.Split(' ');
        score = Convert.ToInt32(words[words.Length - 1].ToString().Trim());

        
        place1.GetComponent<Image>().sprite = digit[score / 1000];
        score %= 1000;
        place2.GetComponent<Image>().sprite = digit[score / 100];
        score %= 100;
        place3.GetComponent<Image>().sprite = digit[score / 10];
        score %= 10;
        place4.GetComponent<Image>().sprite = digit[score];
        
    }
}