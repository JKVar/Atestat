using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject robbanasiEffekt;
    public healthBar hBar;
    public float maxHP=100f;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        if (hBar != null)
        {
            hBar.SetMaxHealth(HP);
        }
    }

    public void Sebez(float damage)
    {
        HP -= damage;
        if (hBar != null)
        {
            hBar.SetHealth(HP);
        }
        if(HP<=0)
        {
            Meghal();
        }
    }

    void Meghal()
    {
        Instantiate(robbanasiEffekt, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
