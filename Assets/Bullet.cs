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

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.up * speed;
        else
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(impactEffect);
    }

    // Update is called once per frame

  
  
}
