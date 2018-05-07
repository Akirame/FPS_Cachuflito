using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    public void LoadScene0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Game.Get().DestroyGame();
    }

    public void LoadScene1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
