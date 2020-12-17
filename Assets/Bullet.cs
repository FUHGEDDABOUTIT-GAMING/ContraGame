using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public Rigidbody2D rb;
    private GameObject obj;
    private Animator animator;

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    
    {
        animator = GetComponent<Animator>();
        
        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.up * speed;
        else
        rb.velocity = transform.right * speed;

    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Jumper_Enemy jumper = hitInfo.GetComponent<Jumper_Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
          //  animator.Play("Impact");
           obj=Instantiate(impactEffect, transform.position, transform.rotation);
           
        }
        if (jumper != null)
        {
            jumper.TakeDamage(damage);
            //  animator.Play("Impact");
            obj=Instantiate(impactEffect, transform.position, transform.rotation);
           
        }

       // Destroy(obj);
        Destroy(gameObject);
        
      
    }

    // Update is called once per frame

  
  
}
