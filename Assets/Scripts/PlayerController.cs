using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    private bool canRun;

    private Vector3 pos;

    public GameObject endScreen;

    private void Start()
    {

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
            endScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheckEndLine))
        {
            canRun = false;
            endScreen.SetActive(true);
        }
    }

    public void CanRun()
    {
        canRun = true;
    }
}
