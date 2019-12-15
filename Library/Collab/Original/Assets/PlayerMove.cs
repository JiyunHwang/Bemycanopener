using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public UnityEvent Crush;

    public GameObject Player;
    public GameObject Motor;

    public float playerSpeed;
    public Text status;
    public int score;

    public bool item;
    public float Timer;

    int startPoint;
    int currDir;
    public int nextDir;
    public bool dirChanged = false;
    private Vector3 currVector;
    private Vector3 leftVector = new Vector3(0, -90f, 0);
    private Vector3 rightVector = new Vector3(0, 90f, 0);

    int nextX;
    int nextY;
    bool[,,] usedDir = new bool[5, 5, 4];

    private Rigidbody rb;

    GameObject[,] map = new GameObject[5, 5];

    public GameObject ScoreScreen;
    public GameObject FailScreen;

    public GameObject ScoreBoard;

    Collider currCorner = null;

    GameObject backArrow;
    bool isBackArrow;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0.7f;
        rb = GetComponent<Rigidbody>();
        score = 0;
        status = gameObject.GetComponentInChildren<Text>();

        ScoreScreen.SetActive(false);
        FailScreen.SetActive(false);

        //랜덤한 시작 지점
        GameObject[] startList = GameObject.FindGameObjectsWithTag("StartPoint");
        startPoint = UnityEngine.Random.Range(0, 6);
        Player.transform.position = startList[startPoint].transform.position;
        switch (startPoint)
        {
            case 0:
                currVector = new Vector3(0, 90f, 0);
                currDir = 2;
                nextX = 1;
                nextY = 1;
                break;
            case 1:
                currVector = new Vector3(0, 180f, 0);
                currDir = 3;
                nextX = 1;
                nextY = 2;
                break;
            case 2:
                currVector = new Vector3(0, 180f, 0);
                currDir = 3;
                nextX = 1;
                nextY = 3;
                break;
            case 3:
                currVector = new Vector3(0, 270f, 0);
                currDir = 0;
                nextX = 2;
                nextY = 3;
                break;
            case 4:
                currVector = new Vector3(0, 270f, 0);
                currDir = 0;
                nextX = 3;
                nextY = 3;
                break;
            case 5:
                currVector = new Vector3(0, 0, 0);
                currDir = 1;
                nextX = 3;
                nextY = 3;
                break;
        }
        Player.transform.rotation = Quaternion.Euler(currVector);

        Debug.Log("nextX" + nextX + " nextY" + nextY + " currDir" + currDir);

        //교차로, end/fail point 정보 [3,3] array로 저장
        GameObject[] intersectionList = GameObject.FindGameObjectsWithTag("Intersection");
        GameObject[] failList = GameObject.FindGameObjectsWithTag("Failpoint");
        GameObject endPoint = GameObject.FindGameObjectWithTag("Endpoint");

        map = new GameObject[5, 5];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                map[i + 1, j + 1] = intersectionList[i * 3 + j];
                map[i + 1, j + 1].SetActive(false);
            }
        }
        map[nextX, nextY].SetActive(true);

        map[1, 0] = failList[0]; map[0, 2] = failList[1]; map[0, 3] = failList[2];
        map[2, 4] = failList[3]; map[3, 4] = failList[4]; map[4, 3] = failList[5];
        map[3, 0] = endPoint;

        //교차로의 화살표 사용 정보 초기화
        usedDir[1, 1, 1] = true; usedDir[1, 3, 2] = true;
        usedDir[2, 1, 0] = true; usedDir[2, 2, 2] = true; usedDir[2, 3, 0] = true;
        usedDir[3, 1, 3] = true; usedDir[3, 2, 3] = true;

        if (usedDir[nextX, nextY, 0]) map[nextX, nextY].transform.Find("Left").gameObject.SetActive(false);
        if (usedDir[nextX, nextY, 1]) map[nextX, nextY].transform.Find("Up").gameObject.SetActive(false);
        if (usedDir[nextX, nextY, 2]) map[nextX, nextY].transform.Find("Right").gameObject.SetActive(false);
        if (usedDir[nextX, nextY, 3]) map[nextX, nextY].transform.Find("Down").gameObject.SetActive(false);

        //도착할 예정인 코너에 사용자가 진행해 오는 방향의 화살표가 있다면 일시적으로 false
        String dir = "";
        if (currDir == 0) dir = "Right";
        else if (currDir == 1) dir = "Down";
        else if (currDir == 2) dir = "Left";
        else if (currDir == 3) dir = "Up";

        if (nextX > 0 && nextX < 4 && nextY > 0 && nextY < 4 && map[nextX, nextY].transform.Find(dir).gameObject.activeSelf == true)
        {
            isBackArrow = true;
            backArrow = map[nextX, nextY].transform.Find(dir).gameObject;
            backArrow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item)
        {
            if (Timer < 7.0f)
            {
                playerSpeed = 0.2f;
                Timer += Time.deltaTime;
            }
            else
            {
                Timer = 0;
                playerSpeed = 0.7f;
                item = false;
            }

        }
        transform.position = transform.position + transform.forward * playerSpeed * Time.deltaTime;

    }

    public void setStartSpeed()
    {
        playerSpeed = 0.7f;
    }
    /*
    public void setScore()
    {
        score += random.Next(50);
        status.text = "SCORE: " + score;
    }
    */
    public void goStraight()
    {
        playerSpeed = 0.7f;

    }
    public void speedDown()
    {
        Timer = 0;
        item = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Corner") && currCorner != other)
        {
            currCorner = other;
            if (isBackArrow)
            {
                backArrow.SetActive(true);
                isBackArrow = false;
            }
            map[nextX, nextY].SetActive(false);
            if (!dirChanged && !usedDir[nextX, nextY, currDir]) nextDir = currDir;
            else if (!dirChanged && usedDir[nextX, nextY, currDir]) // 방향 선택 안했는데 직진 불가능할때
            {
                if (usedDir[nextX, nextY, (currDir + 1) % 4] == false) nextDir = (currDir + 1) % 4;
                else if (usedDir[nextX, nextY, (currDir + 3) % 4] == false) nextDir = (currDir + 3) % 4;
                else
                { // Game Over;
                    playerSpeed = 0;
                    FailScreen.SetActive(true);
                }
            }
            Debug.Log("currDir" + currDir + "nextDir" + nextDir);
            if ((nextDir - currDir + 4) % 4 == 3) currVector += leftVector;
            else if ((nextDir - currDir + 4) % 4 == 1) currVector += rightVector;
            iTween.RotateTo(Player, currVector, 1);
            if (currDir != nextDir) Player.transform.position = currCorner.transform.position;
            currDir = nextDir;
            dirChanged = false;



            switch (currDir)
            {
                case 0:
                    map[nextX, nextY].transform.Find("Left").gameObject.SetActive(false);
                    usedDir[nextX, nextY, currDir] = true;
                    nextY--;
                    break;

                case 1:
                    map[nextX, nextY].transform.Find("Up").gameObject.SetActive(false);
                    usedDir[nextX, nextY, currDir] = true;
                    nextX--;
                    break;

                case 2:
                    map[nextX, nextY].transform.Find("Right").gameObject.SetActive(false);
                    usedDir[nextX, nextY, currDir] = true;
                    nextY++;
                    break;

                case 3:
                    map[nextX, nextY].transform.Find("Down").gameObject.SetActive(false);
                    usedDir[nextX, nextY, currDir] = true;
                    nextX++;
                    break;
            }

            map[nextX, nextY].SetActive(true);
            if (usedDir[nextX, nextY, 0]) map[nextX, nextY].transform.Find("Left").gameObject.SetActive(false);
            if (usedDir[nextX, nextY, 1]) map[nextX, nextY].transform.Find("Up").gameObject.SetActive(false);
            if (usedDir[nextX, nextY, 2]) map[nextX, nextY].transform.Find("Right").gameObject.SetActive(false);
            if (usedDir[nextX, nextY, 3]) map[nextX, nextY].transform.Find("Down").gameObject.SetActive(false);


            String dir = "";
            if (currDir == 0) dir = "Right";
            else if (currDir == 1) dir = "Down";
            else if (currDir == 2) dir = "Left";
            else if (currDir == 3) dir = "Up";

            if (nextX > 0 && nextX < 4 && nextY > 0 && nextY < 4 && map[nextX, nextY].transform.Find(dir).gameObject.activeSelf == true)
            {
                isBackArrow = true;
                backArrow = map[nextX, nextY].transform.Find(dir).gameObject;
                backArrow.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("Failpoint"))
        {
            playerSpeed = 0;
            FailScreen.SetActive(true);

        }
        if (other.gameObject.CompareTag("Endpoint"))
        {
            playerSpeed = 0;
            ScoreScreen.SetActive(true);

            ScoreBoard.GetComponent<showScore>().makeScoreBoard(score);
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            Crush.Invoke();
        }
    }
}