using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRoll : MonoBehaviour
{
    public float rollTimer = 1f;
    private GameObject rolled;
    public Animator rollAnimation;
    public Transform crocBody;

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
        if (other.tag == "Player")
        {
            other.transform.parent = crocBody;
            rolled = other.gameObject;
            rollAnimation.SetBool("isRolling", true);
            Invoke("Unroll", rollTimer);

            
        }
    }

    private void Unroll ()
    {
        rollAnimation.SetBool("isRolling", false);
        rolled.transform.parent = null;
    }
    


}
