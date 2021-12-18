using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score=600;
    [Range(0, 10)] public float speed;
    public GameObject gopanel;


    void Awake()
    {
        instance = this;
    }
    public void gameOver()
    {
        gopanel.SetActive(true);
        print(Time.timeScale);
        StopAllCoroutines();
    }
    public void retry()
    {
        
        gopanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
      if(score <= 0)
        {
            gameOver();
        }
    }
}
