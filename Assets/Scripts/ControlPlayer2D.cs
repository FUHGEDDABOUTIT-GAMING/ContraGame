using System;
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
    private TextMeshProUGUI lives;
    

    [SerializeField]
    private GameOver gameOver;
    
    //combat

    private int health = 3;

    private float invinsibleTimeafterHurt =1;
    private bool movementDisabled;
    public int itemCount;
    
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

        

        lives.text = "Lives: " + health;
        
    }

   void Hurt()
   {
       health--;

        

       if (health == 0)
       {
           
           //Application.LoadLevel(Application.loadedLevel);
           GetComponent<BoxCollider2D>().enabled = false;
           gameOver.gameObject.SetActive(true);
           movementDisabled = true;
           Debug.Log(itemCount);
           lives.text = "Lives: " + 0;

       }
       else
       {
           StartCoroutine(hurtBlinker());
           //animator.Play("Player_Damaged");
       }
   }

   IEnumerator hurtBlinker()
   {
       //ignore collision btwe enmeies and players
       int enemyLayer = LayerMask.NameToLayer("Enemy");
       int playerLayer = LayerMask.NameToLayer("Player");
       Physics2D.IgnoreLayerCollision(enemyLayer,playerLayer);
       foreach(Collider2D collider in myCols)
       {
           
           collider.enabled = false;
           collider.enabled = true;
           
       }
       
       // start animation
       animator.SetLayerWeight(1,1);
       
       // wait
       yield return new WaitForSeconds(invinsibleTimeafterHurt);
       
       //re enable
       Physics2D.IgnoreLayerCollision(enemyLayer,playerLayer,false);
       animator.SetLayerWeight(1,0);
       
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
