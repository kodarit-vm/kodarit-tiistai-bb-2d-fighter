using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private Animator animator;

    public bool blockCheck = false;
    public float coolDown = 0.25f;

    private float coolDownTimer;
    private bool attacking = false;
    private bool hit = false;
    private int chooser;

    public Transform punchCheck;
    public Transform kickCheck;
    private float range = 0.5f;

    private LayerMask enemyLayer;
    public float punchDamage = 2f;
    public float kickDamage = 3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.GetMask("Default");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockCheck && !attacking && coolDownTimer <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Punch();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Kick();
            }
        }
    }

    private void Kick()
    {
        chooser = UnityEngine.Random.Range(0, 2);
        if (chooser == 1)
        {
            animator.SetTrigger("kick1");
        } else
        {
            animator.SetTrigger("kick2");
        }

    }

    private void Punch()
    {
        chooser = UnityEngine.Random.Range(0, 2);
        if (chooser == 1)
        {
            animator.SetTrigger("punch1");
        } else
        {
            animator.SetTrigger("punch2");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchCheck.position, range);
        Gizmos.DrawWireSphere(kickCheck.position, range);
    }
}
