using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIranyitas : MonoBehaviour
{
    public Transform Tr;
    //public Animator anim;
    public float speed = 4f;
    public float turnSpeed = 1.5f;

    

    Vector2 irany;
    float mozgasSzog = 0f;


    // Update is called once per frame
    void Update()
    {
        irany.y = Input.GetAxisRaw("Vertical");
        irany.x = Input.GetAxisRaw("Horizontal");
        //anim.SetFloat("tankMegy", irany.y);/*
        
    }

    private void FixedUpdate()
    {
        float mozgasDSzog = -irany.x * Time.fixedDeltaTime * turnSpeed;
        mozgasSzog += mozgasDSzog;
        Tr.position = Tr.position + new Vector3(Mathf.Cos(mozgasSzog), Mathf.Sin(mozgasSzog), 0f)* speed*irany.y * Time.fixedDeltaTime;
        Tr.RotateAroundLocal(Vector3.forward, mozgasDSzog);
    }
}
