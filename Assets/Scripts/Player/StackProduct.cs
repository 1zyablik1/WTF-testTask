using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackProduct
{
    private List<Product> products;

    private Transform parent;

    private float maxSizeStack;

    public StackProduct(Transform parent, float maxSizeStack)
    {
        products = new List<Product>();

        this.maxSizeStack = maxSizeStack;
        this.parent = parent;
    }

    public bool TryAddToStack(Product product)
    {
        if (products.Count + 1 > maxSizeStack)
            return false;

        AddToStack(product);

        return true;
    }

    public bool TryGetProduct(List<ProductType> productTypes, out Product product)
    {
        for(int i = products.Count - 1; i >= 0; i--)
        {
            foreach(var data in productTypes)
            {
                if (data == products[i].GetProductType())
                {
                    product = products[i];
                    products.RemoveAt(i);
                    //rePos
                    return true;
                }
            }    
        }

        product = null;
        return false;
    }

    private void AddToStack(Product product)
    {
        products.Add(product);
        product.transform.SetParent(parent);

        product.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public Vector3 GetTopProductPosition()
    {
        Vector3 position = new Vector3(0, this.parent.position.y + (products.Count - 1) * 0.2f, 0);
        return position;
    }
}
