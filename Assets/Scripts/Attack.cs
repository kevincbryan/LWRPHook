using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    //public int damage;
    public float attackDelay = .5f;
    private float timeUntilAttack = .5f;    
    public float attackDistance = 5f;
    public GameObject attackVolume;
    public Animator attackAnim;
    public ParticleSystem attackParticles;
    public NavMeshAgent nav;
    public GameObject target;
    private Vector3 pauseHolder;
    private NPCMove myMover;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
        myMover = gameObject.GetComponent<NPCMove>();
        timeUntilAttack = attackDelay;
        //Debug.Log("Nav is found : " + nav);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log ("Time")
        timeUntilAttack = Mathf.Max(0, timeUntilAttack - Time.deltaTime);

        if(timeUntilAttack <= 0)
        {
            //Debug.Log("Attack is firable");
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= attackDistance)
            {
                //Debug.Log("Firing attack");
                timeUntilAttack = attackDelay;
                MakeAttack();
                //Debug.Log("Attack has fired");
            }
        }
    }

    private void MakeAttack ()
    {
        Debug.Log("MakeAttack is running");
        attackVolume.SetActive(true);
        attackAnim.SetBool("isChomp", true);

        if (attackParticles)
        {
            attackParticles.Play();
        }
        myMover.PauseMovement(true);
      
        Invoke("EndAttack", attackDelay);
    }

    private void EndAttack()
    {
        //attackVolume.SetActive(false);
        attackAnim.SetBool("isChomp", false);
        if (attackParticles)
        {
            attackParticles.Stop();
        }
       myMover.PauseMovement(false);
       
        
    }
}
