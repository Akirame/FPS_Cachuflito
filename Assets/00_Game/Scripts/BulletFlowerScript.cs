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
        if (count >= 3f)
        {
            Destroy(gameObject);
        }
        else
        {            
            count += Time.deltaTime;
        }
    }
}
