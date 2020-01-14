using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatNavigation : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform target;
    private bool isStopped = false;


    // Start is called before the first frame update
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerStay(Collider other)
    {

       if (isStopped == false)
        {
            if (other.tag == "Player")
            {
                nav.destination = target.transform.position;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        nav.destination = transform.position;
    }

    public void StopMovement(bool paused)
    {
        isStopped = paused;
    }
}
