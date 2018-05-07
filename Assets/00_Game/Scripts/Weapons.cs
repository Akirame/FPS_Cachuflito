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
    public GameObject shootPoint;

    private static Weapons instance;
    private bool boolTrap;
    private bool boolFlower;
    private int bulletTrapWeapon;
    private int bulletFlowerWeapon;

    public static Weapons Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

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
            GameObject obj = Instantiate(FlowerBullet, shootPoint.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 25));
            obj.transform.rotation = shootPoint.transform.rotation;
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
    public bool GetBulletMagazine()
    {
        if (boolTrap && !boolFlower)
            return true;
        else
            return false;

    }
    public int GetBulletTrap()
    {
        return bulletTrapWeapon;
    }
    public int GetFlowerWeapon()
    {
        return bulletFlowerWeapon;
    }

}
