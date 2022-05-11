using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour
{
    public Animator anim;
    float sec = 1f;

    public void newGame()
    {
        StartCoroutine(Varakozas(SceneManager.GetActiveScene().buildIndex + 2));
    }

    public void LoadGame()
    {
        Adatok adat = AdatokMentes.AdatokBetolt();
        
        StartCoroutine(Varakozas(adat.sceneIndex));
    }
    
    IEnumerator Varakozas(int level)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(level);
    }
}
