using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputZone : TriggerZone
{
    private Sequence moveSequence;

    private int maxCountInInputStorage;

    protected override void OnTriggerEnterPlayer(Player player)
    {
        base.OnTriggerEnterPlayer(player);

        TryGetProduct(player);

        isPlayerInTrigger = true;
        isCanToCheck = true;
    }

    protected override void OnTriggerStayPlayer(Player player)
    {
        base.OnTriggerStayPlayer(player);

        TryGetProduct(player);
    }

    protected override void OnTriggerExitPlayer(Player player)
    {
        base.OnTriggerExitPlayer(player);

        isPlayerInTrigger = false;
        isCanToCheck = false;
    }

    public void SetMaxCountInInputStorage(int vallue)
    {
        maxCountInInputStorage = vallue;
    }

    private void TryGetProduct(Player player)
    {
        if (!isPlayerInTrigger)
            return;

        if (maxCountInInputStorage != -1)
          if (maxCountInInputStorage <= products.Count)
                return;

        if (!isCanToCheck)
            return;

        GetProduct(player);
    }

    private void GetProduct(Player player)
    {
        Product product;
        if (player.GetFromStack(neededProducts, out product))
        {
            products.Add(product);

            product.transform.SetParent(this.transform);

            isCanToCheck = false;
            AnimProduct(product);
        }
    }

    private void AnimProduct(Product product)
    {
        moveSequence = DOTween.Sequence();

        moveSequence.Append(product.transform.DOMove(this.startEndPoint.position, 0.2f));
        moveSequence.AppendCallback(() =>
        {
            product.gameObject.SetActive(false);
            isCanToCheck = true;
        });
    }
}
