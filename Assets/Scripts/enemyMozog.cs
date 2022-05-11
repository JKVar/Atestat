using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMozog : MonoBehaviour
{
    public Transform Tr;
    public float sRange = 30f;
    public float speed=3.25f,turnSpeed=1.5f;
    public float stopRange = 8f;

    Transform playerTr;

    bool kozelben = false;
    float tav,szog;
    float mozSzog;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("jatekosKeres", 0f, 0.2f);
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
        if(kozelben && tav>=stopRange)
        {
            Forgat();
        }
    }

    void Forgat()
    {
        Vector2 irany = playerTr.position - Tr.position;
        szog = Mathf.Atan2(irany.y, irany.x);

        Quaternion forog = new Quaternion(0f, 0f, Mathf.Sin(szog / 2), Mathf.Cos(szog / 2));
        Tr.rotation = Quaternion.Lerp(Tr.rotation, forog, Time.fixedDeltaTime*turnSpeed);

        mozSzog = Mathf.Asin(Tr.rotation.z)*2;
        Mozgat();
    }

    void Mozgat()
    {
        Tr.position += new Vector3(Mathf.Cos(mozSzog), Mathf.Sin(mozSzog), 0f)*Time.fixedDeltaTime*speed;
    }
}
