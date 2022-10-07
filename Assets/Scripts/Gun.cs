using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPos;
    private AudioSource audioSource;
    public bool isUpgraded;
    public float upgradeTime = 10.0f;
    private float currentTime;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
       Rigidbody bullet = createBullet();
       bullet.velocity = transform.parent.forward * 100;
        if (isUpgraded) 
        {
            Rigidbody bullet2 = createBullet();
            bullet2.velocity = (transform.right + transform.forward / 0.5f) * 100;
            Rigidbody bullet3 = createBullet();
            bullet3.velocity = ((transform.right * -1) + transform.forward / 0.5f) * 100;
        }

        if (isUpgraded)
        {
            audioSource.PlayOneShot(SoundManager.Instance.upgradedGunFire);
        }
        else 
        {
            audioSource.PlayOneShot(SoundManager.Instance.gunFire);
        }
    }
    private Rigidbody createBullet() 
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPos.position;
        return bullet.GetComponent<Rigidbody>();
    }

    public void UpgradeGun() 
    {
        isUpgraded = true;
        currentTime = 0;
    }
}
