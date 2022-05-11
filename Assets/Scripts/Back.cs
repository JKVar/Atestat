using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public Animator anim;

    public void Vissza()
    {
        StartCoroutine(Varakozas(0));
    }

    IEnumerator Varakozas(int level)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
