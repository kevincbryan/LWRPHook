using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public string tagToBlock = "Boat";
    private BoatNavigation boatBlock;

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
        if (other.tag == tagToBlock)
        {
            boatBlock = other.gameObject.GetComponent<BoatNavigation>();
            if (boatBlock)
            {
                Debug.Log("Block found, boat should stop");
                boatBlock.StopMovement(true);
            }
        }
    }

    private void OnDestroy()
    {
        if (boatBlock)
        {
            Debug.Log("Block destroyed boat should move");
            boatBlock.StopMovement(false);
        }
    }

}
