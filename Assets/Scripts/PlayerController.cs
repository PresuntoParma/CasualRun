using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
