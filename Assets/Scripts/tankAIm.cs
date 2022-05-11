using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankAIm : MonoBehaviour
{
    public GameObject golyo;
    public Transform firePoint;
    //GameObject GO;
    Transform Tr;
    Transform playerTr;

    public float sRange = 20f, turnSpeed = 2f;
    public float fireRate = 1f;
    float tav;
    float szog,forSzog;
    bool kozelben = false,forogE=true;

    void Start()
    {
        Tr = GetComponent<Transform>();
        InvokeRepeating("jatekosKeres", 0f, 0.2f);
        InvokeRepeating("ujraTolt", 1.5f, 1 / fireRate);

    }

    void ujraTolt()
    {
        if (kozelben && forogE && playerTr!=null)
        {
            Loves();
        }
    }

    void jatekosKeres()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerTr = playerGO.transform;
        tav = Vector3.Distance(playerTr.position, Tr.position);
        if (tav <= sRange)
        {
            kozelben = true;
        }
        else
        {
            kozelben = false;
        }

    }

    private void FixedUpdate()
    {
        if(kozelben)
        {
            Forog();
        }
    }

    void Forog()
    {
        Vector2 irany = playerTr.position - Tr.position;
        szog = Mathf.Atan2(irany.y, irany.x);
        if (forogE)
        {
            Quaternion forog = new Quaternion(0f, 0f, Mathf.Sin(szog / 2), Mathf.Cos(szog / 2));
            Tr.rotation = Quaternion.Lerp(Tr.rotation, forog, Time.fixedDeltaTime * turnSpeed);
            
        }
        Vector3 forV3 = Tr.rotation.eulerAngles;
        forSzog = forV3.z*Mathf.Deg2Rad;

    }

    void Loves()
    {
        GameObject GO = (GameObject)Instantiate(golyo, firePoint.position, firePoint.rotation);
        GO.GetComponent<golyoScript>().Init(forSzog);
        forogE = false;
        StartCoroutine(Var(0.5f/fireRate));
    }

    IEnumerator Var(float fR)
    {
        yield return new WaitForSeconds(fR);
        forogE = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sRange);
    }
}
