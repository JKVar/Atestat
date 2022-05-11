using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    //public GameObject player;
    public GameObject ellenseg;
    public Transform playerSPoint;
    public Transform ellensegSPoint;

    public SzamlaloIkon szamIkon;
    public GameObject WinMenu;
    public Text levelText;
    
    GameObject jatekos;

    public float ellensegSzama = 1f;
    float eNr=0f;
    bool folyatat = true;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.dataPath);
        //Instantiate(player, playerSPoint.position, playerSPoint.rotation);
        levelText.text  = "Level " + (SceneManager.GetActiveScene().buildIndex-1);
        Invoke("ellensegIdez",1f);
        jatekos = GameObject.FindGameObjectWithTag("Player");
        szamIkon.SetAlapErtek(ellensegSzama);
    }

    void ellensegIdez()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (eNr == ellensegSzama && enemy == null)
        {
            szamIkon.SetErtek(0f);
            //betolti a win Menu-t
            PlayerVane();
        }

        //ha nincs ellenseg akkor spawn-ol egyet
        if (enemy==null && eNr<ellensegSzama)
        {
            jatekos = GameObject.FindGameObjectWithTag("Player");
            Vector3 pPoz = jatekos.GetComponent<Transform>().position;
            float tav1 = Vector3.Distance(pPoz, playerSPoint.position);
            float tav2 = Vector3.Distance(pPoz, ellensegSPoint.position);
            if (tav1 <= tav2)
            {
                Instantiate(ellenseg, ellensegSPoint.position, ellensegSPoint.rotation);
            }
            else
            {
                Instantiate(ellenseg, playerSPoint.position, playerSPoint.rotation);
            }
            eNr++;
            szamIkon.SetErtek(ellensegSzama - eNr + 1);
        }
        if(enemy!=null && jatekos==null)
        {
            Lose();
        }

        if (folyatat)
        {
            Invoke("ellensegIdez", 0.2f);
        }
        
    }

    void PlayerVane()
    {
        if (jatekos.GetComponent<Health>().HP > 0)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    void Win()
    {
        //Time.timeScale = 0f;
        folyatat = false;
        Destroy(jatekos);
        WinMenu.SetActive(true);
        WinMenu.GetComponent<winMenu>().Nyert();
    }

    void Lose()
    {
        folyatat = false;
        //Time.timeScale = 0f;
        WinMenu.SetActive(true);
        WinMenu.GetComponent<winMenu>().Vesztett();
    }
}
