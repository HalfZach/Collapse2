using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtHolder : MonoBehaviour
{
    public void Collapse()
    {
       Dirt[] allDirts = GetComponentsInChildren<Dirt>();

        foreach (var d in allDirts)
        {
            d.Respawn();
        }
    }
}
