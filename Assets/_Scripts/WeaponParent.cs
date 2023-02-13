using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector3 target;
    public int speed = 5;
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
       Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;

        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }
}
