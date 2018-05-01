using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public GameObject trapWeapon;
    public GameObject FlowerWeapon;
    public GameObject FlowerBullet;
    public float rayDistance = 5;
    public LayerMask rayCastLayer;
    public Camera cam;
    private bool boolTrap = true;
    private bool boolFlower = false;

    private void Update()
    {
        selectWeapon();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance,rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);
            switch (layerHitted)
            {   
                case "Traps":
                    {
                        
                        if (Input.GetKeyDown(KeyCode.Mouse0) && boolTrap == true)
                            Destroy(hit.transform.gameObject);
                    }
                    break;
                //case "Ghost":
                //    {
                //        if ((Input.GetKeyDown(KeyCode.Mouse0) && boolFlower == true))
                //            Destroy(hit.transform.gameObject);
                //    }
                //    break;
            }                
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && boolFlower == true)
        {
            GameObject obj = Instantiate(FlowerBullet, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 25));
        }
    }

    private void selectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            trapWeapon.SetActive(true);
            FlowerWeapon.SetActive(false);
            boolTrap = true;
            boolFlower = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            trapWeapon.SetActive(false);
            FlowerWeapon.SetActive(true);
            boolTrap = false;
            boolFlower = true;
        }
    }
}
