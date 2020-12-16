using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;

    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // all the shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
