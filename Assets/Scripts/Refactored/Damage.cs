﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitArea : MonoBehaviour
{
    public int damage = 1;
    public string tagToHit = "Enemy";
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
        if (other.tag == tagToHit)
        {
            HP hpToDamage = other.GetComponent<HP>();
            if (hpToDamage)
            {
                hpToDamage.TakeDamage(damage);
            }
            
        }
    }

}
