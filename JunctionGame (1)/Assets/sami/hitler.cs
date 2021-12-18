using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitler : MonoBehaviour
{
    public Text hpTxt;
    private void Update()
    {
        hpTxt.text = GameManager.instance.score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        
      
            GameManager.instance.score -= 20;
            Destroy(other.gameObject);
      
    }
}
