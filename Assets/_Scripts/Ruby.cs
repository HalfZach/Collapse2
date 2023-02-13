using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        PlayerStats.Instance.RubyObtained = true;
        FindObjectOfType<DirtHolder>().Collapse();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
