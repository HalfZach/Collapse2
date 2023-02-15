using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtHolder : MonoBehaviour
{
    
   public void CollapseWait()
    {
        Invoke("Collapse", 2);

    } 
    
    public void Collapse()
    {
        SoundManager.Instance.PlaySound("GetOut");
        SoundManager.Instance.PlaySound("Bercillak");
        Dirt[] allDirts = GetComponentsInChildren<Dirt>();

        foreach (var d in allDirts)
        {
            d.Respawn();
        }
    }
}
