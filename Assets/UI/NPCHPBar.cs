using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHPBar : MonoBehaviour
{

    public HP npcHP;
    public Image healthbar;
    private float healthPercentage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = (float)npcHP.hp / (float)npcHP.hpMax;
        healthbar.fillAmount = healthPercentage;
    }
}
