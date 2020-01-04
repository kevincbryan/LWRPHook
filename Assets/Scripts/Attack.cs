using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public int damage;
    public float attackDelay = .5f;
    private float timeUntilAttack = 0;
    public float attackDistance = 5f;
    public GameObject attackVolume;
    public Animator attackAnim;
    public ParticleSystem attackParticles;
    public NavMeshAgent nav;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilAttack = Mathf.Max(0, timeUntilAttack - Time.deltaTime);

        if(timeUntilAttack >= 0)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= attackDistance)
            {
                timeUntilAttack = attackDelay;
                MakeAttack();
                Debug.Log("Attack has fired");
            }
        }
    }

    private void MakeAttack ()
    {
        attackVolume.SetActive(true);
        attackAnim.SetBool("isChomp", true);
        attackParticles.Play();
        Invoke("EndAttack", .5f);
    }

    private void EndAttack()
    {
        attackVolume.SetActive(false);
        attackAnim.SetBool("isChomp", false);
        attackParticles.Stop();
    }
}
