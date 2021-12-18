using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indian : MonoBehaviour
{
    public string trashTag;


    private void OnTriggerEnter(Collider other)
    {
        print("qub");
        if (other.gameObject.CompareTag(trashTag))
        {
            GameManager.instance.score += 50;
            Destroy(other.gameObject);
        }
    }
        

}


  
