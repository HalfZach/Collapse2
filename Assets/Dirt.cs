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
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("ShakeTrigger");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
