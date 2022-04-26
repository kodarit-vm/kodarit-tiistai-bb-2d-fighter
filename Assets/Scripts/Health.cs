using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class Health : MonoBehaviour
{
    PhotonView view;

    private float maxHealth = 100f;
    public float currentHealth;

    private float hitTimer = 0.15f;
    public bool isHit = false;

    private Animator animator;
    private Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    [PunRPC]
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

    public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentHealth);
        } else if (stream.IsReading)
        {
            currentHealth = (float)stream.ReceiveNext();
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
