using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThrown = false;
    private GameObject target;
    [SerializeField] private Vector3 throwHightOffset = new Vector3(0, 0.33f, 0);

    private void Start()
    {
        target = GameObject.Find("Player");    
    }

    void Update()
    {

        if (Time.frameCount % 6 ==0)
        {
            
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            if (distanceToTarget < throwDistance && justThrown==false)
            {
                ThrowSnowBall();
            }
        }
       
    }

    void ThrowSnowBall()
    {
        justThrown = true;
        GameObject tempSnowBall = Instantiate(snowBall,transform.position,transform.rotation);
        Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
        Vector3 targetDirection =  Vector3.Normalize(target.transform.position-transform.position);
            
        //Add a small throw angle
        targetDirection += throwHightOffset;
        tempRb.AddForce(targetDirection * throwSpeed);
        Invoke("ThrowOver", 0.1f);
    }
    void ThrowOver()
    {
        justThrown = false;
    }
}
