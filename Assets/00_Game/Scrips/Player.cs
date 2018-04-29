using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static Player instance;
    private Rigidbody rigid;

    public static Player Get()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void getHit(int health)
    {
        Game.Get().SetHealth(health);
    }
    private void OnCollisionEnter(Collision c)
    {
        float force = 7000;
       
        if (c.gameObject.tag == "Trap")
        {
            getHit(50);
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }

}
