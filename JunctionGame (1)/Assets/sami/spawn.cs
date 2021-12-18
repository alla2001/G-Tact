using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject refrence;
    private Vector3 refe;
    public GameObject[] trash;
    private float e = 0;
    
    IEnumerator wait ()
    {
        print("hello");
        e = 0;
        for(int i=0; i<Random.Range(3,5);i++)
        {
            Instantiate(trash[Random.Range(0, 5)], refe - new Vector3(e, 0, Random.Range(-1,2)), Quaternion.identity);
            e += 3.5f;
        }
        
        

        yield return new WaitForSeconds(2.5f);
        StartCoroutine(wait());
    }
    private void Start()
    {
        StartCoroutine(wait());
        refe = refrence.transform.position ;
       
    }
    private void Update()
    {
        print(this.gameObject.name);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }



}
