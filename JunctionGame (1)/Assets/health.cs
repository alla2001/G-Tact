using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int hp;

    public void ReduceHp(int value)
    {
        hp -= value;
    }

    private void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);
    }
}