using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public HP playerHP;
    public Image healthbar;
    private float healthPercentage;

    // Start is called before the first frame update
    void Start()
    {

        GameObject playerHolder = GameObject.FindGameObjectWithTag("Player");
        playerHP = playerHolder.GetComponent<HP>();
        //Debug.Log("PlayerHealth is found :" + playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = (float)playerHP.hp / (float)playerHP.hpMax;
        //Debug.Log("PlayerHealth is: " + playerHP.hp);
        //Debug.Log("Health Percentage is :" + healthPercentage);
        healthbar.fillAmount = healthPercentage;
    }
}
