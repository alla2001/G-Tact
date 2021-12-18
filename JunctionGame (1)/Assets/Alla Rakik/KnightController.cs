using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public float minSwipDistance;
    public GameObject lineRenderer;
    private Vector3 startPosHit = Vector3.zero;
    private Vector3 endPosHit = Vector3.zero;
    public LayerMask enemy;

    public override void OnSwip()

    {
        if (input.SwipedDistance > minSwipDistance)
        {
            print("SWIPED..");

            Ray startPos = Camera.main.ScreenPointToRay(input.startPos);
            Ray endPos = Camera.main.ScreenPointToRay(input.endPos);
            RaycastHit hit;

            if (Physics.Raycast(startPos, out hit))
            {
                startPosHit = hit.point;
            }
            if (Physics.Raycast(endPos, out hit))
            {
                endPosHit = hit.point;
            }
            print(input.startPos);
            print(input.endPos);

            RaycastHit[] hits;
            hits = Physics.SphereCastAll(startPosHit, 1f, (endPosHit - startPosHit));
            if (hits.Length > 0)
            {
                foreach (RaycastHit casthit in hits)
                {
                    if (casthit.collider.GetComponent<health>() != null)
                    {
                        print("HIITTT");
                        casthit.collider.GetComponent<health>().hp -= 1;
                        GameObject temp = Instantiate(lineRenderer, Vector3.zero, Quaternion.identity);
                        temp.GetComponent<LineRenderer>().SetPositions(new Vector3[] { temp.transform.InverseTransformPoint(startPos.GetPoint(1)), temp.transform.InverseTransformPoint(endPos.GetPoint(1)) });
                        Destroy(temp, 2);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(startPosHit, 0.1f);
        Gizmos.DrawSphere(endPosHit, 0.1f);
    }
}