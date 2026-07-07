using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{

    public float duration = 0.2f;
    private MeshRenderer meshRenderer;

    public Color startColor = Color.white;

    private Color correctColor;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        correctColor = meshRenderer.materials[0].GetColor("_Color");

        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(correctColor, duration);
    }
}
