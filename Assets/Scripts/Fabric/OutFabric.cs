using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutFabric : AbstractFabric
{
    protected override void Init()
    {
        CreatePool();
    }

    protected override void TryToSpawn()
    {
        base.TryToSpawn();

        if(IsStorageHaveSpace())
        {
            Spawn();
        }
    }
}
