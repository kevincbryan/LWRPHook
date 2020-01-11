using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHPBar : MonoBehaviour
{

    public HP npcHP;
    public Image healthbar;
    public Image backHealth;
    private float healthPercentage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.enabled == false )
        {

            if ( npcHP.hp != npcHP.hpMax)
            {
                healthbar.enabled = true;
                backHealth.enabled = true;
                Debug.Log("This should run onceish");
            }
            

        }
        healthPercentage = (float)npcHP.hp / (float)npcHP.hpMax;
        healthbar.fillAmount = healthPercentage;
    }
}
