using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    
    public  bool arrived = false;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0,GameManager.instance.speed * Time.deltaTime);
        //transform.Rotate(0, 0, 3, Space.World); 
        //GetComponent<Rigidbody>().AddForce(0, 0, 10);
        
    }
}
