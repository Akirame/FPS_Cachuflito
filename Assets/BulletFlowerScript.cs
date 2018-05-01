using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlowerScript : MonoBehaviour
{

    public float speed;
    private Rigidbody rigid;
    private float count;

    void Start()
    {
        count = 0;
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {        
        if (count >= 5)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(count);
            count += Time.deltaTime;
        }
    }
}
