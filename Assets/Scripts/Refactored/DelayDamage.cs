using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDamage : MonoBehaviour
{
    public int damage = 1;
    public string tagToHit = "Enemy";
    public float chargeTime = .5f;
    private Collider myTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("DamageEnd", chargeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToHit)
        {
            myTarget = other;
        }

    }

    private void OnTriggerExit(Collider other)
    {
            if (other.tag == tagToHit)
            {
                myTarget = null;
            }
        }

    private void DamageEnd ()
    {
        if (myTarget)
        {
            HP hpToDamage = myTarget.GetComponent<HP>();
            if (hpToDamage)
            {
                hpToDamage.TakeDamage(damage);
            }
        }

        gameObject.SetActive(false);
    }

}
