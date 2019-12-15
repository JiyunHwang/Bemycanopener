using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerPos : MonoBehaviour
{
    public GameObject MinimapMark;
    public GameObject PlaneMark;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = Player.transform.position - PlaneMark.transform.position;
        this.transform.position = MinimapMark.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = Player.transform.position - PlaneMark.transform.position;
        this.transform.position = MinimapMark.transform.position + offset;
    }
}
