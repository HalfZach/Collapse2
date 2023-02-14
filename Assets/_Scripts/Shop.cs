using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, ICollectable
{
    public GameObject shopPanel;
    [SerializeField] private PlayerMovement pm;
    public void Collect()
    {
        pm.canMove = false;
        Debug.Log("Open Shop");
        shopPanel.SetActive(true);
    }

    private void Awake()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    public void CloseShop()
    {
        pm.canMove = true;
    }

    public void BuyJump()
    {
        if (PlayerStats.Instance.Gold >= 100)
        {
            PlayerStats.Instance.Gold -= 100;
            SoundManager.Instance.PlaySound("Cash");
            pm.IncreaseJump();
        }
    }

    public void BuyStrength()
    {
        if (PlayerStats.Instance.Gold >= 50)
        {
            PlayerStats.Instance.Gold -= 50;
            SoundManager.Instance.PlaySound("Cash");
            pm.IncreaseStrength();
        }
    }

}
