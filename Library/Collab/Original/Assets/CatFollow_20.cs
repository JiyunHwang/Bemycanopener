using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CatFollow_20 : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public GameObject Cube;
    public GameObject Cart;

    public GameObject Cat;
    public GameObject CatManager;

    bool follow = false;

    public Text status;
    public int score;
    public int totalScore;


    System.Random random = new System.Random();
    double X, Z;
    float numX, numZ;

    void Start()
    {
        score = 20;
        X = random.NextDouble();
        Z = random.NextDouble();
        numX = Convert.ToSingle(X);
        numZ = -(Convert.ToSingle(Z));
        animator = Cat.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {


        if (follow)
        {
            Vector3 target = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
            Cat.transform.LookAt(target);
            Vector3 offset = new Vector3(numX, 0.3f, numZ);
            Cat.transform.position = Cart.transform.position + offset;
            animator.Play("A_smell");
        }

    }
    public void setBool()
    {
        follow = true;
        Cube.gameObject.SetActive(false);
        Cat.transform.SetParent(Cart.transform);
        Cat.GetComponent<AudioSource>().Play();
    }
    public void setScore()
    {

        string phrase = status.text.ToString();
        string[] words = phrase.Split(' ');
        totalScore = Convert.ToInt32(words[words.Length - 1].ToString().Trim());
        totalScore += score;
        status.text = "SCORE: " + totalScore;

        CatManager.GetComponent<CatManagement>().pushCat(Cat);
    }
    public void obstacleScore()
    {
        if (CatManager.GetComponent<CatManagement>().checkFollowing(Cat))
        {
            string phrase = status.text.ToString();
            string[] words = phrase.Split(' ');
            totalScore = Convert.ToInt32(words[words.Length - 1].ToString().Trim());
            totalScore -= score;
            if (totalScore < 0)
                totalScore = 0;
            status.text = "SCORE: " + totalScore;
            Cat.SetActive(false);
        }


    }
}
