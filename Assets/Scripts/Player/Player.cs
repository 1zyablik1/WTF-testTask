using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private void Awake()
    {
        StackAwake();
    }

    private void FixedUpdate()
    {
        MovementFixedUpdate();
    }
}
