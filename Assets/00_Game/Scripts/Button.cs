using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private Button but;

    private void Start()
    {
        but = GetComponent<Button>();
    }

    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
        Game.Get().DestroyGame();
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }
}
