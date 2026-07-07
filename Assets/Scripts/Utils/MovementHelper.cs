using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    float duration = 1f;

    private int index = 0;

    private void Start()
    {
        transform.position = positions[0].position;
        NextIndex();

        StartCoroutine(StartMovement());
    }

    private void NextIndex()
    {
        index++;

        if (index >= positions.Count) index = 0;
    }

    IEnumerator StartMovement()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[index].position, time / duration);


                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }
}
