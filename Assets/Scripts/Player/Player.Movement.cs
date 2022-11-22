using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    public float speed;

    private void MovementFixedUpdate()
    {
        if (JoystickControl.Horizontal != 0 || JoystickControl.Vertical != 0)
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        this.transform.position += new Vector3(JoystickControl.Horizontal * speed * Time.deltaTime, 0f, JoystickControl.Vertical * speed * Time.deltaTime);
    }

    private void Rotate()
    {
        this.transform.eulerAngles = new Vector3(0f, Mathf.Atan2(JoystickControl.Horizontal, JoystickControl.Vertical) * Mathf.Rad2Deg, 0f);
    }
}
