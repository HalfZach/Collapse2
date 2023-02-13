using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        if (PlayerStats.Instance.RubyObtained)
        {
            Debug.Log("You Win!");
        }
    }
}
