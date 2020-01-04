using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward.normalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet has hit something");
        HP colHP = collision.gameObject.GetComponent<HP>();

        if (colHP)
        {
            colHP.TakeDamage(damage);

        }
        if (collision.gameObject.tag != "Water")
        {
            Destroy(gameObject);
        }
        
    }
}
