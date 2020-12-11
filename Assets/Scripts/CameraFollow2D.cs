using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField]private float timeOffset;

    [SerializeField] private Vector2 posOffset;

    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float bottomLimit;
    [SerializeField]
    private float topLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cameras start position
        Vector3 startPos = transform.position;
        //Players current position
        Vector3 endPos = player.transform.position;


        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z =-10;
        
        // smoothly move the camera
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset*Time.deltaTime);
        
        


        transform.position = new Vector3
            (
            // limits a value to a range -clamp
            Mathf.Clamp(transform.position.x, leftLimit,rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit,topLimit),
            transform.position.z
            
            
            );
        
        
    }


    private void OnDrawGizmos()
    {
        // draw a box around our camera boundary
        Gizmos.color = Color.red;
        // top boundary line
        Gizmos.DrawLine(new Vector2(leftLimit,topLimit), new Vector2(rightLimit, topLimit));
        //right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit,topLimit), new Vector2(rightLimit, bottomLimit));
        // bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
