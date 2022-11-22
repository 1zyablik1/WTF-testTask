using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    protected List<Product> products;

    protected List<ProductType> neededProducts;

    [SerializeField] protected Transform startEndPoint;

    protected bool isPlayerInTrigger = false;
    protected bool isCanToCheck = false;

    //[SerializeField] protected int maxToInput; // -1 to  inf

    protected void Awake()
    {
        products = new List<Product>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnTriggerEnterPlayer(player);
            player = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnTriggerStayPlayer(player);
            player = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnTriggerExitPlayer(player);
            player = null;
        }
    }

    public void SetNeededProduct(List<ProductType> neededProduct)
    {
        this.neededProducts = neededProduct;
    }

    protected virtual void OnTriggerExitPlayer(Player player)
    {
    }

    protected virtual void OnTriggerStayPlayer(Player player)
    {
    }

    protected virtual void OnTriggerEnterPlayer(Player player)
    {
    }

    public int GetProductsCount()
    {
        return products.Count;
    }

    public void AddToProducts(Product product)
    {
        products.Add(product);
    }

    public virtual Vector3 GetPositionToPlaceProduct()
    {
        return Vector3.zero;
    }

    public void DeleteLastProduct()
    {
        products.RemoveAt(products.Count - 1);
    }
}
