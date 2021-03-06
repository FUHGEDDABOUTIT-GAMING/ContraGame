﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.LowLevel;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlPlayer2D : MonoBehaviour
{

    public static ControlPlayer2D instance;
    private Animator animator;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public float movespeed;

    private bool isGrounded;

    private bool facingRight = true;
    
    [SerializeField]
    private Transform groundCheck;
    
    [SerializeField]
    private TextMeshProUGUI healthTMP;
    

    [SerializeField]
    private GameOver gameOver;

    [SerializeField]
    private PauseMenu pauseMenu;
    
    //combat

    [SerializeField]
    public static int health = 5;

    private float invinsibleTimeafterHurt =1;
    private bool movementDisabled;
    public int itemCount;

    private bool paused;
    
    Collider2D[] myCols;
    // Start is called before the first frame update
    void Start()
    {
      //  instance = this;
        itemCount = 0;
        myCols = this.GetComponents<Collider2D>();
       animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movementDisabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!paused){
                pauseMenu.gameObject.SetActive(true);
                movementDisabled = true;
                paused = true;
            }
            else{
                pauseMenu.gameObject.SetActive(false);
                movementDisabled = false;
                paused = false;
            }
            Debug.Log("Escaped pressed");
        }

    }

    private void FixedUpdate()
    {


        
        if (movementDisabled)
            return;
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platforms")))
        {
         //   Debug.Log("Grounded");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            //Debug.Log("NOT Grounded");
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                facingRight = false;
                transform.Rotate(0,180,0);
            }
            
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if (isGrounded)
            {

                if (Input.GetKey(KeyCode.B))
                    animator.Play("Run_Fire");
                else
                    animator.Play("Run");
            }

          

        }

        else if (Input.GetKey(KeyCode.D)){
            if (!facingRight)
            {
                facingRight = true;
                transform.Rotate(0,180,0);
            }
            
            rb.velocity = new Vector2(+movespeed, rb.velocity.y);
           if (isGrounded)
            {
                
                if(Input.GetKey(KeyCode.B))
                    animator.Play("Run_Fire");
                else
                animator.Play("Run");
            }
                
                
    
        }
        
        /*
        else if (Input.GetKey(KeyCode.W))
        {

            //rb.velocity = new Vector2(+movespeed, rb.velocity.y);
            if (isGrounded)
            {
                
                if(Input.GetKey(KeyCode.B))
                    animator.Play("Up_Fire");
                else
                    animator.Play("Gun_Up");
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
                
                
            
        }
        else if (Input.GetKey(KeyCode.S))
        {

            if (isGrounded)
            {
                
                if(Input.GetKey(KeyCode.B))
                    animator.Play("Duck_Fire");
                else
                    animator.Play("Duck");
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
                
            
        }
        */
        
        else
        {
            if (isGrounded)
            {
                
                if(Input.GetKey(KeyCode.B))
                    animator.Play("Static_Fire");
                else
                    animator.Play("Static");
            }
            /*if(isGrounded)
                animator.Play("Static");
            rb.velocity = new Vector2(0, rb.velocity.y);*/
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded==true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
           animator.Play("Jump");
        }

        
        //sets health text on screen
        healthTMP.text = "health: " + health;
        
    }

   void Hurt()
   {   
       //lowers health 
       health -= 1;
       

        

       if (health == 0)
       {
           
           //Application.LoadLevel(Application.loadedLevel);
           GetComponent<BoxCollider2D>().enabled = false;
           gameOver.gameObject.SetActive(true);
           movementDisabled = true;
           Debug.Log(itemCount);
           healthTMP.text = "health: " + 0;

       }
       else
       {
            StartCoroutine(DoBlinks(.05f, 0.2f));

       }
   }

    //blinking animation
     IEnumerator DoBlinks(float duration, float blinkTime) {
         while (duration > 0f) {
                 duration -= Time.deltaTime;
      
            //toggle renderer
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
      
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
         }
  
         //make sure renderer is enabled when we exit
         GetComponent<Renderer>().enabled = true;
     }






    private void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.CompareTag("enemy")){
            Hurt();  
        
        }

        else if (col.gameObject.CompareTag("Finish")){
            gameOver.gameObject.SetActive(true);
            movementDisabled = true;
        }






        
    }





      //      if(facingRight){
      //        rb.velocity = new Vector2 (-knockbackSpeed*5, knockbackSpeed);
      //      }
      //      else{
      //        rb.velocity = new Vector2(knockbackSpeed,knockbackSpeed);
      //      }   
    /*
    void incrementItems()
    {
        itemCount++;
    }
    
    */
}
