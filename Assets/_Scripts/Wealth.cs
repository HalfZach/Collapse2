using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wealth : MonoBehaviour, ICollectable
{
    [SerializeField] private int GoldAmount = 1;

    public void Collect()
    {
        PlayerStats.Instance.Gold += GoldAmount;
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
