using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        if (PlayerStats.Instance.RubyObtained)
        {
            SoundManager.Instance.StopSound();
            SoundManager.Instance.PlaySound("Win");
            Debug.Log("You Win!");
            Loader.Load("Victory Scene");
        }
    }
}
