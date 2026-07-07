using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollectableCoin> itens;

    [Header("Animation")]
    public float scaleDuration;
    public float scaleTimeBetweenCoins;
    public Ease ease;

    private void Start()
    {
        itens = new List<ItemCollectableCoin>();

        StartAnimation();
    }

    private void Update()
    {
        
    }

    public void RegisterCoin(ItemCollectableCoin i)
    {
        if(!itens.Contains(i))
            itens.Add(i);
    }

    public void StartAnimation()
    {
        StartCoroutine(ScaleCoinByTime());
    }

    IEnumerator ScaleCoinByTime()
    {
        Sort();
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenCoins);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
