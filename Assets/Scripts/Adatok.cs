using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Adatok
{
    public int sceneIndex;

    public Adatok()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }
}
