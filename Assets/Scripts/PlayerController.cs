using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCheckEnemy = "Enemy";

    private bool canRun;

    private Vector3 pos;

    private void Start()
    {
        canRun = true;
    }

    void Update()
    {
        if (!canRun) return;

        pos = target.position;
        pos.y = transform.position.y;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCheckEnemy))
        {
            canRun = false;
        }
    }
}
