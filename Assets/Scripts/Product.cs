using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField]
    private ProductData productData;

    public ProductData GetProductData()
    {
        return productData;
    }

    public ProductType GetProductType()
    {
        return productData.productType;
    }

    public float GetProductTimeSpawn()
    {
        return productData.spawnedTime;
    }

}
