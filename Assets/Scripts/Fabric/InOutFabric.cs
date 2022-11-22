using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutFabric : AbstractFabric
{
    protected int countOfInputProducts = 0;

    protected override void Init()
    {
        CreatePool();
        ((InputZone)inputTrigger).SetMaxCountInInputStorage(maxCountInInputStorage);
        inputTrigger.SetNeededProduct(inputProduct);
    }

    protected override void TryToSpawn()
    {
        base.TryToSpawn();

        if (IsStorageHaveSpace() && IsHaveResources())
        {
            Spawn();
        }
    }

    protected bool IsHaveResources()
    {
        if (inputTrigger.GetProductsCount() > 0)
        {
            text.text = "";
            return true;
        }
        text.text = "No resources";
        return false;
    }

    protected override void Spawn()
    {
        if (isSpawning == false)
        {
            inputTrigger.DeleteLastProduct();
            StartCoroutine(Spawning());
            isSpawning = true;
        }
    }
}
