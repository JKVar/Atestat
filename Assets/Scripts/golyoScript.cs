using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golyoScript : MonoBehaviour
{
    public GameObject robbanasEffekt;
    public Rigidbody2D rb;
    public float speed = 40f;
    public float sebzes = 10f;
    float sz;

    public void Init(float szog)
    {
        sz = szog;
    }

    public void Loooo()
    {
        rb.velocity = new Vector2(Mathf.Cos(sz), Mathf.Sin(sz)) * speed;
        Invoke("Elpusztit", 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health enemy = collision.GetComponent<Health>();
            enemy.Sebez(sebzes);
        }
        if (collision.gameObject.tag == "Player")
        {
            Health player = collision.GetComponent<Health>();
            player.Sebez(sebzes);
        }
        if(collision.gameObject.tag!="Mocsar")
        {
            Instantiate(robbanasEffekt, transform.position, transform.rotation);
            Elpusztit();
        }
    }

    void Elpusztit()
    {
        Destroy(gameObject);
    }

}
