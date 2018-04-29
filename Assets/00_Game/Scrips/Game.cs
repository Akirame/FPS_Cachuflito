using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static Game instance;
    private int _Score;
    private int _Health;
    
    public static Game Get()
    {
        return instance;
    }
    private void Start()
    {
        _Score = 0;
        _Health = 100;
    }

    private void Update()
    {
        if (_Health <= 0)
        {
            SceneManager.LoadScene(2);
            _Health = 100;            
        }        
    }
    private void Awake()
    {        
        instance = this;        
    }
    public void AddScore(int score)
    {
        _Score += score;        
    }
    public void SetHealth(int health)
    {
        _Health -= health;
    }
}
