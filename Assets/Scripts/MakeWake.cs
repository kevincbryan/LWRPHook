using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MakeWake : MonoBehaviour
{
    private ParticleSystem myWake;
    private InWater myInWater;
    //private Rigidbody rb;
    private PlayerController playerController;
    public NavMeshAgent myNav;
    private Vector3 stopped = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        myWake = gameObject.GetComponentInChildren<ParticleSystem>();
        myInWater = gameObject.GetComponent<InWater>();
        playerController = gameObject.GetComponent<PlayerController>();
        myNav = gameObject.GetComponent<NavMeshAgent>();

        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 still = new Vector3 (0, 0, 0);

        if (myWake.isPlaying == false)
        {


            if (myInWater.inWater == true && myInWater.aboveWater == true)
            {
                if (playerController)
                {
                    if (playerController.isMoving == true)
                    {
                        //Debug.Log ("RB Velocity is " + Vector3.Distance (rb.velocity, still));
                        myWake.Play();
                    }
                }
                if (myNav)
                {
                    
                    if (myNav.velocity != stopped)
                    {
                        myWake.Play();
                    }
                }
                
                
            }
        }
        else
        {
            if (myInWater.inWater == false || myInWater.aboveWater == false)
            {
                myWake.Stop();
            }
            else if (playerController)
            {
                if (playerController.isMoving == false)
                {
                    myWake.Stop();
                }
            }
            else if (myNav)
            {
                Vector3 stopped = new Vector3(0, 0, 0);
                if (myNav.velocity == stopped)
                {
                    myWake.Stop();
                }
            }

        }
    }
}
