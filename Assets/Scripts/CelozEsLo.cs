using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelozEsLo : MonoBehaviour
{
    //public Camera cam;
    public Transform tankTr;
    public float turnSpeed=3f;
    Transform Tr;

    public GameObject golyo;
    public Transform firePoint;
    public float golyoSpeed=25f,fireRate=2f;

    float szog, lovesSzog = 0f;
    bool forogE = true;
    Vector2 egerPoz;
    Vector3 mousePoz;

    // Start is called before the first frame update
    void Start()
    {
        Tr=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //egerPoz = cam.ScreenToWorldPoint(Input.mousePosition);
        egerPoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoz = new Vector3(egerPoz.x,egerPoz.y);
        if(Input.GetButtonDown("Fire1") && forogE)
        {
            //ha lovok akkor megalla forgassal a tank
            forogE = false;
            Shoot();
            StartCoroutine(Waiting(1f/fireRate));
        }
    }

    private void FixedUpdate()
    {
        
        Vector3 nezIrany = mousePoz-tankTr.position;
        szog = Mathf.Atan2(nezIrany.y, nezIrany.x);
        
        if (forogE)
        {
            Quaternion rotat = new Quaternion(0f, 0f, Mathf.Sin(szog / 2), Mathf.Cos(szog / 2));
            Tr.rotation = Quaternion.Lerp(Tr.rotation, rotat, Time.fixedDeltaTime * turnSpeed);
        }
        Vector3 rotV3 = Tr.rotation.eulerAngles;
        lovesSzog = rotV3.z * Mathf.Deg2Rad;
    }
    
    protected void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(golyo, firePoint.position, firePoint.rotation);
        GO.GetComponent<golyoScript>().Init(lovesSzog);
    }

    IEnumerator Waiting(float sec)
    {
        yield return new WaitForSeconds(sec);
        forogE = true;

    }
}
