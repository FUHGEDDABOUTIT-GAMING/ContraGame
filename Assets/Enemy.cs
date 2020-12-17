using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    
    [SerializeField]Transform player;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float aggroRange;
    public GameObject deathEffect;
    private Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
 
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > aggroRange)
        {
            StopChasingPlayer();
        }
     
        else
        {
            ChasePlayer();  
        }
        
    }
    
    void StopChasingPlayer()
    { 
        animator.Play("Crab_Idle");
        rb2d.velocity = new Vector2(0, 0);
        
    }

    void ChasePlayer()
    {
        animator.Play("Crab_Walk");
        if (transform.position.x < player.position.x)
        {
           // Mathf.FloorToInt(transform.position.x);
           rb2d.velocity = new Vector2(moveSpeed, 0);
            spriteRenderer.flipX = true;

        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            spriteRenderer.flipX = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    
   
    void Die()
    {
        GameObject death=Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
     
        
        





    }
}
