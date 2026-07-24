using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public string compareTag = "Player";

    public GameObject graphicItem;

    public AudioSource audioSource;

    public float timeToHide = 3f;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        OnCollect();
        Invoke("HideItem", timeToHide);
    }

    protected void HideItem()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        print("coletou");
        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }
        if (audioSource != null) audioSource.Play();
    }

}
