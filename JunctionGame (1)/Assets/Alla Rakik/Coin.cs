using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToAdd = 1;
    // Start is called before the first frame update

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ENTERNED");
        if (other.CompareTag("PacMan"))
        {
            other.gameObject.GetComponent<PacManController>().AddScore(scoreToAdd);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PacMan"))
        {
            other.gameObject.GetComponent<PacManController>().AddScore(scoreToAdd);
            Destroy(gameObject);
        }
    }
}