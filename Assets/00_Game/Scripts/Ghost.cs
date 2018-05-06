using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private Rigidbody rigid;
    private int HP;

    private void Start()
    {
        HP = 30;
        rigid = GetComponent<Rigidbody>();
        InvokeRepeating("GhostMovement", 5, 5);
    }

    private void Update()
    {
        if (HP <= 0)
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Game.Get().AddScore(200);
        Game.Get().GhostDestroyed();
    }
    private void GhostMovement()
    {     
            rigid.velocity = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            rigid.rotation = Quaternion.Euler(Vector3.forward);
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            rigid.transform.position = new Vector3(Random.Range(-9f, 89f), 2, Random.Range(49f, -49f));
        }
        if (other.gameObject.tag == "Player")
        {
            Player.Get().getHit(10);
        }
        if (other.gameObject.tag == "Bullet")
        {
            getHit();
            Destroy(other.gameObject);            
        }
    }

    public void getHit()
    {
        HP -= 10;
    }
}
