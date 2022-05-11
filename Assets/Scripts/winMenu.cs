using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winMenu:PauseMenu
{
    //public Animator anim;
    public GameObject yWin;
    public GameObject yLose;
    public GameObject nLevelButton;
    public GameObject retryButton;

    public void Nyert()
    {
        Cursor.visible = true;
        yWin.SetActive(true);
        nLevelButton.SetActive(true);
        yLose.SetActive(false);
        retryButton.SetActive(false);
        Ment();
    }

    public void Vesztett()
    {
        Cursor.visible = true;
        yWin.SetActive(false);
        nLevelButton.SetActive(false);
        yLose.SetActive(true);
        retryButton.SetActive(true);
    }

    public void LoadNextLevel()
    {
        
        //anim.SetTrigger("Start");
        StartCoroutine(Varakozas(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void Retry()
    {
        //Time.timeScale = 1f;
        
        StartCoroutine(Varakozas(SceneManager.GetActiveScene().buildIndex));
    }

    void Ment()
    {
        AdatokMentes.Mentes(1);
    }
    

    IEnumerator Varakozas(int level)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }
}
