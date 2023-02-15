using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour, ICollectable
{

    public Animator CamAnim;
    public void Collect()
    {
        PlayerStats.Instance.Gold += 1000;
        SoundManager.Instance.PlaySound("Cash");
        PlayerStats.Instance.RubyObtained = true;
        SoundManager.Instance.PlaySound("CaveIn");
        CamAnim.SetTrigger("CaveIn");
        FindObjectOfType<DirtHolder>().CollapseWait();
       
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
