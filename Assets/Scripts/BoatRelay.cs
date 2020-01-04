using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRelay : MonoBehaviour
{
    public Transform nextTarget;
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
        if (other.gameObject.tag == "Boat")
        {
            if(other.gameObject.GetComponent<BoatNavigation>())
            {
                other.gameObject.GetComponent<BoatNavigation>().target = nextTarget;
            }
        }
    }
}
