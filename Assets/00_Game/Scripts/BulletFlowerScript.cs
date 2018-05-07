using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlowerScript : MonoBehaviour
{
    private float count;

    void Start()
    {
        count = 0;
    }


    void Update()
    {        
        if (count >= 1.5f)
        {
            Destroy(gameObject);
        }
        else
        {            
            count += Time.deltaTime;
        }
    }
}
