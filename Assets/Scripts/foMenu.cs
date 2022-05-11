using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class foMenu : MonoBehaviour
{
    public Animator anim;

    public void Kilep()
    {
        Debug.Log("Kilep.");
        Application.Quit();
    }

    public void HowToPlay()
    {
        StartCoroutine(Varakozas(1));
    }

    IEnumerator Varakozas(int level)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
