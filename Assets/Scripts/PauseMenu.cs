using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Animator anim;

    public void Pause(bool szunetel)
    {
        if(szunetel)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    public void MenuBetolt()
    {
        AdatokMentes.Mentes(0);
        Time.timeScale = 1f;
        Cursor.visible = true;
        
        StartCoroutine(Varakozas(0));
        
    }

    public void Kilep()
    {
        AdatokMentes.Mentes(0);
        Application.Quit();
    }

    IEnumerator Varakozas(int level)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
