using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //public PauseMenu pause;
    public GameObject pMenu;
    PauseMenu pause;

    private void Start()
    {
        pause = pMenu.GetComponent<PauseMenu>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pMenu.SetActive(true);
            pause.Pause(true);
        }
    }
}
