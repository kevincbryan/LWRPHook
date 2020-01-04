using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWater : MonoBehaviour
{

    public bool inWater = false;
    public bool aboveWater = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other) {
       if (other.tag == "Water")
       {
           inWater = true;
       }
       if (other.tag == "AboveWater")
       {
           aboveWater = true;
       }
   }

   private void OnTriggerExit(Collider other) {

        if (other.tag == "Water")
        {
            inWater = false;
        }
        if (other.tag == "AboveWater")
        {
            aboveWater = false;
        }
   }
}
