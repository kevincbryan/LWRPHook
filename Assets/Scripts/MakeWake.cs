using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MakeWake : MonoBehaviour
{
    public ParticleSystem myWake;
    private InWater myInWater;
    //private Rigidbody rb;
    private PlayerController playerController;
    public NavMeshAgent myNav;
    private Vector3 stopped = new Vector3(0, 0, 0);
    public bool particlesStopped = true;
 

    // Start is called before the first frame update
    void Start()
    {
        //myWake = gameObject.GetComponentInChildren<ParticleSystem>();
        ParticleSystem[] particles = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        //Debug.Log("Particles has been created? " + particles);
        //Debug.Log("Particles are :" + particles[0], particles[1]);


        for (int i = 0; i < particles.Length; i++)
        {
            //Debug.Log("For loop has been called");
            if (particles[i].tag == "Wake")
            {
                myWake = particles[i];
                //Debug.Log("Wake has been found " + myWake);
            }
            
        }



        myInWater = gameObject.GetComponent<InWater>();
        playerController = gameObject.GetComponent<PlayerController>();
        myNav = gameObject.GetComponent<NavMeshAgent>();

        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 still = new Vector3 (0, 0, 0);

        if (particlesStopped == true)
        {
            //Debug.Log("Should Check for starting");


            if (myInWater.inWater == true && myInWater.aboveWater == true)
            {
                //Debug.Log("PlayerIsInWater");

                if (playerController)
                {
                    //Debug.Log("PlayerController exists and should be tested");
                    if (playerController.isMoving == true)
                    {
                        //Debug.Log ("RB Velocity is " + Vector3.Distance (rb.velocity, still));
                        myWake.Play();
                        particlesStopped = false;
                        //Debug.Log("Player Wake should start");
                    }
                }
                if (myNav)
                {
                    Debug.Log("Checking for movement, and Nav is confirmed");
                    
                    if (myNav.velocity != stopped)
                    {
                        
                        myWake.Play();
                        particlesStopped = false;
                        Debug.Log("Not stopped particles should start");
                    }
                }
                
                
            }
        }
        if (particlesStopped == false)
        {
            if (myInWater.inWater == false || myInWater.aboveWater == false)
            {
                myWake.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                particlesStopped = true;
            }
            else if (playerController)
            {
                if (playerController.isMoving == false)
                {
                    myWake.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                    Debug.Log("Player Wake should stop");
                    particlesStopped = true;
                }
            }
            else if (myNav)
            {
                Vector3 stopped = new Vector3(0, 0, 0);
                if (myNav.velocity == stopped)
                {
                    myWake.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                    particlesStopped = true;
                }
            }

        }
    }
}
