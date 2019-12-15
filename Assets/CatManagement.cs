using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManagement : MonoBehaviour
{
    SortedSet<GameObject> catList = new SortedSet<GameObject>();
    // Start is called before the first frame update
    

    public void pushCat(GameObject cat)
    {
        catList.Add(cat);
    }
    public bool checkFollowing(GameObject cat)
    {
        if (catList.Contains(cat))
        {
            catList.Remove(cat);
            return true;
        }
        else
            return false;
        
    }
}
