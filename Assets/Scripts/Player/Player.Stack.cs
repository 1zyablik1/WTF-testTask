using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    public Transform productsParent;

    private StackProduct stackProduct;

    public int sizeStack = 8;

    private void StackAwake()
    {
        stackProduct = new StackProduct(productsParent, sizeStack);
    }

    public bool AddToStack(Product product)
    {
        return stackProduct.TryAddToStack(product);
    }

    public Vector3 GetTopProductPosition()
    {
        return stackProduct.GetTopProductPosition();
    }


    public bool GetFromStack(List<ProductType> productTypes, out Product product)
    {
        product = null;
        return stackProduct.TryGetProduct(productTypes, out product);
    }
}
