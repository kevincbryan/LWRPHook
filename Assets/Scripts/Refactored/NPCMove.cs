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
        nav.destination = target.transform.position;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= turningDistance)
        {
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position, -transform.position).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * nav.angularSpeed);
        }

    }
}
