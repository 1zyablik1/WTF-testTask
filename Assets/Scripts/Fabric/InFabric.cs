using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFabric : AbstractFabric
{
    protected override void Init()
    {
        ((InputZone)inputTrigger).SetMaxCountInInputStorage(maxCountInInputStorage);
        inputTrigger.SetNeededProduct(inputProduct);
    }
}
