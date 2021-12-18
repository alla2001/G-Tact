using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public enum Direction
{
    forward, backward, left, right
}

public class PacManController : MonoBehaviour
{
    public Direction dir;

    public float speed;
    public int score = 0;
    public LayerMask IgnoreMe;
    public Text scoreText;

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    private void Awake()
    {
        StartCoroutine(MovementUpdate());
    }

    public void Move(int direction)
    {
        dir = (Direction)direction;
    }

    public IEnumerator MovementUpdate()
    {
        yield return new WaitForSeconds(0.4f);
        Vector3 tempdir = (this.transform.position + GetVector(dir) * speed) - this.transform.position;
        RaycastHit _hit;
        if (!Physics.Raycast(this.transform.position + ((this.transform.position + GetVector(dir) * speed) - this.transform.position).normalized * 0.51f, tempdir, out _hit, ((this.transform.position + GetVector(dir) * speed) - this.transform.position).magnitude)
                )
        {
            this.transform.Translate(GetVector(dir) * speed);
        }
        else
        {
            if (_hit.collider.gameObject.CompareTag("PacMan"))
            {
                if (GetVector(_hit.collider.gameObject.GetComponent<PacManController>().dir) != -GetVector(dir))
                {
                    Destroy(_hit.collider.gameObject);
                    this.transform.Translate(GetVector(dir) * speed);
                }
            }
            else if (_hit.collider.gameObject.CompareTag("Coin"))
            {
                AddScore(1);
                Destroy(_hit.collider.gameObject);
                this.transform.Translate(GetVector(dir) * speed);
            }
        }

        StartCoroutine(MovementUpdate());
    }

    public Vector3 GetVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.forward: return Vector3.forward;
            case Direction.backward: return -Vector3.forward;
            case Direction.left: return Vector3.left;
            case Direction.right: return Vector3.right;
            default: return Vector3.zero;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position + ((this.transform.position + GetVector(dir) * speed) - this.transform.position).normalized * 0.51f, (this.transform.position + GetVector(dir) * speed) - this.transform.position);
    }
}