using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public abstract class AbstractFabric : MonoBehaviour
{
    [SerializeField] protected List<ProductType> inputProduct;
    [SerializeField] protected Product outputProduct;

    [SerializeField] protected TriggerZone inputTrigger;
    [SerializeField] protected TriggerZone outputTrigger;

    [SerializeField] protected Transform productContainer;
    [SerializeField] protected Transform spawnPoint;


    [SerializeField] protected int maxCountInOutputStorage;
    [SerializeField] protected int maxCountInInputStorage;
    [SerializeField]protected TMP_Text text;

    protected Pool poolProfucts;

    protected bool isSpawning = false;

    private Sequence spawningSequence;


    protected void Awake()
    {
        Init();
        text.text = "";
    }

    protected abstract void Init();

    protected void CreatePool()
    {
        if (outputProduct == null)
            throw new System.Exception("Is Out/InOut Fabric?");

        poolProfucts = new Pool(outputProduct.gameObject, productContainer.gameObject);
    }

    protected void Update()
    {
        TryToSpawn();
    }

    protected virtual void TryToSpawn()
    {
    }

    protected virtual void Spawn()
    {
        if(isSpawning == false)
        {
            StartCoroutine(Spawning());
            isSpawning = true;
        }
    }

    protected bool IsStorageHaveSpace()
    {
        if(outputTrigger.GetProductsCount() < maxCountInOutputStorage - 1)
        {
            text.text = "";
            return true;
        }

        text.text = "Full Storage";
        return false;
    }

    protected IEnumerator Spawning()
    {
        yield return new WaitForSeconds(outputProduct.GetProductTimeSpawn());

        isSpawning = false;

        Product spawnedProduct = poolProfucts.GetFreeElement(spawnPoint.position).GetComponent<Product>();
        AnimateSpawning(spawnedProduct);
    }

    private void AnimateSpawning(Product product)
    {
        spawningSequence = DOTween.Sequence();

        spawningSequence.Append(product.transform.DOMove(outputTrigger.GetPositionToPlaceProduct(), 0.5f));
        spawningSequence.AppendCallback(() => {
            outputTrigger.AddToProducts(product); 
        });
    }
}
