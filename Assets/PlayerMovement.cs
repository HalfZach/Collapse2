using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    [SerializeField]private float speed = 8f;
    [SerializeField]private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Transform attackPos;
    public LayerMask damagables;

    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    [SerializeField]
    private InputActionReference pointerPosition;

    private Vector2 pointerInput;

    private WeaponParent weaponParent;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //if (!isFacingRight && horizontal > 0f)
        //{
        //    Flip();
        //}
        //else if (isFacingRight && horizontal < 0f)
        //{
        //    Flip();
        //}

        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = 0f;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.75f);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Collider2D[] thingsToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, damagables);
            for (int i = 0; i < thingsToDamage.Length; i++)
            {
                thingsToDamage[i].GetComponent<IDamageable>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }



    private bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.2f, damagables))
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
