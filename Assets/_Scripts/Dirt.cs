using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int health = 1;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D col;
    [SerializeField] private Color[] colors;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < maxHealth)
        {
            sr.sprite = sprites[1];
            
        }
        if (health <= maxHealth/3)
        {
            sr.sprite = sprites[2];
            
        }

        if (health <= 0)
        {
            SoundManager.Instance.PlaySound("Crash");
            col.enabled = false;
            sr.enabled = false;
        }
        else
        {
            animator.SetTrigger("ShakeTrigger");
            SoundManager.Instance.PlaySound("Dig");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = Mathf.RoundToInt (Mathf.Abs (GetComponent<Transform>().position.y)/20) +1;
        sr.color = colors[maxHealth];
        health = maxHealth;
    }

    public void Respawn()
    {
        health = maxHealth;
        sr.sprite = sprites[0];
        col.enabled = true;
        sr.enabled = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
