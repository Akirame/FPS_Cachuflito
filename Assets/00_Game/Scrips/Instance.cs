using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{

    public Transform prefab1;
    public Transform prefab2;
    public Transform prefab3;
    public Transform prefab4;
    public Transform prefabWall;
    public GameObject trap;
    private Transform[] prefabs;
    private int[] randomEuler;
    private float spawnTrapTimer;

    void Start()
    {
        spawnTrapTimer = 10;
        randomEuler = new int[] { 0, 90 };
        prefabs = new Transform[] { prefab1, prefab2, prefab3, prefab4 };

        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(i * 20, 0, 0), Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), this.transform);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(i * 20, 0, 20), Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), this.transform);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(i * 20, 0, 40), Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), this.transform);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(i * 20, 0, -20), Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), this.transform);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(i * 20, 0, -40), Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), this.transform);            
        }
        Instantiate(prefabWall, new Vector3(40, 0, -49.6f), Quaternion.identity, this.transform);
        InvokeRepeating("SpawnTraps", spawnTrapTimer, spawnTrapTimer);
    }
    private void Update()
    {    
    }
    private void SpawnTraps()
    {
        Instantiate(trap, new Vector3(Random.Range(-9f,89f), 0.2f,Random.Range(49f,-49f)), Quaternion.identity, this.transform);
        Instantiate(trap, new Vector3(Random.Range(-9f, 89f), 0.2f, Random.Range(49f, -49f)), Quaternion.identity, this.transform);
        Instantiate(trap, new Vector3(Random.Range(-9f, 89f), 0.2f, Random.Range(49f, -49f)), Quaternion.identity, this.transform);
    }
}
