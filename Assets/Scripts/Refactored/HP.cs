using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int hp;
    public int hpMax;
    public Animator transition;


    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (gameObject.tag == "Player")
            {
                LoadThisLevel();
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }


    public void LoadThisLevel ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }


    IEnumerator LoadLevel (int levelIndex)
    {
        if (transition) transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);

    }
}
