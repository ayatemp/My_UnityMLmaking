using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palmscript : MonoBehaviour
{
    public bool collision = false;

    //くっついている時はcollisionをtrueに
    private void  OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Goal")
        {
            collision = true;
        }
    }

    //離れている時はcollisionをfalseに
    
}
