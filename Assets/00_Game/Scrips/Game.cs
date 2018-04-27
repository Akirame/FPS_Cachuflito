using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;
    private int Score;
    private int Health;
    
    public static Game get()
    {
        return instance;
    }
    private void Start()
    {
        Score = 0;
        Health = 100;
    }
    private void Awake()
    {        
        instance = this;
        DontDestroyOnLoad(instance);
    }
    public void AddScore(int score)
    {
        Score += score;        
    }
}
