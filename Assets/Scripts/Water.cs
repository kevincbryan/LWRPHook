using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InWater>()!= null)
        {
            other.GetComponent<InWater>().inWater = true;
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InWater>() != null)
        {
            other.GetComponent<InWater>().inWater = false;
        }
    }
}
