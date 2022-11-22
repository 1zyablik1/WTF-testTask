using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OutputZone : TriggerZone
{
    private Sequence waitSequence;
    [SerializeField]private float waitTime = 0.5f;
    private int maxInRow = 5;

    protected override void OnTriggerEnterPlayer(Player player)
    {
        base.OnTriggerEnterPlayer(player);

        isPlayerInTrigger = true;
        isCanToCheck = true;

        TryGiveProduct(player);
    }

    protected override void OnTriggerStayPlayer(Player player)
    {
        base.OnTriggerStayPlayer(player);

        TryGiveProduct(player);
    }

    protected override void OnTriggerExitPlayer(Player player)
    {
        base.OnTriggerExitPlayer(player);

        isPlayerInTrigger = false;
        isCanToCheck = false;
    }

    protected void TryGiveProduct(Player player)
    {
        if (products.Count == 0)
            return;

        if (!isPlayerInTrigger)
            return;

        if (!isCanToCheck)
            return;

        if(player.AddToStack(products[products.Count - 1]))
        {
            isCanToCheck = false;
            Product deletedProduct = products[products.Count - 1];
            products.RemoveAt(products.Count - 1);
            WaitProduct(player, deletedProduct);
        }
    }

    private void WaitProduct(Player player, Product product)
    {
        waitSequence = DOTween.Sequence();

        waitSequence.Append(product.transform.DOLocalMove(player.GetTopProductPosition(), waitTime));
        //waitSequence.AppendInterval(waitTime);
        waitSequence.AppendCallback(() => { isCanToCheck = true; });

        //waitSequence.AppendCallback(() => { isCanToCheck = true; });
    }

    public override Vector3 GetPositionToPlaceProduct()
    {
        Vector3 position = new Vector3(startEndPoint.position.x + startEndPoint.position.x * (products.Count % maxInRow) * 0.1f,
                                       startEndPoint.position.y,
                                       startEndPoint.position.z - 0.5f * (products.Count / maxInRow) );

        return position;
    }

}
