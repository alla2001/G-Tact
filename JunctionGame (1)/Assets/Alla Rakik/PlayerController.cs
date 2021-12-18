using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeInput))]
public abstract class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public SwipeInput input;

    private void Awake()
    {
        input.Swiped += OnSwip;
        if (input == null) input = GetComponent<SwipeInput>();
    }

    public abstract void OnSwip();

    private void Update()
    {
    }
}