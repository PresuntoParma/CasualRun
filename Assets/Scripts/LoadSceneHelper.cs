using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(string i)
    {
        SceneManager.LoadScene(i);
    }
}
