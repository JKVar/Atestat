using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kurzor : MonoBehaviour
{
    //public Camera cam;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pozicio = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pozicio;
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("klikk");
        }
    }
}
