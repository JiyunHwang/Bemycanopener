using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Curve1;
    public GameObject Curve2;
    public GameObject LeftDir;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turning()
    {
        Player.transform.LookAt(Curve1.transform);
        iTween.MoveTo(Player, Curve1.transform.position, 10f);
        Player.transform.LookAt(Curve2.transform);
        iTween.MoveTo(Player, Curve2.transform.position, 7f);
        Player.transform.LookAt(LeftDir.transform);
        iTween.MoveTo(Player, LeftDir.transform.position, 10f);
        Player.transform.Rotate(0, -45f, 0);

        if(Vector3.Distance(Player.transform.position, LeftDir.transform.position) < 0.05f)
            return;
    }
}
