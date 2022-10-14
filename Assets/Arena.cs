using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject player;
    public Transform elevator;
    private Animator arenaAnimator;
    private SphereCollider sphereCollider;
    void Start()
    {
        arenaAnimator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Camera.main.transform.parent.gameObject.
        GetComponent<CameraMovement>().enabled = false;
        player.transform.parent = elevator.transform;
        player.GetComponent<PlayerController>().enabled = false;
        arenaAnimator.SetBool("OnElevator", true);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.elevatorArrived);
    }

    public void ActivatePlatform() 
    {
        sphereCollider.enabled = true;
    }
}
