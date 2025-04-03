using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private float stunTime = 1f;
    [SerializeField] private float knockBackForce;
    [SerializeField] private float upwardForce;

    private Rigidbody rb;
    public bool isHurt = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        PlayerEvents.onHit += TakingDamage;
    }

    private void OnDisable()
    {
        PlayerEvents.onHit -= TakingDamage;
    }

    private void TakingDamage()
    {
        if (rb!=null)
        {
            rb.AddForce(knockBackForce * transform.forward);
            rb.AddForce(upwardForce * transform.up);
        }

        isHurt = true;
        StartCoroutine(Recover());
        print("player is taking damage");

    }

    private IEnumerator Recover()
    {
        yield return new WaitForSeconds(stunTime);
        isHurt = false;
    }
}
