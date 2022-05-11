using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MocsarScript : MonoBehaviour
{
    int i=0,j=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && i<1)
        {
            TankIranyitas pSebesseg = collision.GetComponent<TankIranyitas>();
            pSebesseg.speed -= 1.5f;
            i++;
        }
        if (collision.gameObject.tag == "Enemy" && j < 1)
        {
            enemyMozog eSebesseg = collision.GetComponent<enemyMozog>();
            eSebesseg.speed -= 1.7f;
            j++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TankIranyitas pSebesseg = collision.GetComponent<TankIranyitas>();
            pSebesseg.speed += 1.5f;
            i = 0;
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemyMozog eSebesseg = collision.GetComponent<enemyMozog>();
            eSebesseg.speed += 1.7f;
            j = 0;
        }
    }

}
