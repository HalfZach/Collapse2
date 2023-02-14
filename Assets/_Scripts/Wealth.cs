using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wealth : MonoBehaviour, ICollectable
{
    [SerializeField] private int GoldAmount = 1;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite[] sprites;

    public void Collect()
    {
        PlayerStats.Instance.Gold += GoldAmount;
        SoundManager.Instance.PlaySound("Cash");
        Destroy(gameObject);
    }


    private void Awake()
    {
        sr= GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int num = Mathf.RoundToInt(Mathf.Abs(GetComponent<Transform>().position.y) / 15) + 1 + Random.Range(-2, 2);

        if (num >= sprites.Length -1)
        {
            num = sprites.Length -1;
        }
        if (num <= 0)
        {
            num = 0;
        }


        sr.sprite = sprites[num];
        GoldAmount =num + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
