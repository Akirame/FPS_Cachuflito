using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public GameObject trapWeapon;
    public GameObject FlowerWeapon;
    public GameObject FlowerBullet;
    public float rayDistance;
    public LayerMask rayCastLayer;
    public Camera cam;
    private bool boolTrap;
    private bool boolFlower;
    private int bulletTrapWeapon;
    private int bulletFlowerWeapon;
    private void Start()
    {
        rayDistance = 5;
        boolTrap = true;
        boolFlower = false;
        bulletTrapWeapon = 1;
        bulletFlowerWeapon = 6;
    }
    private void Update()
    {
        SelectWeapon();
        ShootWeapon();
        Reload();
        SetBulletText();
    }

    private void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            trapWeapon.SetActive(true);
            FlowerWeapon.SetActive(false);
            boolTrap = true;
            boolFlower = false;
            Game.Get().SetWeaponText("TRAPPERZAPPER");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            trapWeapon.SetActive(false);
            FlowerWeapon.SetActive(true);
            boolTrap = false;
            boolFlower = true;
            Game.Get().SetWeaponText("FLOWERPOWER");
        }
    }
    private void ShootWeapon()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.white);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);
            switch (layerHitted)
            {
                case "Traps":
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0) && boolTrap == true && bulletTrapWeapon > 0)
                        {
                            Destroy(hit.transform.gameObject);
                            Game.Get().BulletShooted();
                            bulletTrapWeapon--;
                        }
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && boolFlower == true && bulletFlowerWeapon > 0)
        {
            GameObject obj = Instantiate(FlowerBullet, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 25));            
            bulletFlowerWeapon--;
            Game.Get().BulletShooted();
        }
    }
    private void Reload()
    {
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Mouse1)) && boolFlower == true && bulletFlowerWeapon == 0)
        {
            bulletFlowerWeapon = 6;
        }
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Mouse1)) && boolTrap == true && bulletTrapWeapon == 0)
        {
            bulletTrapWeapon = 1;
        }
    }
    private void SetBulletText()
    {
        if (boolTrap == true)
        {
            Game.Get().SetBulletText(bulletTrapWeapon, "/1");
        }
        if (boolFlower == true)
        {
            Game.Get().SetBulletText(bulletFlowerWeapon, "/6");
        }
    }
}
