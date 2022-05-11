using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinityGM : MonoBehaviour
{
    public GameObject ellenseg;

    public SzamlaloIkon szamIkon;
    //public GameObject WinMenu;
    public Text levelText,killText;

    float ellensegSzama = 0f;
    float eNr = 0f, kill = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.dataPath);
        //Instantiate(player, playerSPoint.position, playerSPoint.rotation);
        levelText.text = "The End - Infinity mode";
        InvokeRepeating("Spawn", 1f,5f);
        InvokeRepeating("Keres", 1f, 0.1f);
        szamIkon.SetAlapErtek(ellensegSzama);
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-40f,40f), Random.Range(-40f, 40f),transform.rotation.z);
        Instantiate(ellenseg, pos, transform.rotation);
    }

    void Keres()
    {
        eNr = ellensegSzama;
       
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        ellensegSzama = enemy.Length;

        if(ellensegSzama<eNr)
        {
            kill += eNr - ellensegSzama;
        }

        killText.text = "Kills: " + kill;
        szamIkon.SetErtek(ellensegSzama);
    }
}
