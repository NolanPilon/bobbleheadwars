using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPos;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet")) 
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            CancelInvoke("fireBullet");
        }

    }
    void fireBullet() 
    {
        //Spawn Bullet at Barrel Position
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPos.position;
        //Add Forward Force
        bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;
    }
}
