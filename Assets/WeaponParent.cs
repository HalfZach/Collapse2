using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector3 target;
    public int speed = 5;
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
        //target = Input.mousePosition;

        //Vector3 vectorToTarget = target - transform.position;
        //float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        transform.right = (PointerPosition - (Vector2)transform.position).normalized;
    }
}
