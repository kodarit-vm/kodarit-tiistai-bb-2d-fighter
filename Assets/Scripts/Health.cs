using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    public float currentHealth;

    private float hitTimer = 0.15f;
    private bool isHit = false;

    private Animator animator;
    private Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (!isHit)
        {
            if (GetComponent<Fight>().blockCheck)
            {
                currentHealth -= damageTaken / 2;
            } else
            {
                currentHealth -= damageTaken;
                StartCoroutine(KnockBack());
            }
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        StartCoroutine(Dying());
    }
    IEnumerator Dying()
    {
        isHit = true;
        myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        yield return new WaitForSeconds(5f);
    }

    IEnumerator KnockBack()
    {
        isHit = true;
        myRigidBody.velocity = new Vector2(GetComponent<Movement>().facing * -2.5f, 2.5f);
        animator.SetTrigger("takeDamage");
        yield return new WaitForSeconds(hitTimer);
        isHit = false;
    }
}
