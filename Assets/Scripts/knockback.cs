using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("enemy")){

            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null){
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * 4;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                enemy.isKinematic = true;

            }
        }
    }
}
