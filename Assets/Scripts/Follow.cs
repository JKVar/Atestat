using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform playerTr;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Transform>();
        talaldMeg();
    }

    void talaldMeg()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if(go!=null)
        {
            playerTr = go.GetComponent<Transform>();
        }
        else
        {
            Invoke("talaldMeg", 0.2f);
        }
    }

    private void FixedUpdate()
    {
        cam.position = new Vector3(playerTr.position.x, playerTr.position.y, cam.position.z);
    }
}
