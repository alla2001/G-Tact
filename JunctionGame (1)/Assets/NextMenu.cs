using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuSelect;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void LoadNext()
    {
        menu.SetActive(false);
        menuSelect.SetActive(true);
    }
}