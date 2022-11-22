using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Data/Product Data", order = 51)]
public class ProductData : ScriptableObject
{
    public ProductType productType;
    public float spawnedTime;
}
