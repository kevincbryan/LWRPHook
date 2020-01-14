using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject target;
    public float stoppingDistance = 0f;
    private float turningDistance;
    private bool movePaused = false;  // Used to pause movement when a creature is lining up an attack
    private bool isStopped = false; // Used to stop movement for external reasons, ie log falling in the path.
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        nav.stoppingDistance = stoppingDistance;
        if (stoppingDistance < 0)
        {
            turningDistance = stoppingDistance * 1.5f;
        }
        else
        {
            stoppingDistance = 0;
            turningDistance = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (movePaused == false && isStopped == false)
        {
            nav.destination = target.transform.position;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= turningDistance)
            {
                Quaternion lookRotation = Quaternion.LookRotation(target.transform.position, -transform.position).normalized;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * nav.angularSpeed);
            }

        }
            
        
      

    }

    public void PauseMovement(bool paused)
    {
        movePaused = paused;
       
    }

    public void StopMovement (bool paused)
    {
        isStopped = paused;
    }
}
