using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRemove : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private void Awake()
    {
        if (lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        lineRenderer.colorGradient.alphaKeys[0].alpha = 0;
        lineRenderer.colorGradient.alphaKeys[1].alpha = 0;
    }
}