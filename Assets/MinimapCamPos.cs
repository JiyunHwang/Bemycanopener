using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamPos : MonoBehaviour
{
    public GameObject minimapPlane;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 CamPos = new Vector3(0, 12f, 0);
        this.transform.position = minimapPlane.transform.position + CamPos;
        this.transform.Rotate(90f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CamPos = new Vector3(0, 12f, 0);
        this.transform.position = minimapPlane.transform.position + CamPos;
        this.transform.Rotate(90f, 0, 0);
    }
}
