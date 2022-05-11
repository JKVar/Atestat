using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SzamlaloIkon : MonoBehaviour
{
    //public Text text;
    public Text text;

    public void SetAlapErtek(float maxEllensegNr)
    {
        text.text = maxEllensegNr + " x";
        //t.text = maxEllensegNr + " x";
    }

    public void SetErtek(float ellensegNr)
    {
        text.text = ellensegNr + " x";
        //t.text = ellensegNr + " x";
    }
}
