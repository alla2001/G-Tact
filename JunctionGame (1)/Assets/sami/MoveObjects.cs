using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MoveObjects : MonoBehaviour
{
    private Dictionary<int, GameObject> links = new Dictionary<int, GameObject>();

    private void Update()
    {
        foreach (Touch _touch in Input.touches)
        {
            bool intouches = false;
            foreach (KeyValuePair<int, GameObject> temp in links)
            {
                if (_touch.fingerId == temp.Key)
                {
                    intouches = true;
                    temp.Value.transform.position = Camera.main.ScreenPointToRay(_touch.position).GetPoint(19);
                    temp.Value.transform.position = new Vector3(temp.Value.transform.position.x, 1, temp.Value.transform.position.z);
                }
            }
            if (!intouches)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(_touch.position), out hit))
                {
                    if (hit.collider.CompareTag("metal") || hit.collider.CompareTag("plastic"))
                    {
                        links.Add(_touch.fingerId, hit.collider.gameObject);
                    }
                }
            }
        }
        foreach (KeyValuePair<int, GameObject> temp in links)
        {
            bool intouches = false;
            foreach (Touch _touch in Input.touches)
            {
                if (_touch.fingerId == temp.Key)
                    intouches = true;
            }
            if (!intouches) links.Remove(temp.Key);
        }
    }
}